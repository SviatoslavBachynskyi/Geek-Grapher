using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace GeekGrapher.FractalPainter.Validations
{
    class DoubleValidation : ValidationRule
    {
        public double Min { get; set; } = Double.MaxValue;
        public double Max { get; set; } = Double.MinValue;

        public string DisplayName { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double part;
            string str = value as string;

            if (str.Trim() == "")
                return new ValidationResult(false, $"{DisplayName} cannot be empty");

            if (!double.TryParse(str, out part))
            {
                return new ValidationResult(false, $"{str.Truncate(15)} is not a numeric number");
            };

            if (part < Min || part > Max)
            {
                return new ValidationResult(false, $"{DisplayName} must be in range from {Min} to {Max}");
            }

            return ValidationResult.ValidResult;
        }
    }
}
