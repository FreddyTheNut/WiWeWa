using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WiWeWa.Model.Enum;
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

        private bool aufloesung = true;
        public bool Aufloesung
        {
            get { return aufloesung; }
            set
            {
                if(Aufloesung != value)
                {
                    aufloesung = value;
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
        public Command SelectAnswer_Command
        {
            get
            {
                return new Command<AntwortViewModel>(antwort =>
                {
                    SelectAnswer(antwort);
                });
            }
        }

        private void SelectAnswer(AntwortViewModel antwort)
        {
            if(antwort != null)
            {
                if (antwort.Status == AntwortStatus.NotSelected)
                    antwort.Status = AntwortStatus.Selected;
                else
                    antwort.Status = AntwortStatus.NotSelected;
            }
        }

        public TrialPageViewModel()
        {
            RandomQuestion();
        }

        private void RandomQuestion()
        {
            if(Frage != null)
            {
                if (Aufloesung)
                {
                    List<AntwortViewModel> selectedAntworten = Frage.Antworten.Where(x => x.Status == AntwortStatus.Selected).ToList(); ;

                    if (selectedAntworten.Any())
                    {
                        selectedAntworten.ForEach(x => { if (x.Richtig) x.Status = AntwortStatus.Right; else x.Status = AntwortStatus.Wrong; });

                        if (selectedAntworten.TrueForAll(x => x.Status == AntwortStatus.Right))
                            //TODO - Status.Bearbeitung
                            Frage.Status = FrageStatus.Richtig;
                        else
                            Frage.Status = FrageStatus.Falsch;

                        Aufloesung = false;
                    }
                }
                else
                {
                    Frage.Antworten.ToList().ForEach(x => x.Status = AntwortStatus.NotSelected);
                    List<FrageViewModel> zubearbeitendeFragen = Fragen.Where(x => x.Status != FrageStatus.Richtig && x != Frage).ToList();

                    Frage = zubearbeitendeFragen[new Random().Next(0, zubearbeitendeFragen.Count)];

                    Aufloesung = true;
                }
            }
            else
            {
                Frage = Fragen[new Random().Next(0, Fragen.Count)];
            }
        }
    }
}
