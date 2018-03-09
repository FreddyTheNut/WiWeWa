using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel
{
    public class DatabaseViewModel
    {
        private readonly SQLiteConnection database = new SQLiteConnection(DependencyService.Get<IDependency>().GetLocalFilePath("IHKWiso.db"));

        public List<PruefungViewModel> GetPruefungen()
        {
            return new List<PruefungViewModel>(database.Table<PruefungViewModel>());
        }

        public List<FrageViewModel> GetFragen()
        {
            return new List<FrageViewModel>(database.Table<FrageViewModel>());
        }

        public List<AntwortViewModel> GetAntworten()
        {
            return new List<AntwortViewModel>(database.Table<AntwortViewModel>());
        }
    }
}
