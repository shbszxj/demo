using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfTimer
{
    public class TimeSpanToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = string.Empty;
            if (value is TimeSpan)
            {
                var ts = (TimeSpan)value;
                result = ts.TotalSeconds < 1 ? string.Empty : ts.ToString("hh\\:mm\\:ss");
            }
            else if (value is DateTime)
            {
                result = ((DateTime)value).ToString("HH\\:mm\\:ss");
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
