using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WiWeWa.View.Converter
{
    public class IntToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                int lenght = (int)value;
                GridLength gridLength = new GridLength(lenght, GridUnitType.Star);

                return gridLength;
            }

            return new GridLength(0, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                GridLength gridLength = (GridLength)value;

                return gridLength.Value;
            }

            return 0;
        }
    }
}
