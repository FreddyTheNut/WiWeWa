using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.Model;
using WiWeWa.Model.Enum;
using WiWeWa.ViewModel.Helper;

namespace WiWeWa.ViewModel.ModelViewModel
{
    class FrageViewModel : NotifyPropertyChanged
    {
        private Frage frage = new Frage();

        public int Id
        {
            get { return frage.Id; }
            set
            {
                if (Id != value)
                {
                    frage.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public int PruefungNR
        {
            get { return frage.PruefungNR; }
            set
            {
                if (PruefungNR != value)
                {
                    frage.PruefungNR = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Aufgabe
        {
            get { return frage.Aufgabe; }
            set
            {
                if (Aufgabe != value)
                {
                    frage.Aufgabe = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FrageText
        {
            get { return frage.FrageText; }
            set
            {
                if (FrageText != value)
                {
                    frage.FrageText = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ZusatzText
        {
            get { return frage.ZusatzText; }
            set
            {
                if (ZusatzText != value)
                {
                    frage.ZusatzText = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Antwortmoeglichkeiten
        {
            get { return frage.Antwortmoeglichkeiten; }
            set
            {
                if (Antwortmoeglichkeiten != value)
                {
                    frage.Antwortmoeglichkeiten = value;
                    OnPropertyChanged();
                }
            }
        }
        public int RichtigeAnzahl
        {
            get { return frage.RichtigeAnzahl; }
            set
            {
                if (RichtigeAnzahl != value)
                {
                    frage.RichtigeAnzahl = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Wiederholung
        {
            get { return frage.Wiederholung; }
            set
            {
                if (Wiederholung != value)
                {
                    frage.Wiederholung = value;
                    OnPropertyChanged();
                }
            }
        }
        public FrageStatus Status
        {
            get { return frage.Status; }
            set
            {
                if (Status != value)
                {
                    frage.Status = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
