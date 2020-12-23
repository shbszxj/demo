using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfEnumToCheckbox
{
    public class DeptConverter : IValueConverter
    {
        private Department department;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue)
            {
                return false;
            }
            department = (Department)value;
            return department.HasFlag((Department)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            department ^= (Department)parameter;
            return department;
        }
    }
}
