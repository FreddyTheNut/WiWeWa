using SMPHCracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WiWeWa.View;
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
            if(viewModel != null)
            {
                 switch (viewModels[viewModel])
                 {
                     case 0:
                         Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new LoadingPage());
                         break;

                     case 1:
                         Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new TrialPage());
                         break;

                     case 2:
                         Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new MainPage());
                         break;
                 }
            }
        }
    }
}
