using System;
using System.Globalization;
using System.Windows.Data;

namespace DXY.WorkSheet.Converter
{
    public class AddWidth : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value) + 17;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
