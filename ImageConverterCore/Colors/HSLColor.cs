using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.ImageConverterCore
{
    public class HSLColor
    {
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Lightness { get; set; }

        public HSLColor(double h, double s, double l)
        {
            Hue = h;
            Saturation = s;
            Lightness = l;
        }
    }
}
