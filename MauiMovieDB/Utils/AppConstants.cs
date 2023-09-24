using System;
namespace MauiMovieDB.Utils
{
    public static class AppConstants
    {
        public const string APIKey = "63455be405499cb794650868c77f1e27";
        public const string BaseURL = "https://api.themoviedb.org/3";
        public const string GetRequestTokenEndPoint = "/authentication/token/new";
        public const string GetRequestValidateLogin = "/authentication/token/validate_with_login";
        public const string GetPopularMovie = "/movie/popular";
        public const string GetTrendingMovie = "/trending/movie";
        public const string GetMovieDetails = "/movie";
        public const string PostCreateNewSession = "/authentication/session/new";
        public const string GetAccountDetails = "/account";
        public const string ImageRootPath = "https://image.tmdb.org/t/p/w500/";
    }
}

