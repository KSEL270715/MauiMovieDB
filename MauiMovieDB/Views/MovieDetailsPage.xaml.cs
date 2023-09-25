
using MauiMovieDB.ViewModels;

namespace MauiMovieDB.Views;

public partial class MovieDetailsPage : ContentPage
{
    MovieDetailsViewModel _viewModel = null;
    public MovieDetailsPage()
    {
        InitializeComponent();
        // _viewModel = Application.Current.MainPage.Handler.MauiContext.Services.GetService<MovieDetailsViewModel>();
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
       //_viewModel = this.BindingContext as MovieDetailsViewModel;
       // await _viewModel.LoadDetails(_viewModel.ID);
       // this.BindingContext = _viewModel;
    }

}
