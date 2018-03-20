using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        private bool isSolvable = true;
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

        private Color buttonColor = (Color)App.Current.Resources["PrimaryColor"];
        public Color ButtonColor
        {
            get { return buttonColor; }
            set
            {
                if (ButtonColor != value)
                {
                    buttonColor = value;
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
            Fragen = new ObservableCollection<FrageViewModel>(DatabaseViewModel.Instance.GetSelectedFragen());

            Aufloesung = true;

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
            else
                NextQuestion();
        }

        private void SetIsSolveabel()
        {
            IsSolvable = Frage.Antworten.Where(x => x.Status == AntwortStatus.Selected).ToList().Count() == Frage.RichtigeAnzahl;

            if(IsSolvable)
                ButtonColor = (Color)App.Current.Resources["SecondaryColor"];
            else
                ButtonColor = (Color)App.Current.Resources["PrimaryColor"];
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
                        {
                            ButtonColor = (Color)App.Current.Resources["RightColor"];

                            if (DatabaseViewModel.Instance.IsWiederholung)
                                if (Frage.Status != FrageStatus.Bearbeitet)
                                    Frage.Status = FrageStatus.Bearbeitet;
                                else
                                    Frage.Status = FrageStatus.Richtig;
                            else
                                Frage.Status = FrageStatus.Richtig;
                        }
                        else
                        {
                            ButtonColor = (Color)App.Current.Resources["WrongColor"];

                            Frage.Status = FrageStatus.Falsch;
                        }

                        Aufloesung = false;

                        Frage.Antworten.Where(x => x.Richtig).ToList().ForEach(x => x.Status = AntwortStatus.Right);
                    }
                }
                else
                {
                    Frage.Antworten.ToList().ForEach(x => x.Status = AntwortStatus.NotSelected);
                    List<FrageViewModel> zubearbeitendeFragen = Fragen.Where(x => x.Status != FrageStatus.Richtig).ToList();

                    if(zubearbeitendeFragen.Any())
                    {
                        FrageViewModel frageTemp = zubearbeitendeFragen[new Random().Next(0, zubearbeitendeFragen.Count)];
                        List<AntwortViewModel> antwortenTemp = frageTemp.Antworten.ToList();
                        frageTemp.Antworten.Clear();

                        foreach(AntwortViewModel antwortTemp in RandomizeAntworten(antwortenTemp))
                        {
                            frageTemp.Antworten.Add(antwortTemp);
                        }
                        
                        Frage = frageTemp;

                        Aufloesung = true;

                        SetIsSolveabel();
                        SetCanSelectCounter();
                    }
                    else
                    {
                        Beenden();
                    }
                 
                }
            }
            else
            {
                Frage = Fragen[new Random().Next(0, Fragen.Count)];

                SetIsSolveabel();
                SetCanSelectCounter();
            }
        }

        private List<AntwortViewModel> RandomizeAntworten(List<AntwortViewModel> tempAntworten)
        {
            Random rnd = new Random();

            for (int i = 0; i < tempAntworten.Count; i++)
            {
                AntwortViewModel temp = tempAntworten[i];
                int randomIndex = rnd.Next(i, tempAntworten.Count);
                tempAntworten[i] = tempAntworten[randomIndex];
                tempAntworten[randomIndex] = temp;
            }

            return tempAntworten;
        }

        private void Beenden()
        {
            Alert("Glückwunsch!", "Alle ausgewählten Prüfungen beendet.");
            NavigateBack();
        }
        #endregion
    }
}
