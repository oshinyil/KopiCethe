using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KopiCethe.StockManagement.App.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (targetType != typeof(ImageSource))
            {
                throw new InvalidOperationException("Target type must be System.Windows.Media.ImageSource.");
            }

            try
            {
                var img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri("/KopiCethe.StockManagement.App;component/Images/coffee" + value + ".jpg", UriKind.Relative);
                img.EndInit();
                return img;
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
