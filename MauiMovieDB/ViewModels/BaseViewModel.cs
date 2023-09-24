using System;
namespace MauiMovieDB.ViewModels
{
    public abstract class BaseViewModel : NotifyableObject
    {
        public BaseViewModel()
        {
        }
        public async virtual Task LoadDetails(object param = null)
        {

        }
    }
}

