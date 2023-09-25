using MauiMovieDB.Interfaces;
using MauiMovieDB.ViewModels;
using MauiMovieDB.Views;

namespace MauiMovieDB;

public partial class App : Application
{
    LoginPage loginPage = new LoginPage();
    public App()
    {
        InitializeComponent();

        MainPage = loginPage;
        
    }

    protected override void OnStart()
    {
        base.OnStart();
        LoginViewModel loginViewModel = Handler.MauiContext.Services.GetService<LoginViewModel>();
        loginPage.BindingContext = loginViewModel;
        //INavigationService navigationService = Handler.MauiContext.Services.GetService<INavigationService>();
        //navigationService.NavigateTo(nameof(LoginViewModel));
    }
}

