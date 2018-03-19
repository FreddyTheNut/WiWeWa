using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WiWeWa.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrialPage : ContentPage
	{
		public TrialPage ()
		{
			InitializeComponent ();

            //Workaround Xamarin Bug (https://bugzilla.xamarin.com/show_bug.cgi?id=32899)
            nextButton.IsEnabled = false;
            nextButton.SetBinding(Button.IsEnabledProperty, new Binding("IsSolvable"));
        }
	}
}