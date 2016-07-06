using System;
using System.Windows.Data;

namespace ZhuiFengLib.ValueConverter
{
    /*
    *Bool值转换为图片
    *
    *
    */

    public class BoolToImageConverter : BoolToValueConverter<string> { }

    public class BoolToValueConverter<T> : IValueConverter
    {
        public T FalseValue { get; set; }
        public T TrueValue { get; set; }

        public int Max { get; set; }
        public int Min { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return FalseValue;
            else
                // return (bool)value ? TrueValue : FalseValue;
                return (double)value >= 0 ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null ? value.Equals(TrueValue) : false;
        }
    }
}