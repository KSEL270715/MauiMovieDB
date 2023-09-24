using MauiMovieDB.Models;
using MauiMovieDB.ViewModels;

namespace MauiMovieDB.Views;

public partial class PopularMoviesPage : ContentPage
{
    PopularMoviesViewModel _viewModel = null;
    public PopularMoviesPage()
    {
        InitializeComponent();
        _viewModel = Application.Current.MainPage.Handler.MauiContext.Services.GetService<PopularMoviesViewModel>();

    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDetails();
        this.BindingContext = _viewModel;
    }

    async void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        MovieDetailsPage movieDetailsPage = Application.Current.MainPage.Handler.MauiContext.Services.GetService<MovieDetailsPage>();
        MovieDetailsViewModel movieDetailsViewModel = Application.Current.MainPage.Handler.MauiContext.Services.GetService<MovieDetailsViewModel>();
        movieDetailsViewModel.ID = ((sender as Grid).BindingContext as MovieList).Id;
        movieDetailsViewModel.IsFavourite = ((sender as Grid).BindingContext as MovieList).Favourite;
        await Application.Current.MainPage.Navigation.PushAsync(movieDetailsPage);
    }
}
