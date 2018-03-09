using SMPHCracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WiWeWa.View;
using WiWeWa.ViewModel;
using WiWeWa.ViewModel.ViewViewModel;
using Xamarin.Forms;

namespace WiWeWa
{
    public sealed class PageController
    {
        enum Pages
        {
            LoadingPage,
            TrialPage,
            MainPage
        }
        private static Dictionary<Type, Pages> viewModelsDic = new Dictionary<Type, Pages>()
        {
            {typeof(LoadingPageViewModel), Pages.LoadingPage },
            {typeof(TrialPageViewModel), Pages.TrialPage },
            {typeof(MainPageViewModel), Pages.MainPage }
        };

        public static void OpenPage(Type viewModel)
        {
            Device.BeginInvokeOnMainThread(() => App.Current.MainPage = GetPage(viewModel));
        }

        public static void OpenPage(Type viewModel, Type viewModelClose)
        {
            OpenPage(viewModel);

            switch (viewModelsDic[viewModelClose])
            {
                case Pages.LoadingPage:
                    ViewModelLocator.ClearLoadingPageViewModel();
                    break;

                case Pages.TrialPage:
                    ViewModelLocator.ClearTrialPageViewModel();
                    break;

                case Pages.MainPage:
                    ViewModelLocator.ClearMainPageViewModel();
                    break;
            }
        }

        public static void NavigatePage(Type viewModel)
        {
            Page page = GetPage(viewModel);

            INavigation navigation = App.Current.MainPage.Navigation;

            if (navigation.NavigationStack.Count > 0)
            {
                Device.BeginInvokeOnMainThread(() => navigation.PushAsync(page));
            }            
            else
            {
                NavigationPage navigationPage = new NavigationPage(App.Current.MainPage);
                navigationPage.PushAsync(page);

                Device.BeginInvokeOnMainThread(() => App.Current.MainPage = navigationPage);
            }
        }

        private static Page GetPage(Type viewModel)
        {
            switch (viewModelsDic[viewModel])
            {
                case Pages.LoadingPage:
                    return new LoadingPage();

                case Pages.TrialPage:
                    return new TrialPage();

                case Pages.MainPage:
                    return new MainPage();
            }

            return null;
        }
    }
}
