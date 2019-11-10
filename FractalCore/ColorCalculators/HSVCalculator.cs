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
        internal override Color Calculate(int iteration)
        {
            if (iteration == Drawer.MaxIteration) return Color.Black;

            return ColorModelConverter.ColorFromHSV(
                255.0 * iteration / Drawer.MaxIteration, 1.0, 1.0);
        }
    }
}
