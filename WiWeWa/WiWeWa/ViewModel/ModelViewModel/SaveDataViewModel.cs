using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.Model;
using WiWeWa.Model.Enum;

namespace WiWeWa.ViewModel.ModelViewModel
{
    public class SaveDataViewModel : ViewModelBase
    {
        private SaveData saveData = new SaveData();

        public int Id
        {
            get { return saveData.Id; }
            set
            {
                if (Id != value)
                {
                    saveData.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public FrageStatus Status
        {
            get { return saveData.Status; }
            set
            {
                if (Status != value)
                {
                    saveData.Status = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
