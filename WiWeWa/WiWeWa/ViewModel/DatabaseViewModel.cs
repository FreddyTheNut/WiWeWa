using SQLite;
using System.Collections.Generic;
using System.Linq;
using WiWeWa.Model.Enum;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel
{
    public class DatabaseViewModel
    {
        private static DatabaseViewModel instance;
        public static DatabaseViewModel Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DatabaseViewModel();
                }

                return instance;
            }
        }

        private readonly SQLiteConnection wisoDatabase = new SQLiteConnection(DependencyService.Get<IDependency>().GetWisoDataBasePath());
        private readonly SQLiteConnection saveDatabase = new SQLiteConnection(DependencyService.Get<IDependency>().GetSaveDatabasePath());

        public List<PruefungViewModel> Pruefungen { get; } = new List<PruefungViewModel>();
        public bool IsWiederholung { get; set; }


        public DatabaseViewModel()
        {
            LoadData();
            LoadAllFrageStatus();

            Pruefungen.SelectMany(x => x.Fragen).ToList().ForEach(x => x.PropertyChanged += Frage_PropertyChanged);
        }


        public List<FrageViewModel> GetSelectedFragen()
        {
            return Pruefungen.Where(x => x.IsSelected).SelectMany(x => x.Fragen).ToList();
        }

        private void LoadData()
        {
            List<PruefungViewModel> pruefungen = wisoDatabase.Table<PruefungViewModel>().ToList();
            List<FrageViewModel> fragen = wisoDatabase.Table<FrageViewModel>().ToList();
            List<AntwortViewModel> antworten = wisoDatabase.Table<AntwortViewModel>().ToList();

            pruefungen.ForEach(p => fragen.FindAll(f => p.Id == f.PruefungNr).ForEach(f => p.Fragen.Add(f)));
            pruefungen.ForEach(p => p.Fragen.ToList().ForEach(f => antworten.FindAll(a => f.Id == a.FrageNr).ForEach(a => f.Antworten.Add(a))));

            if (Pruefungen.Any())
                Pruefungen.Clear();

            Pruefungen.AddRange(pruefungen);
        }

        private void SaveFrageStatus(FrageViewModel frage)
        {
            saveDatabase.InsertOrReplace(new SaveDataViewModel { Id = frage.Id, Status = frage.Status });
        }

        private void LoadAllFrageStatus()
        {
            saveDatabase.CreateTable<SaveDataViewModel>();

            List<SaveDataViewModel> saveData = saveDatabase.Table<SaveDataViewModel>().ToList();

            foreach( SaveDataViewModel save in saveData)
            {
                Pruefungen.SelectMany(x => x.Fragen).ToList().FirstOrDefault(x => x.Id == save.Id).Status = save.Status;
            }
        }

        public void ResetAllData()
        {
            saveDatabase.DeleteAll<SaveDataViewModel>();
            Pruefungen.SelectMany(x => x.Fragen).ToList().ForEach(x => { x.Status = FrageStatus.Unbearbeitet; x.Antworten.ToList().ForEach(y => y.Status = AntwortStatus.NotSelected); });
        }

        public void ResetPruefungData(PruefungViewModel pruefung)
        {
            foreach(SaveDataViewModel save in saveDatabase.Table<SaveDataViewModel>().ToList())
            {
                if(pruefung.Fragen.Any(x => x.Id == save.Id))
                {
                    saveDatabase.Delete<SaveDataViewModel>(save.Id);
                }
            }

            pruefung.Fragen.ToList().ForEach(x => { x.Status = FrageStatus.Unbearbeitet; x.Antworten.ToList().ForEach(y => y.Status = AntwortStatus.NotSelected); });
        }


        private void Frage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Status"))
                SaveFrageStatus((FrageViewModel)sender);
        }
    }
}
