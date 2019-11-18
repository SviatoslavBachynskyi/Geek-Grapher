using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    internal class BlackWhiteCalculator : ColorCalculator
    {

        internal override Color Calculate(double iteration)
        {
            var Hue = (byte)(255 - (iteration * 255) / Drawer.MaxIterations);
            return Color.FromRgb(Hue, Hue, Hue);
        }
    }
}
