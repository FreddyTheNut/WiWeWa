using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<PruefungViewModel> Pruefungen { get; }

        private PruefungViewModel selectedPruefung;
        public PruefungViewModel SelectedPruefung
        {
            get { return selectedPruefung; }
            set
            {
                if (SelectedPruefung != value)
                {
                    selectedPruefung = value;
                    OnPropertyChanged();

                    ChoosePruefung();
                }
            }
        }

        public MainPageViewModel()
        {
            DatabaseViewModel.LoadData();
            Pruefungen = new ObservableCollection<PruefungViewModel>(DatabaseViewModel.Pruefungen);
        }

        private void ChoosePruefung()
        {
            //TODO - open Frage
            SelectedPruefung.IsSelected = true;
            NavigatePage(typeof(TrialPageViewModel));
        }
    }
}
