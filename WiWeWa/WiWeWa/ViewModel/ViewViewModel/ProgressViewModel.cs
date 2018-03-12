using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WiWeWa.Model.Enum;
using WiWeWa.ViewModel.ModelViewModel;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class ProgressViewModel
    {
        public ObservableCollection<FrageViewModel> Fragen { get; } = new ObservableCollection<FrageViewModel>(DatabaseViewModel.GetSelectedFragen());

        public Dictionary<FrageStatus, int> Progress = new Dictionary<FrageStatus, int>()
        {
            { FrageStatus.Unbearbeitet, 0 },
            { FrageStatus.Bearbeitet, 0 },
            { FrageStatus.Richtig, 1 },
            { FrageStatus.Falsch, 0 }
        };

        private void UpdateStatus()
        {
            Progress[FrageStatus.Unbearbeitet] = Fragen.Count(x => x.Status == FrageStatus.Unbearbeitet);
            Progress[FrageStatus.Bearbeitet] = Fragen.Count(x => x.Status == FrageStatus.Bearbeitet);
            Progress[FrageStatus.Richtig] = Fragen.Count(x => x.Status == FrageStatus.Richtig);
            Progress[FrageStatus.Falsch] = Fragen.Count(x => x.Status == FrageStatus.Falsch);
        }

    }
}
