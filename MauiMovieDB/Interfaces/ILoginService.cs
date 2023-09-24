using System;
namespace MauiMovieDB.Services
{
	public interface ILoginService
	{
		Task<bool> ValidateLoginAsync(string userName,string password);
	}
}

