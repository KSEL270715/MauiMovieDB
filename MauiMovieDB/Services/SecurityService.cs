using System;
using MauiMovieDB.Interfaces;
using MauiMovieDB.Utils;

namespace MauiMovieDB.Services
{
    public class SecurityService : ISecurityService
    {
        public SecurityService()
        {

        }
        public string SessionID { get; set; }
        public string RequestToken { get; set; }
        public int AccountID { get; set; }

    }
}

