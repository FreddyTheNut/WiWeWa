using SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using WiWeWa.Model;
using WiWeWa.Model.Enum;

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
        public bool IsSelected
        {
            get { return pruefung.IsSelected; }
            set
            {
                if (IsSelected != value)
                {
                    pruefung.IsSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<FrageViewModel> Fragen { get; } = new ObservableCollection<FrageViewModel>();

        public string Bezeichnung
        {
            get
            {
                return $"Prüfung {Jahreszeit} {Jahr} - {Fragen.Count(x => x.Status == FrageStatus.Richtig)}/{Fragen.Count}";
            }
        }

        public PruefungViewModel()
        {
            Fragen.CollectionChanged += Fragen_CollectionChanged;
        }

        private void Fragen_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Fragen.Last().PropertyChanged += PruefungViewModel_PropertyChanged;
        }

        private void PruefungViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Status"))
            {
                OnPropertyChanged(nameof(Bezeichnung));
            }
        }
    }
}
