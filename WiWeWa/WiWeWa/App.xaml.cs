using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Distribute;
using Xamarin.Forms;
using System.Threading.Tasks;

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
            Distribute.ReleaseAvailable = OnReleaseAvailable;

            AppCenter.Start("android=f6500740-46ac-4b23-bb13-c00363434602;" +
                  "uwp=1a1e2890-9172-4e21-bf03-ee56f3bcd9e6;" +
                  "ios=65237137-44c2-4042-be25-9e2a3fdfccba",
                  typeof(Analytics), typeof(Crashes), typeof(Push), typeof(Distribute));
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

        bool OnReleaseAvailable(ReleaseDetails releaseDetails)
        {
            // Look at releaseDetails public properties to get version information, release notes text or release notes URL
            string versionName = releaseDetails.ShortVersion;
            string versionCodeOrBuildNumber = releaseDetails.Version;
            string releaseNotes = releaseDetails.ReleaseNotes;
            Uri releaseNotesUrl = releaseDetails.ReleaseNotesUrl;

            // custom dialog
            var title = "Version " + versionName + " available!";
            Task answer;

            // On mandatory update, user cannot postpone
            if (releaseDetails.MandatoryUpdate)
            {
                answer = Current.MainPage.DisplayAlert(title, releaseNotes, "Download and Install");
            }
            else
            {
                answer = Current.MainPage.DisplayAlert(title, releaseNotes, "Download and Install", "Maybe tomorrow...");
            }
            answer.ContinueWith((task) =>
            {
                // If mandatory or if answer was positive
                if (releaseDetails.MandatoryUpdate || (task as Task<bool>).Result)
                {
                    // Notify SDK that user selected update
                    Distribute.NotifyUpdateAction(UpdateAction.Update);
                }
                else
                {
                    // Notify SDK that user selected postpone (for 1 day)
                    // Note that this method call is ignored by the SDK if the update is mandatory
                    Distribute.NotifyUpdateAction(UpdateAction.Postpone);
                }
            });

            // Return true if you are using your own dialog, false otherwise
            return true;
        }
    }
}
