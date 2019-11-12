using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GeekGrapher.FractalPainter.Validations
{
    class IntegerValidation : ValidationRule
    {
        public int Min { get; set; } = Int32.MaxValue;
        public int Max { get; set; } = Int32.MinValue;

        public string DisplayName { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int part;
            string str = value as string;

            if (str is null || str.Trim() == "")
                return new ValidationResult(false, $"{DisplayName} cannot be empty");

            if (!int.TryParse(str, out part))
            {
                return new ValidationResult(false, $"{str.Truncate(15)} is not a integer number");
            };

            if (part < Min || part > Max)
            {
                return new ValidationResult(false, $"{DisplayName} must be in range from {Min} to {Max}");
            }

            return ValidationResult.ValidResult;
        }
    }
}
