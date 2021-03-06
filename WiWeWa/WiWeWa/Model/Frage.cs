﻿using WiWeWa.Model.Enum;

namespace WiWeWa.Model
{
    public class Frage
    {
        private int id;
        private int pruefungNr;
        private int aufgabe;
        private string frageText;
        private string zusatzText;
        private int antwortmoeglichkeiten;
        private int richtigeAnzahl;
        private int wiederholung = 0;
        private FrageStatus status;

        public int Id { get => id; set => id = value; }
        public int PruefungNr { get => pruefungNr; set => pruefungNr = value; }
        public int Aufgabe { get => aufgabe; set => aufgabe = value; }
        public string FrageText { get => frageText; set => frageText = value; }
        public string ZusatzText { get => zusatzText; set => zusatzText = value; }
        public int Antwortmoeglichkeiten { get => antwortmoeglichkeiten; set => antwortmoeglichkeiten = value; }
        public int RichtigeAnzahl { get => richtigeAnzahl; set => richtigeAnzahl = value; }
        public int Wiederholung { get => wiederholung; set => wiederholung = value; }
        public FrageStatus Status { get => status; set => status = value; }
    }
}
