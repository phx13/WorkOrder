using System;
using System.Globalization;
using System.Windows.Data;

namespace DXY.WorkSheet.Converter
{
    public class Left_Bottom : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value},0,0,{value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
