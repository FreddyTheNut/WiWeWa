using System;
using System.Collections.ObjectModel;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel.ViewViewModel
{
    public class TrialPageViewModel : ViewModelBase
    {
        public ObservableCollection<FrageViewModel> Fragen { get; } = new ObservableCollection<FrageViewModel>(DatabaseViewModel.GetSelectedFragen());

        private FrageViewModel frage;
        public FrageViewModel Frage
        {
            get { return frage; }
            set
            {
                if (Frage != value)
                {
                    frage = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command Next_Command
        {
            get
            {
                return new Command(_ =>
                {
                    RandomQuestion();
                });
            }
        }

        public TrialPageViewModel()
        {
            RandomQuestion();
        }

        private void RandomQuestion()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, Fragen.Count);

            Frage = Fragen[i];
        }
    }
}
