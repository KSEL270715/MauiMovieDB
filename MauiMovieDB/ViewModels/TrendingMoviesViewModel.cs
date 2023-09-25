using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiMovieDB.Interfaces;
using MauiMovieDB.Models;
using MauiMovieDB.Utils;

namespace MauiMovieDB.ViewModels
{
    public class TrendingMoviesViewModel : BaseViewModel
    {
        private readonly IAPIService _apiService;
        private readonly INavigationService _navigationService;
        private readonly ISecurityService _securityService;

        private ObservableCollection<MovieList> _listMovieList;
        public ObservableCollection<MovieList> ListMovieList
        {
            get { return _listMovieList; }
            set
            {
                _listMovieList = value;
                OnPropertyChanged(nameof(ListMovieList));
            }
        }

        public ICommand SelectPopularMovieCommand { get; set; }

        public TrendingMoviesViewModel(IAPIService apiService, INavigationService navigationService, ISecurityService securityService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
            _securityService = securityService;
            SelectPopularMovieCommand = new Command<object>(async (o) => { await ExecuteSelectPopularMovieCommand(o); });
        }

        public async override Task LoadDetails(object param = null)
        {
            try
            {
                MovieResults movieResults = await _apiService.GetRequestAsync<MovieResults>(AppConstants.GetTrendingMovie+"/day");
                string endPoint = "/account/" + _securityService.AccountID + "/favorite/movies?session_id=" + _securityService.SessionID;
                MovieResults favouriteMovieResults = await _apiService.GetRequestPathAsync<MovieResults>(endPoint);
                foreach (var movie in favouriteMovieResults.Results)
                {
                    MovieList favMovie = movieResults.Results.FirstOrDefault(m => m.Id == movie.Id);
                    if (favMovie != null)
                    {
                        favMovie.Favourite = true;
                    }
                }
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ListMovieList = new ObservableCollection<MovieList>(movieResults.Results);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private async Task ExecuteSelectPopularMovieCommand(object MovieListParam)
        {
            MovieList movieList = MovieListParam as MovieList;
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("id", movieList.Id);
            keyValuePairs.Add("fav", movieList.Favourite);
            await _navigationService.NavigateTo("MovieDetailsViewModel", keyValuePairs);
        }
    }
}

