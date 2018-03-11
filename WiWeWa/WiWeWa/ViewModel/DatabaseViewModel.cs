using SQLite;
using System.Collections.Generic;
using System.Linq;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel
{
    public sealed class DatabaseViewModel
    {
        public static List<PruefungViewModel> Pruefungen { get; } = new List<PruefungViewModel>();

        private static readonly SQLiteConnection database = new SQLiteConnection(DependencyService.Get<IDependency>().GetLocalFilePath("IHKWiso.db"));

        public static void LoadData()
        {
            List<PruefungViewModel> pruefungen = GetPruefungen();
            List<FrageViewModel> fragen = GetFragen();
            List<AntwortViewModel> antworten = GetAntworten();

            pruefungen.ForEach(p => fragen.FindAll(f => p.Id == f.PruefungNr).ForEach(f => p.Fragen.Add(f)));
            pruefungen.ForEach(p => p.Fragen.ToList().ForEach(f => antworten.FindAll(a => f.Id == a.FrageNr).ForEach(a => f.Antworten.Add(a))));

            SetPruefungen(pruefungen);
        }

        public static List<FrageViewModel> GetSelectedFragen()
        {
            return Pruefungen.Where(x => x.IsSelected).SelectMany(x => x.Fragen).ToList();
        }

        private static void SetPruefungen(List<PruefungViewModel> pruefungen)
        {
            Pruefungen.Clear();
            Pruefungen.AddRange(pruefungen);
         }

        private static List<PruefungViewModel> GetPruefungen()
        {
            return new List<PruefungViewModel>(database.Table<PruefungViewModel>());
        }

        private static List<FrageViewModel> GetFragen()
        {
            return new List<FrageViewModel>(database.Table<FrageViewModel>());
        }

        private static List<AntwortViewModel> GetAntworten()
        {
            return new List<AntwortViewModel>(database.Table<AntwortViewModel>());
        }
    }
}
