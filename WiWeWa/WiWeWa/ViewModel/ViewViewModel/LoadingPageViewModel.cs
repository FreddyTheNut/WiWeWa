using System;
using System.Threading.Tasks;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class LoadingPageViewModel : ViewModelBase
    {
        public LoadingPageViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            DatabaseViewModel.LoadData();

            Task.Delay(TimeSpan.FromSeconds(2)).ContinueWith(_ =>
            {
                OpenPage(typeof(TrialPageViewModel));
            });
        }
    }
}
