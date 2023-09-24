using System;
using Newtonsoft.Json;

namespace MauiMovieDB.Models
{
    public class LoginModel
    {
        public string username;
        public string password;
        public string request_token;
    }
    public class LoginResponseModel
    {
        public string success;
        public string expires_at;
        public string request_token;
    }
    public class LoginSessionModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }
    }
    public class LoginSessionRequest
    {
        [JsonProperty("request_token")]
        public string RequestToken { get; set; }
    }
    public class Avatar
    {
        [JsonProperty("gravatar")]
        public Gravatar Gravatar { get; set; }

        [JsonProperty("tmdb")]
        public Tmdb Tmdb { get; set; }
    }

    public class Gravatar
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }

    public class AccountDetails
    {
        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("include_adult")]
        public bool IncludeAdult { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class Tmdb
    {
        [JsonProperty("avatar_path")]
        public object AvatarPath { get; set; }
    }
}

