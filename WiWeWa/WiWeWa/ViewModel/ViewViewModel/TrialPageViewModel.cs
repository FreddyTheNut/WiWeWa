using System.Collections.ObjectModel;
using WiWeWa.ViewModel.ModelViewModel;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class TrialPageViewModel : ViewModelBase
    {
        ObservableCollection<PruefungViewModel> pruefungen = new ObservableCollection<PruefungViewModel>(DatabaseViewModel.Pruefungen);
    }
}
