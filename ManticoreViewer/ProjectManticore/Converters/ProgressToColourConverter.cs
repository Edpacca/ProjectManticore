using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ManticoreViewer
{
    public class ProgressToColourConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double value = System.Convert.ToDouble(values[0]);
            double maximum = System.Convert.ToDouble(values[1]);
            var progress = (value / maximum) * 100;

            if (progress <= 10d)
            {
                return Brushes.DarkRed;
            }
            else if (progress <= 50d)
            {
                return Brushes.Red;
            }

            return Brushes.Green;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
