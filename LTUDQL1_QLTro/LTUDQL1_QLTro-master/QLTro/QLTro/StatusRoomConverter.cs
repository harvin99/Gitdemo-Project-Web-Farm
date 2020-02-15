using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QLTro
{
    class StatusRoomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result;
            if(int.Parse(value.ToString()) == 1)
            {
                result = "Trống";
            }
            else if(int.Parse(value.ToString()) == 2)
            {
                result = "Đã Có Người Thuê";
            }
            else
            {
                result = "Đang Sữa Chữa";
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
