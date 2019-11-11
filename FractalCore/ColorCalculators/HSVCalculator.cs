using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekGrapher.Shared;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    internal class HSVCalculator : ColorCalculator
    {
        internal override Color Calculate(double iteration)
        {
            if (iteration == Drawer.MaxIterations) return Color.Black;

            return ColorModelConverter.ColorFromHSV(
                255.0 * iteration / Drawer.MaxIterations, 1.0, 1.0);
        }
    }
}
