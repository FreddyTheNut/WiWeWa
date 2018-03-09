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
        private static Dictionary<Type, int> viewModelsDic = new Dictionary<Type, int>()
        {
            {typeof(LoadingPageViewModel), 0 },
            {typeof(TrialPageViewModel), 1 },
            {typeof(MainPageViewModel), 2 }
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
                case 0:
                    ViewModelLocator.ClearLoadingPageViewModel();
                    break;

                case 1:
                    ViewModelLocator.ClearTrialPageViewModel();
                    break;

                case 2:
                    ViewModelLocator.ClearMainPageViewModel();
                    break;
            }
        }

        public static void NavigatePage(Type viewModel)
        {
            Page page = GetPage(viewModel);

            INavigation navigation = App.Current.MainPage.Navigation;

            if (navigation.NavigationStack.Count < 0)
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
                case 0:
                    return new LoadingPage();

                case 1:
                    return new TrialPage();

                case 2:
                    return new MainPage();
            }

            return null;
        }
    }
}
