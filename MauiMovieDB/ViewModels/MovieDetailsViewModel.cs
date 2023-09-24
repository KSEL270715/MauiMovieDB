using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiMovieDB.Interfaces;
using MauiMovieDB.Models;
using MauiMovieDB.Utils;
using Newtonsoft.Json;

namespace MauiMovieDB.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private readonly IAPIService _iAPIService;
        private readonly ISecurityService _securityService;
        public int? ID { get; set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private int _releasedYearMovie;
        public int ReleasedYearMovie
        {
            get { return _releasedYearMovie; }
            set
            {
                _releasedYearMovie = value;
                OnPropertyChanged(nameof(ReleasedYearMovie));
            }
        }
        private string _movieBackdropPath;
        public string MovieBackdropPath
        {
            get { return _movieBackdropPath; }
            set
            {
                _movieBackdropPath = value;
                OnPropertyChanged(nameof(MovieBackdropPath));
            }
        }
        private double _ratingPercentage;
        public double RatingPercentage
        {
            get { return _ratingPercentage; }
            set
            {
                _ratingPercentage = value;
                OnPropertyChanged(nameof(RatingPercentage));
            }
        }
        private string _genres;
        public string Genres
        {
            get { return _genres; }
            set
            {
                _genres = value;
                OnPropertyChanged(nameof(Genres));
            }
        }
        private bool _isAdult;
        public bool IsAdult
        {
            get { return _isAdult; }
            set
            {
                _isAdult = value;
                OnPropertyChanged(nameof(IsAdult));
            }
        }
        private string _tagline;
        public string Tagline
        {
            get { return _tagline; }
            set
            {
                _tagline = value;
                OnPropertyChanged(nameof(Tagline));
            }
        }
        private string _overview;
        public string Overview
        {
            get { return _overview; }
            set
            {
                _overview = value;
                OnPropertyChanged(nameof(Overview));
            }
        }
        private string _collectionName;
        public string CollectionName
        {
            get { return _collectionName; }
            set
            {
                _collectionName = value;
                OnPropertyChanged(nameof(CollectionName));
            }
        }
        private ObservableCollection<Cast> _castList;
        public ObservableCollection<Cast> CastList
        {
            get { return _castList; }
            set
            {
                _castList = value;
                OnPropertyChanged(nameof(CastList));
            }
        }
        private bool _isFavourite;
        public bool IsFavourite
        {
            get { return _isFavourite; }
            set
            {
                _isFavourite = value;
                OnPropertyChanged(nameof(IsFavourite));
            }
        }
        public ICommand MarkFavouriteCommand { get; set; }
        public MovieDetailsViewModel(IAPIService iAPIService, ISecurityService securityService)
        {
            _iAPIService = iAPIService;
            _securityService = securityService;
            MarkFavouriteCommand = new Command<object>(async (o) => { await ExecuteMarkFavouriteCommand(o); });
        }
        public async Task ExecuteMarkFavouriteCommand(object movieID)
        {
            int? id = movieID as int?;
            if (id.HasValue)
            {
                FavouriteMovieRequest favouriteMovieRequest = new FavouriteMovieRequest()
                {
                    MediaType = "movie",
                    MediaId = id.Value,
                    Favorite = !IsFavourite
                };

                string endPoint = "/account/" + _securityService.AccountID + "/favorite?session_id=" + _securityService.SessionID;
                await _iAPIService.PostRequestPathAsync<FavouriteMovieRequest>(endPoint, JsonConvert.SerializeObject(favouriteMovieRequest));
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    IsFavourite = !IsFavourite;
                });
            }
        }
        public async override Task LoadDetails(object param = null)
        {
            int? id = param as int?;
            ID = id;
            var MovieDetails = await _iAPIService.GetRequestAsync<MovieDetails>(AppConstants.GetMovieDetails + "/" + id);
            var castDetails = await _iAPIService.GetRequestAsync<CastModel>(AppConstants.GetMovieDetails + "/" + id + "/credits");
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Title = MovieDetails.Title;
                MovieBackdropPath = MovieDetails.MovieBackdropPath;
                ReleasedYearMovie = MovieDetails.ReleasedYearMovie;
                RatingPercentage = MovieDetails.VoteAverage;
                Genres = string.Join(",", MovieDetails.Genres.Select(p => p.Name));
                IsAdult = MovieDetails.Adult;
                Tagline = MovieDetails.Tagline;
                Overview = MovieDetails.Overview;
                CollectionName = MovieDetails.BelongsToCollection?.Name;
                CastList = new ObservableCollection<Cast>(castDetails.Cast);
            });

        }
    }
}

