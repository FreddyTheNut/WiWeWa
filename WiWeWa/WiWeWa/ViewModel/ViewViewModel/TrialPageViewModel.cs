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
        #region Variablen
        public ObservableCollection<FrageViewModel> Fragen { get; private set; }

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

        private bool aufloesung;
        public bool Aufloesung
        {
            get { return aufloesung; }
            set
            {
                if (Aufloesung != value)
                {
                    aufloesung = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isSolvable;
        public bool IsSolvable
        {
            get { return isSolvable; }
            set
            {
                if (IsSolvable != value)
                {
                    isSolvable = value;
                    OnPropertyChanged();
                }
            }
        }

        private int canSelectCounter;
        public int CanSelectCounter
        {
            get { return canSelectCounter; }
            set
            {
                if (CanSelectCounter != value)
                {
                    canSelectCounter = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Commands
        public Command Next_Command
        {
            get
            {
                return new Command(_ =>
                {
                    NextQuestion();
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
        #endregion

        #region Constructer
        public TrialPageViewModel()
        {
            Fragen = new ObservableCollection<FrageViewModel>(DatabaseViewModel.GetSelectedFragen());

            Aufloesung = true;
            IsSolvable = false;

            NextQuestion();
        }
        #endregion

        #region Methods
        private void SelectAnswer(AntwortViewModel antwort)
        {
            if (Aufloesung)
            {
                if (antwort != null)
                {
                    if (antwort.Status == AntwortStatus.NotSelected)
                        antwort.Status = AntwortStatus.Selected;
                    else
                        antwort.Status = AntwortStatus.NotSelected;

                    SetIsSolveabel();
                    SetCanSelectCounter();
                }
            }
        }

        private void SetIsSolveabel()
        {
            IsSolvable = Frage.Antworten.Where(x => x.Status == AntwortStatus.Selected).ToList().Count() == Frage.RichtigeAnzahl;
        }

        private void SetCanSelectCounter()
        {
            CanSelectCounter = Frage.RichtigeAnzahl - Frage.Antworten.Where(x => x.Status == AntwortStatus.Selected).Count();
        }

        private void NextQuestion()
        {
            if (Frage != null)
            {
                if (Aufloesung)
                {
                    List<AntwortViewModel> selectedAntworten = Frage.Antworten.Where(x => x.Status == AntwortStatus.Selected).ToList();

                    if (selectedAntworten.Count() == Frage.RichtigeAnzahl)
                    {
                        selectedAntworten.ForEach(x => { if (x.Richtig) x.Status = AntwortStatus.Right; else x.Status = AntwortStatus.Wrong; });

                        if (selectedAntworten.TrueForAll(x => x.Status == AntwortStatus.Right))
                            //TODO - Status.Bearbeitung
                            Frage.Status = FrageStatus.Richtig;
                        else
                            Frage.Status = FrageStatus.Falsch;

                        Aufloesung = false;

                        Frage.Antworten.Where(x => x.Richtig).ToList().ForEach(x => x.Status = AntwortStatus.Right);
                    }
                }
                else
                {
                    Frage.Antworten.ToList().ForEach(x => x.Status = AntwortStatus.NotSelected);
                    List<FrageViewModel> zubearbeitendeFragen = Fragen.Where(x => x.Status != FrageStatus.Richtig && x != Frage).ToList();

                    Frage = zubearbeitendeFragen[new Random().Next(0, zubearbeitendeFragen.Count)];

                    Aufloesung = true;

                    SetIsSolveabel();
                    SetCanSelectCounter();
                }
            }
            else
            {
                Frage = Fragen[new Random().Next(0, Fragen.Count)];

                SetIsSolveabel();
                SetCanSelectCounter();
            }
        }
        #endregion
    }
}
