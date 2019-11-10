using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    internal class BlackWhiteCalculator : ColorCalculator
    {

        internal override Color Calculate(double iteration)
        {
            var Hue = (int)(255 - (iteration * 255) / Drawer.MaxIterations);
            return Color.FromArgb(Hue, Hue, Hue);
        }
    }
}
