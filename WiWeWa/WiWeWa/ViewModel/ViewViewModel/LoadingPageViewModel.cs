using System;
using System.Collections.Generic;
using System.Text;
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
            List<PruefungViewModel> liste = new DatabaseViewModel().GetPruefungen();
        }

        private void Continue()
        {
            PageController.OpenPage(typeof(TrialPageViewModel));
        }

        public Command ButtonContinue_Clicked
        {
            get
            {
                return new Command(() =>
                {
                    Continue();
                });
            }
        }
    }
}
