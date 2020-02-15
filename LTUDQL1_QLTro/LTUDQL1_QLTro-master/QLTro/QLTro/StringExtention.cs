using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTro
{
    public static class StringExtention
    {
        public static string AccentRemoved(this string value)
        {
            string newvalue = value.Replace("à", "a").Replace("á", "a").Replace("ạ", "a").Replace("ả", "a").Replace("ã", "a").Replace("â", "a")
            .Replace("ầ", "a")
            .Replace("ấ", "a")
            .Replace("ậ", "a")
            .Replace("ẩ", "a")
            .Replace("ẫ", "a")
            .Replace("ă", "a")
            .Replace("ằ", "a")
            .Replace("ắ", "a")
            .Replace("ẳ", "a")
            .Replace("ẵ", "a")
            .Replace("ặ", "a");
            newvalue = newvalue.Replace("è", "e")
            .Replace("é", "e")
            .Replace("ẹ", "e")
            .Replace("ẻ", "e")
            .Replace("ẽ", "e")
            .Replace("ê", "e")
            .Replace("ề", "e")
            .Replace("ế", "e")
            .Replace("ệ", "e")
            .Replace("ể", "e")
            .Replace("ễ", "e");
            newvalue = newvalue.Replace("ì", "i")
            .Replace("í", "i")
            .Replace("ị", "i")
            .Replace("ỉ", "i")
            .Replace("ĩ", "i");
            newvalue = newvalue.Replace("ò", "o")
           .Replace("ó", "o")
           .Replace("ọ", "o")
           .Replace("ỏ", "o")
           .Replace("õ", "o")
           .Replace("ô", "o")
           .Replace("ồ", "o")
           .Replace("ố", "o")
           .Replace("ộ", "o")
           .Replace("ổ", "o")
           .Replace("ỗ", "o")
           .Replace("ơ", "o")
           .Replace("ờ", "o")
           .Replace("ớ", "o")
           .Replace("ợ", "o")
           .Replace("ở", "o")
           .Replace("ỡ", "o").Replace("ù", "u")
           .Replace("ú", "u")
           .Replace("ụ", "u")
           .Replace("ủ", "u")
           .Replace("ũ", "u")
           .Replace("ư", "u")
           .Replace("ừ", "u")
           .Replace("ứ", "u")
           .Replace("ự", "u")
           .Replace("ử", "u")
           .Replace("ữ", "u");
            newvalue = newvalue.Replace("ỳ", "y")
            .Replace("ý", "y")
            .Replace("ỵ", "y")
            .Replace("ỷ", "y")
            .Replace("ỹ", "y");
            newvalue = newvalue.Replace("đ", "d");
            return newvalue;
        }
    }
}
