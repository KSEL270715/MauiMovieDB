using System;
namespace MauiMovieDB.Interfaces
{
    public interface ISecurityService
    {
        string SessionID { get; set; }
        string RequestToken { get; set; }
        int AccountID { get; set; }
    }
}

