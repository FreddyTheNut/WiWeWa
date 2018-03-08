using WiWeWa.ViewModel.ViewViewModel;

namespace SMPHCracker.ViewModel
{
    public sealed class ViewModelLocator
    {

        #region MainPageViewModel
        private static MainPageViewModel mainPage;

        public MainPageViewModel MainPage
        {
            get
            {
                return MainPageStatic;
            }
        }

        public static MainPageViewModel MainPageStatic
        {
            get
            {
                if (mainPage == null)
                {
                    mainPage = new MainPageViewModel();
                }

                return mainPage;
            }
        }

        public static void ClearMainPageViewModel()
        {
            mainPage = null;
        }
        #endregion

        #region LoadingPageViewModel
        private static LoadingPageViewModel loadingPage;

        public LoadingPageViewModel LoadingPage
        {
            get
            {
                return LoadingPageStatic;
            }
        }

        public static LoadingPageViewModel LoadingPageStatic
        {
            get
            {
                if (loadingPage == null)
                {
                    loadingPage = new LoadingPageViewModel();
                }

                return loadingPage;
            }
        }

        public static void ClearLoadingPageViewModel()
        {
            loadingPage = null;
        }
        #endregion

        #region TrialPageViewModel
        private static TrialPageViewModel trialPage;

        public TrialPageViewModel TrialPage
        {
            get
            {
                return TrialPageStatic;
            }
        }

        public static TrialPageViewModel TrialPageStatic
        {
            get
            {
                if (trialPage == null)
                {
                    trialPage = new TrialPageViewModel();
                }

                return trialPage;
            }
        }

        public static void ClearTrialPageViewModel()
        {
            trialPage = null;
        }
        #endregion
    }
}
