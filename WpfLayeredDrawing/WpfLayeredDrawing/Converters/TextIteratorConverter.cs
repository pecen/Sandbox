using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfLayeredDrawing.Converters
{
    public class TextIteratorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = value as string;

            if (!string.IsNullOrEmpty(v))
            {
                int i = 0;

                if(int.TryParse(v.Last().ToString(), out i))
                {
                    return v.Length - 1 + ++i;
                }
                else
                {
                    return v + i;
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
