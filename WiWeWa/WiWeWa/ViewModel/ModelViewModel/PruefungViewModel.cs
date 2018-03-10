using SQLite;
using System.Collections.ObjectModel;
using WiWeWa.Model;

namespace WiWeWa.ViewModel.ModelViewModel
{
    [Table ("Pruefung")]
    public class PruefungViewModel : ViewModelBase
    {
        private Pruefung pruefung = new Pruefung();

        public int Id
        {
            get { return pruefung.Id; }
            set
            {
                if (Id != value)
                {
                    pruefung.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Jahr
        {
            get { return pruefung.Jahr; }
            set
            {
                if (Jahr != value)
                {
                    pruefung.Jahr = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Jahreszeit
        {
            get { return pruefung.Jahreszeit; }
            set
            {
                if (Jahreszeit != value)
                {
                    pruefung.Jahreszeit = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Situation
        {
            get { return pruefung.Situation; }
            set
            {
                if (Situation != value)
                {
                    pruefung.Situation = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<FrageViewModel> Fragen { get; } = new ObservableCollection<FrageViewModel>();

        public string Bezeichnung
        {
            get
            {
                return $"Prüfung {Jahreszeit} {Jahr}";
            }
        }
    }
}
