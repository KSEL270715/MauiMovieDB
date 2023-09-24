using System;
using System.Globalization;

namespace MauiMovieDB.Converters
{
    public class PercentageConverter : IValueConverter
    {
        public PercentageConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? rating = value as double?;
            
            return Math.Round(rating.Value, 1) * 10 + "%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

