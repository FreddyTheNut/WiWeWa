using System;
using System.Collections.Generic;
using System.Text;

namespace WiWeWa.Model
{
    class Pruefung
    {
        private int id;
        private int jahr;
        private string jahreszeit;
        private string situation;
        private List<Frage> fragen = new List<Frage>();

        public int Id { get => id; set => id = value; }
        public int Jahr { get => jahr; set => jahr = value; }
        public string Jahreszeit { get => jahreszeit; set => jahreszeit = value; }
        public string Situation { get => situation; set => situation = value; }
        private List<Frage> Fragen { get => fragen; set => fragen = value; }
    }
}
