using System;
using System.Collections.Generic;
using System.Text;
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
            DataViewModel.SetPruefungen(new DatabaseViewModel().GetAllPruefungen());
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
