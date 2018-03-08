using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel
{
    class DatabaseViewModel
    {
        string path = DependencyService.Get<IDependency>().GetLocalFilePath("Datenbank.sql");

        public List<PruefungViewModel> GetAllPruefungen()
        {
            //TODO - read from Database
            return new List<PruefungViewModel>();
        }
    }
}
