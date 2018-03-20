using Microsoft.AppCenter.Push;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<PruefungViewModel> Pruefungen { get; }
        private bool isStartable;
        public bool IsStartable
        {
            get { return isStartable; }
            set
            {
                if (IsStartable != value)
                {
                    isStartable = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isWiederholung;
        public bool IsWiederholung
        {
            get { return isWiederholung; }
            set
            {
                if (IsWiederholung != value)
                {
                    isWiederholung = value;
                    OnPropertyChanged();
                }
            }
        }

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
                return new Command<bool>(answer =>
                {
                    ResetSaveData(answer);
                });
            }
        }

        public MainPageViewModel()
        {
            Pruefungen = new ObservableCollection<PruefungViewModel>(DatabaseViewModel.Instance.Pruefungen);
        }

        private void SelectPruefung(PruefungViewModel pruefung)
        {
            if (!pruefung.IsSelected)
            {
                pruefung.IsSelected = true;
                IsStartable = true;
            }
            else
            {
                pruefung.IsSelected = false;

                if (!Pruefungen.Any(x => x.IsSelected))
                    IsStartable = false;
            }
        }

        private void Start()
        {
            DatabaseViewModel.Instance.IsWiederholung = IsWiederholung;

            if (Pruefungen.Any(x => x.IsSelected))
                NavigatePage(typeof(TrialPageViewModel));
        }

        private void ResetSaveData(bool answer)
        {
            if(answer)
                DatabaseViewModel.Instance.ResetData();
        }
    }
}
