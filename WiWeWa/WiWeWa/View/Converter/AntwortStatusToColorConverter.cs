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
                        return Color.White;

                    case AntwortStatus.Selected:
                        return Color.Teal;

                    case AntwortStatus.Right:
                        return Color.Green;

                    case AntwortStatus.Wrong:
                        return Color.Red;

                    default:
                        return Color.White;
                }
            }

            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }

    }
}
