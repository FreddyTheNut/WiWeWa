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
        private static Dictionary<Type, int> viewModels = new Dictionary<Type, int>()
        {
            {typeof(LoadingPageViewModel), 0 },
            {typeof(TrialPageViewModel), 1 },
            {typeof(MainPageViewModel), 2 }
        };

        public static void OpenPage(Type viewModel)
        {
            Page page = null;

            switch (viewModels[viewModel])
            {
                case 0:
                    page = new LoadingPage();
                    break;

                case 1:
                    page = new TrialPage();
                    break;

                case 2:
                    page = new MainPage();
                    break;
            }

            Device.BeginInvokeOnMainThread(() => App.Current.MainPage = page);
        }

        public static void OpenPage(Type viewModel, Type viewModelClose)
        {
            OpenPage(viewModel);

            switch (viewModels[viewModelClose])
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
    }
}
