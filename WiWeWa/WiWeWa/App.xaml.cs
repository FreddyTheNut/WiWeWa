using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;

namespace WiWeWa
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            FlowListView.Init();

            MainPage = new NavigationPage(new View.MainPage()) { BarBackgroundColor = (Color)Resources["SecondaryColor"] };

        }

		protected override void OnStart ()
		{
            AppCenter.Start("android=f6500740-46ac-4b23-bb13-c00363434602;" +
                  "uwp=1a1e2890-9172-4e21-bf03-ee56f3bcd9e6;" +
                  "ios=65237137-44c2-4042-be25-9e2a3fdfccba",
                  typeof(Analytics), typeof(Crashes), typeof(Push));
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
