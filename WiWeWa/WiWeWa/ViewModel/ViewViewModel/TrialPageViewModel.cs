using System.Collections.ObjectModel;
using WiWeWa.ViewModel.ModelViewModel;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class TrialPageViewModel : ViewModelBase
    {
        public ObservableCollection<PruefungViewModel> Pruefungen { get; } = new ObservableCollection<PruefungViewModel>(DatabaseViewModel.Pruefungen);

    }
}
