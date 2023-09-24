using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiMovieDB.Interfaces
{
    public interface IAPIService
    {
        Task<T> GetRequestAsync<T>(string endPoint, string queryParam = "");
        Task<T> GetRequestPathAsync<T>(string endPoint, string queryParam = "");
        Task<T> PostRequestAsync<T>(string endPoint, string body, string queryParam = "");
        Task<T> PostRequestPathAsync<T>(string endPoint, string body, string queryParam = "");
    }
}

