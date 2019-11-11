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
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double cReal;

            if (!double.TryParse(value as string, out cReal))
            {
                return new ValidationResult(false, "CReal is not a numeric number");
            };

            if (cReal < -2 || cReal > 2)
            {
                return new ValidationResult(false, "C Real must be in range from -2 to 2");
            }

            return ValidationResult.ValidResult;
        }
    }
}
