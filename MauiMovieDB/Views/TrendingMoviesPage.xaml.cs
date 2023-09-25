
using MauiMovieDB.Models;
using MauiMovieDB.ViewModels;

namespace MauiMovieDB.Views;

public partial class TrendingMoviesPage : ContentPage
{
    TrendingMoviesViewModel _viewModel;
    public TrendingMoviesPage()
    {
        InitializeComponent();
        _viewModel = Application.Current.MainPage.Handler.MauiContext.Services.GetService<TrendingMoviesViewModel>();

    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDetails();
        this.BindingContext = _viewModel;
    }

}
