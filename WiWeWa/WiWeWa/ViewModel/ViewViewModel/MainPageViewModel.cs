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

        public MainPageViewModel()
        {
            DatabaseViewModel.LoadData();
            Pruefungen = new ObservableCollection<PruefungViewModel>(DatabaseViewModel.Pruefungen);
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
            NavigatePage(typeof(TrialPageViewModel));
        }
    }
}
