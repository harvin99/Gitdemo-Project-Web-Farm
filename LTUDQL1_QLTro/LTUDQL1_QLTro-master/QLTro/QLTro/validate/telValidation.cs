using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QLTro.validate
{
    class TelValidation : ValidationRule
    {
        public int min { get; set; }
        public int max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            var phoneNumber = (string)value;
            if (phoneNumber.Length < min || phoneNumber.Length > max)
            {
                return new ValidationResult(false, $" {min} < tel < {max}");
            }
            var userphoneNumberPattern = @"^0[\d]+$";
            Regex userphoneNumberRegex = new Regex(userphoneNumberPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var isValidphoneNumber = userphoneNumberRegex.IsMatch(phoneNumber);
            return isValidphoneNumber ? ValidationResult.ValidResult : new ValidationResult(false, "invalid tel");
        }

    }
}
