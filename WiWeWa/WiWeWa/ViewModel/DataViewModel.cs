using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.ViewModel.ModelViewModel;

namespace WiWeWa.ViewModel
{
    public sealed class DataViewModel
    {
        public static List<PruefungViewModel> Pruefungen { get; } = new List<PruefungViewModel>();

        public static void SetPruefungen(List<PruefungViewModel> pruefungen)
        {
            Pruefungen.Clear();
            pruefungen.ForEach(x => Pruefungen.Add(x));
        }
    }
}
