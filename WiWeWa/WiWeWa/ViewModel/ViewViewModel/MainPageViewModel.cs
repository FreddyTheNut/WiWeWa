using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<PruefungViewModel> Pruefungen { get; }

        public Command SelectPruefung_Command
        {
            get
            {
                return new Command<PruefungViewModel>(pruefung =>
                {
                    SelectPruefung(pruefung);
                });
            }
        }
        public Command Start_Command
        {
            get
            {
                return new Command(_ =>
                {
                    Start();
                });
            }
        }

        public Command Reset_Command
        {
            get
            {
                return new Command(_ =>
                {
                    ResetSaveData();
                });
            }
        }

        public MainPageViewModel()
        {
            Pruefungen = new ObservableCollection<PruefungViewModel>(DatabaseViewModel.Instance.Pruefungen);
        }

        private void SelectPruefung(PruefungViewModel pruefung)
        {
            if(!pruefung.IsSelected)
                pruefung.IsSelected = true;
            else
                pruefung.IsSelected = false;
        }

        private void Start()
        {
            if(Pruefungen.Any(x => x.IsSelected))
                NavigatePage(typeof(TrialPageViewModel));
        }

        private void ResetSaveData()
        {
            DatabaseViewModel.Instance.ResetData();
        }
    }
}
