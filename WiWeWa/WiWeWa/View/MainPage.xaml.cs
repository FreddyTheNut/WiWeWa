﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiWeWa.ViewModel.ViewViewModel;
using Xamarin.Forms;

namespace WiWeWa.View
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            //Workaround Xamarin Bug (https://bugzilla.xamarin.com/show_bug.cgi?id=32899)
            startButton.SetBinding(Button.IsEnabledProperty, new Binding("IsStartable"));
        }
    }
}
