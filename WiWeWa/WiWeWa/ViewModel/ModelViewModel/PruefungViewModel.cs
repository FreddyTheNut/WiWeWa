using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.Model;
using WiWeWa.ViewModel.Helper;

namespace WiWeWa.ViewModel.ModelViewModel
{
    public class PruefungViewModel : NotifyPropertyChanged
    {
        private Pruefung pruefung = new Pruefung();

        public int Id
        {
            get { return pruefung.Id; }
            set
            {
                if (Id != value)
                {
                    pruefung.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Jahr
        {
            get { return pruefung.Jahr; }
            set
            {
                if (Jahr != value)
                {
                    pruefung.Jahr = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Jahreszeit
        {
            get { return pruefung.Jahreszeit; }
            set
            {
                if (Jahreszeit != value)
                {
                    pruefung.Jahreszeit = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Situation
        {
            get { return pruefung.Situation; }
            set
            {
                if (Situation != value)
                {
                    pruefung.Situation = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<Frage> Fragen { get => pruefung.Fragen; set => pruefung.Fragen = value; }
    }
}
