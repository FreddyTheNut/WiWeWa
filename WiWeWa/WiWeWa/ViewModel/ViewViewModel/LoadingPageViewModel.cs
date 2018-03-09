using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class LoadingPageViewModel
    {
        public LoadingPageViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            DatabaseViewModel.LoadData();

            Task.Delay(TimeSpan.FromSeconds(3)).ContinueWith(_ =>
            {
                PageController.OpenPage(typeof(TrialPageViewModel));
            });
        }
    }
}
