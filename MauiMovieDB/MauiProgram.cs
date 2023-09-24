using MauiMovieDB.Interfaces;
using MauiMovieDB.Models;
using MauiMovieDB.Services;
using MauiMovieDB.ViewModels;
using MauiMovieDB.Views;
using Microsoft.Extensions.Logging;

namespace MauiMovieDB;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.RegisterServices();
        builder.RegisterViewModels();
        builder.RegisterViews();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-regular-400.ttf", "FA-R");
                fonts.AddFont("fa-light-300.ttf", "FA-L");
                fonts.AddFont("fa-solid-900.ttf", "FA-S");
                fonts.AddFont("fa-brands-400.ttf", "FA-B");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static void RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
        mauiAppBuilder.Services.AddSingleton<ILoginService, LoginService>();
        mauiAppBuilder.Services.AddSingleton<IAPIService, APIService>();
        mauiAppBuilder.Services.AddSingleton<ISecurityService, SecurityService>();
    }

    public static void RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton(typeof(LoginViewModel));
        mauiAppBuilder.Services.AddSingleton(typeof(DashboardViewModel));
        mauiAppBuilder.Services.AddSingleton(typeof(PopularMoviesViewModel));
        mauiAppBuilder.Services.AddSingleton(typeof(TrendingMoviesViewModel));
        mauiAppBuilder.Services.AddSingleton(typeof(MovieDetailsViewModel));
    }

    private static void RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton(typeof(LoginPage));
        mauiAppBuilder.Services.AddSingleton(typeof(DashboardPage));
        mauiAppBuilder.Services.AddTransient(typeof(MovieDetailsPage));
    }
}

