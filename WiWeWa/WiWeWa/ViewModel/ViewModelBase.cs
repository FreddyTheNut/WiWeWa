using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WiWeWa.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        public void NavigatePage(Type viewModel)
        {
            PageController.NavigatePage(viewModel);
        }

        public void NavigateBack()
        {
            PageController.NavigateBack();
        }

        public void Alert(string title, string message)
        {
            PageController.Alert(title, message);
        }

        public async static Task<string> ActionSheetAlert(string title, params string[] actions)
        {
            return await PageController.ActionSheetAlert(title, actions);
        }

        public void AnalyticCenter(string eventbez)
        {
            Analytics.TrackEvent(eventbez);
        }
        
        public void ErrorCenter(Exception exeption)
        {
            Crashes.TrackError(exeption);
        }
    }
}
