using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using MauiMovieDB.Interfaces;
using MauiMovieDB.Utils;
using Newtonsoft.Json;

namespace MauiMovieDB.Services
{
    public class APIService : IAPIService
    {
        public APIService()
        {
        }

        public async Task<T> GetRequestAsync<T>(string endPoint, string queryParam = "")
        {
            string responseContent = string.Empty;
            string apikey = "?api_key=" + AppConstants.APIKey;
            string requestURL = AppConstants.BaseURL + endPoint + apikey + queryParam;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestURL);
            request.Headers.Add("accept", "application/json");

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<T> GetRequestPathAsync<T>(string endPoint, string queryParam = "")
        {
            string responseContent = string.Empty;
            string apikey = "&api_key=" + AppConstants.APIKey;
            string requestURL = AppConstants.BaseURL + endPoint + apikey + queryParam;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestURL);
            request.Headers.Add("accept", "application/json");

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<T> PostRequestAsync<T>(string endPoint, string httpRequestBodyJson, string queryParam)
        {
            string responseContent = string.Empty;

            string apikey = "?api_key=" + AppConstants.APIKey;

            string requestURL = AppConstants.BaseURL + endPoint + apikey + queryParam;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            var content = new StringContent(httpRequestBodyJson, Encoding.UTF8, "application/json");

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestURL),
                Headers = {
            { HttpRequestHeader.Accept.ToString(), "application/json" }
        },
                Content = new StringContent(httpRequestBodyJson)
            };
            httpRequestMessage.Headers.Add("ContentType", "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestURL),
                Headers =
    {
        { "accept", "application/json" },
    },
                Content = new StringContent(httpRequestBodyJson)
                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
        public async Task<T> PostRequestPathAsync<T>(string endPoint, string httpRequestBodyJson, string queryParam)
        {
            string responseContent = string.Empty;

            string apikey = "&api_key=" + AppConstants.APIKey;

            string requestURL = AppConstants.BaseURL + endPoint + apikey + queryParam;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            var content = new StringContent(httpRequestBodyJson, Encoding.UTF8, "application/json");

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestURL),
                Headers = {
            { HttpRequestHeader.Accept.ToString(), "application/json" }
        },
                Content = new StringContent(httpRequestBodyJson)
            };
            httpRequestMessage.Headers.Add("ContentType", "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestURL),
                Headers =
    {
        { "accept", "application/json" },
    },
                Content = new StringContent(httpRequestBodyJson)
                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}

