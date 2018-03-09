using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

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
