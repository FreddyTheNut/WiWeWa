using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WiWeWa.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        public void OpenPage(Type viewModel)
        {
            PageController.OpenPage(viewModel, GetType());
        }

        public void NavigatePage(Type viewModel)
        {
            PageController.NavigatePage(viewModel);
        }
    }
}
