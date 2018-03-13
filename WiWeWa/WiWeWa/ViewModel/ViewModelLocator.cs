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

        //Temporary not static!
        #region TrialPageViewModel
        private static TrialPageViewModel trialPage;

        public TrialPageViewModel TrialPage
        {
            get
            {
                return new TrialPageViewModel();
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

        //Temporary not static!
        #region ProgressViewModel
        private static ProgressViewModel progressView;

        public ProgressViewModel ProgressView
        {
            get
            {
                return new ProgressViewModel();
            }
        }

        public static ProgressViewModel ProgressViewStatic
        {
            get
            {
                if (progressView == null)
                {
                    progressView = new ProgressViewModel();
                }

                return progressView;
            }
        }

        public static void ClearProgressViewStatic()
        {
            progressView = null;
        }
        #endregion
    }
}
