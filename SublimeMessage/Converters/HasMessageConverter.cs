using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SublimeMessage.Converters
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class HasMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool hasMessage = (bool)value;
            return hasMessage ? "(>.<)" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string hasMessageString = (string)value;
            return hasMessageString != "";
        }
    }
}
