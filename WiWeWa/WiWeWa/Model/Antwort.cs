﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WiWeWa.Model
{
    public class Antwort
    {
        private int id;
        private int frageNr;
        private string antwortText;
        private bool richtig;

        public int Id { get => id; set => id = value; }
        public int FrageNr { get => frageNr; set => frageNr = value; }
        public string AntwortText { get => antwortText; set => antwortText = value; }
        public bool Richtig { get => richtig; set => richtig = value; }
    }
}
