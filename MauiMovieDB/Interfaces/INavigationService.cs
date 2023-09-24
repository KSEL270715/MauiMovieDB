using System;
namespace MauiMovieDB.Interfaces
{
	public interface INavigationService
	{
		Task InitNavigationPage(string pageName, object parameter = null);
        Task NavigateTo(string pageName, object parameter = null);
		Task NavigateBack();
	}
}

