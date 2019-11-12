using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace GeekGrapher.FractalPainter
{
    class ComplexPartValidation : ValidationRule
    {
        public double Min { get; set; }
        public double Max { get; set; }

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

            if (part < -2 || part > 2)
            {
                return new ValidationResult(false, $"{DisplayName} must be in range from -2 to 2");
            }

            return ValidationResult.ValidResult;
        }
    }
}
