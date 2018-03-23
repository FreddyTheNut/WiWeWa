using SMPHCracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WiWeWa.View;
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
            {typeof(TrialPageViewModel), Pages.TrialPage },
            {typeof(MainPageViewModel), Pages.MainPage }
        };

        public static void Alert(string title, string message)
        {
            App.Current.MainPage.DisplayAlert(title, message, "OK");
        }

        public async static Task<string> ActionSheetAlert(string title, params string[] actions)
        {
            return await App.Current.MainPage.DisplayActionSheet(title, "Abbrechen", null, actions);
        }

        public static void NavigatePage(Type viewModel)
        {
            Page page = GetPage(viewModel);

            INavigation navigation = App.Current.MainPage.Navigation;
            Device.BeginInvokeOnMainThread(() => navigation.PushAsync(page));
        }

        public static void NavigateBack()
        {
            INavigation navigation = App.Current.MainPage.Navigation;
            Device.BeginInvokeOnMainThread(() => navigation.PopAsync());
        }

        private static Page GetPage(Type viewModel)
        {
            switch (viewModelsDic[viewModel])
            {
                case Pages.TrialPage:
                    return new TrialPage();

                case Pages.MainPage:
                    return new MainPage();
            }

            return null;
        }
    }
}
