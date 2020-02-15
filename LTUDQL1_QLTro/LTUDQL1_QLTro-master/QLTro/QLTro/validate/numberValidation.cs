using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QLTro.validate
{
    class NumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var phoneNumber = (string)value;
            
            var userphoneNumberPattern = @"^[\d]+\.?[\d]{0,}$";
            Regex userphoneNumberRegex = new Regex(userphoneNumberPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var isValidphoneNumber = userphoneNumberRegex.IsMatch(phoneNumber);
            return isValidphoneNumber ? ValidationResult.ValidResult : new ValidationResult(false, "invalid number");
        }

    }
}
