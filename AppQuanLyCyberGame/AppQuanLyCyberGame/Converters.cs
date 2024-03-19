using System;
using System.Globalization;
using System.Windows.Data;

namespace AppQuanLyCyberGame
{
    public class SenderIdComparisonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Kiểm tra nếu giá trị value bằng với giá trị được truyền từ ViewModel
            if (value != null && value.ToString() == parameter?.ToString())
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}