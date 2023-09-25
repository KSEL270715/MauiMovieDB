using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiMovieDB.Interfaces;
using MauiMovieDB.Services;

namespace MauiMovieDB.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;
        private string _userName= "Kalaiselvan0727";
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }

        }
        private string _password= "Kalaiselvan@123";
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }

        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(ILoginService loginService, INavigationService navigationService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
            LoginCommand = new Command(ExecuteLoginCommand);
        }

        private async void ExecuteLoginCommand()
        {
            bool isValidUser = await _loginService.ValidateLoginAsync(UserName, Password);
            if (isValidUser)
            {
                await _navigationService.InitNavigationPage(nameof(DashboardViewModel));
            }
            else
            {
                //Show Error Message
            }
        }

        public override async Task LoadDetails(object param = null)
        {
            await Task.CompletedTask;
            // throw new NotImplementedException();
        }
    }
}

