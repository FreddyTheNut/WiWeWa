using SQLite;
using WiWeWa.Model;
using WiWeWa.Model.Enum;

namespace WiWeWa.ViewModel.ModelViewModel
{
    [Table("Antwort")]
    public class AntwortViewModel : ViewModelBase
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
        public AntwortStatus Status
        {
            get { return antwort.Status; }
            set
            {
                if (Status != value)
                {
                    antwort.Status = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
