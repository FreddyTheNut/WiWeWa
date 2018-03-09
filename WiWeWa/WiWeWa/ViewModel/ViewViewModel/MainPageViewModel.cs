using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            string path = DependencyService.Get<IDependency>().GetLocalFilePath("Datenbank.sql");
        }
    }
}
