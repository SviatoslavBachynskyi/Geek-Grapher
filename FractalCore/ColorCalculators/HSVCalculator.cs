using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GeekGrapher.Shared;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    internal class HSVCalculator : ColorCalculator
    {
        internal override Color Calculate(double iteration)
        {
            if (iteration == Drawer.MaxIterations) return Color.FromRgb(0,0,0);

            return ColorModelConverter.ColorFromHSV(
                255.0 * iteration / Drawer.MaxIterations, 1.0, 1.0);
        }
    }
}
