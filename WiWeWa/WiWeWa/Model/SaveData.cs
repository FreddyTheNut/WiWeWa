using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.Model.Enum;

namespace WiWeWa.Model
{
    public class SaveData
    {
        private int id;
        private FrageStatus status;

        public int Id { get => id; set => id = value; }
        public FrageStatus Status { get => status; set => status = value; }
    }
}
