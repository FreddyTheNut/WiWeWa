using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiWeWa.Model.Enum;
using WiWeWa.ViewModel.ModelViewModel;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class ProgressViewModel : ViewModelBase
    {
        private ObservableCollection<FrageViewModel> Fragen = new ObservableCollection<FrageViewModel>(DatabaseViewModel.GetSelectedFragen());

        private int unbearbeitetCount = 1;
        private int bearbeitetCount = 0;
        private int richtigCount = 0;
        private int falschCount = 0;

        public int UnbearbeitetCount
        {
            get { return unbearbeitetCount; }
            set
            {
                if(UnbearbeitetCount != value)
                {
                    unbearbeitetCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public int BearbeitetCount
        {
            get { return bearbeitetCount; }
            set
            {
                if (BearbeitetCount != value)
                {
                    bearbeitetCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public int RichtigCount
        {
            get { return richtigCount; }
            set
            {
                if (RichtigCount != value)
                {
                    richtigCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public int FalschCount
        {
            get { return falschCount; }
            set
            {
                if (FalschCount != value)
                {
                    falschCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public ProgressViewModel()
        {
            Fragen.ToList().ForEach(x => x.PropertyChanged += Frage_PropertyChanged);

            UpdateStatus();
        }

        private void Frage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Status"))
                UpdateStatus();
        }

        private void UpdateStatus()
        {
            UnbearbeitetCount = Fragen.Count(x => x.Status == FrageStatus.Unbearbeitet);
            BearbeitetCount = Fragen.Count(x => x.Status == FrageStatus.Bearbeitet);
            RichtigCount = Fragen.Count(x => x.Status == FrageStatus.Richtig);
            FalschCount = Fragen.Count(x => x.Status == FrageStatus.Falsch);
        }
    }
}
