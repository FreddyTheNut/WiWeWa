using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WiWeWa.View.Converter
{
    public class BoolToSelectedColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                bool isSelected = (bool)value;

                if (isSelected)
                {
                    return App.Current.Resources["SecondaryColor"];
                }

                return App.Current.Resources["PrimaryColor"];
            }

            return App.Current.Resources["PrimaryColor"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }
    }
}
