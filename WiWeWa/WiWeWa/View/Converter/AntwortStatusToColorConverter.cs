using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using WiWeWa.Model.Enum;
using Xamarin.Forms;

namespace WiWeWa.View.Converter
{
    public class AntwortStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                AntwortStatus status = (AntwortStatus)value;

                switch (status)
                {
                    case AntwortStatus.NotSelected:
                        return App.Current.Resources["PrimaryColor"];

                    case AntwortStatus.Selected:
                        return App.Current.Resources["SecondaryColor"];

                    case AntwortStatus.Right:
                        return App.Current.Resources["RightColor"];

                    case AntwortStatus.Wrong:
                        return App.Current.Resources["WrongColor"];

                    default:
                        return App.Current.Resources["PrimaryColor"];
                }
            }

            return App.Current.Resources["PrimaryColor"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }

    }
}
