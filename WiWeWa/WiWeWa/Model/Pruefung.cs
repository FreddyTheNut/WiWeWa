﻿namespace WiWeWa.Model
{
    class Pruefung
    {
        private int id;
        private int jahr;
        private string jahreszeit;
        private string situation;
        private bool isSelected;

        public int Id { get => id; set => id = value; }
        public int Jahr { get => jahr; set => jahr = value; }
        public string Jahreszeit { get => jahreszeit; set => jahreszeit = value; }
        public bool IsSelected { get => isSelected; set => isSelected = value; }
        public string Situation { get => situation; set => situation = value; }
    }
}
