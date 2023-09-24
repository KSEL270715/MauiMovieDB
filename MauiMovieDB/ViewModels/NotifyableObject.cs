using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiMovieDB.ViewModels
{
    public class NotifyableObject : INotifyPropertyChanged
    {
        public NotifyableObject()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

