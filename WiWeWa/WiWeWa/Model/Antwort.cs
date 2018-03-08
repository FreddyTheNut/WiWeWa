using System;
using System.Collections.Generic;
using System.Text;

namespace WiWeWa.Model
{
    class Antwort
    {
        private int id;
        private int frageNR;
        private string antwortText;
        private bool richtig;

        public int Id { get => id; set => id = value; }
        public int FrageNR { get => frageNR; set => frageNR = value; }
        public string AntwortText { get => antwortText; set => antwortText = value; }
        public bool Richtig { get => richtig; set => richtig = value; }
    }
}
