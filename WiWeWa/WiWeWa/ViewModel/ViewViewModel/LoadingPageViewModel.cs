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
            string path = DependencyService.Get<IDependency>().GetLocalFilePath("Datenbank.sql");
        }
    }
}
