using WiWeWa.Model.Enum;

namespace WiWeWa.Model
{
    public class Antwort
    {
        private int id;
        private int frageNr;
        private string antwortText;
        private bool richtig;
        private AntwortStatus status;

        public int Id { get => id; set => id = value; }
        public int FrageNr { get => frageNr; set => frageNr = value; }
        public string AntwortText { get => antwortText; set => antwortText = value; }
        public bool Richtig { get => richtig; set => richtig = value; }
        public AntwortStatus Status { get => status; set => status = value; }
    }
}
