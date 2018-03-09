using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WiWeWa.ViewModel.ModelViewModel;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class TrialPageViewModel : ViewModelBase
    {
        ObservableCollection<PruefungViewModel> pruefungen = new ObservableCollection<PruefungViewModel>(DatabaseViewModel.Pruefungen);
    }
}
