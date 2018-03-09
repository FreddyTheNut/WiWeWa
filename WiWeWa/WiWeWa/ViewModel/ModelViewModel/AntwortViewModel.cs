using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.Model;
using WiWeWa.ViewModel.Helper;

namespace WiWeWa.ViewModel.ModelViewModel
{
    [Table("Antwort")]
    public class AntwortViewModel : NotifyPropertyChanged
    {
        private Antwort antwort = new Antwort();

        public int Id
        {
            get { return antwort.Id; }
            set
            {
                if (Id != value)
                {
                    antwort.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public int FrageNr
        {
            get { return antwort.FrageNr; }
            set
            {
                if (FrageNr != value)
                {
                    antwort.FrageNr = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AntwortText
        {
            get { return antwort.AntwortText; }
            set
            {
                if (AntwortText != value)
                {
                    antwort.AntwortText = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Richtig
        {
            get { return antwort.Richtig; }
            set
            {
                if (Richtig != value)
                {
                    antwort.Richtig = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
