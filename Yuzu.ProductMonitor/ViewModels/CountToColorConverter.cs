using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Yuzu.ProductMonitor.ViewModels
{
    /// <summary>
    /// 数值到颜色转换器
    /// </summary>
    public class CountToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(99, 255, 255, 255));
            if (value != null && int.TryParse(value.ToString(), out int result))
            {
                if (result >= 30)
                {
                    brush = new SolidColorBrush(Color.FromRgb(207, 76, 122));
                }
                return brush;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
