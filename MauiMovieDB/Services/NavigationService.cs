using System;
using MauiMovieDB.Interfaces;
using MauiMovieDB.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MauiMovieDB.Services
{
    public class NavigationService : INavigationService
    {
        private Page _mainPage => Application.Current.MainPage;
        private IServiceProvider _serviceProvider => Application.Current.MainPage.Handler.MauiContext.Services;

        public NavigationService()
        {

        }
        public async Task InitNavigationPage(string viewModel, object parameter = null)
        {
            //Page page = GetPage(viewModel);
            string pageName = viewModel.Replace("ViewModel", "Page");
            var pageType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(o => o.GetTypes()).FirstOrDefault(o => o.Name == pageName);
            var page = _serviceProvider.GetService(pageType) as TabbedPage;
            BaseViewModel baseViewModel = GetViewModel(viewModel);
            page.BindingContext = baseViewModel;
            await baseViewModel.LoadDetails(parameter);
            NavigationPage navigationPage = new NavigationPage(page);
            navigationPage.BarBackgroundColor = Color.FromArgb("#202020");
            Application.Current.MainPage = navigationPage;
        }
        public async Task NavigateTo(string viewModel, object parameter = null)
        {
            ContentPage page = GetPage(viewModel);
            BaseViewModel baseViewModel = GetViewModel(viewModel);
            page.BindingContext = baseViewModel;
            await baseViewModel.LoadDetails(parameter);
            await _mainPage.Navigation.PushAsync(page);
        }
        public async Task NavigateBack()
        {
            await _mainPage.Navigation.PopAsync();
        }
        private ContentPage GetPage(string viewModel)
        {
            string pageName = viewModel.Replace("ViewModel", "Page");
            var pageType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(o => o.GetTypes()).FirstOrDefault(o => o.Name == pageName);
            var page = _serviceProvider.GetService(pageType) as ContentPage;
            return page;
        }
        private BaseViewModel GetViewModel(string viewModel)
        {
            var pageType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(o => o.GetTypes()).FirstOrDefault(o => o.Name == viewModel);
            var page = _serviceProvider.GetService(pageType);
            return page as BaseViewModel;
        }
    }
}

