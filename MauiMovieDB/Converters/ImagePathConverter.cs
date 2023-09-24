using System;
using System.Globalization;
using MauiMovieDB.Utils;

namespace MauiMovieDB.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public ImagePathConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imagePath = value as string;
            string imageURL = Path.Combine(AppConstants.ImageRootPath + imagePath);
            return imageURL;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

