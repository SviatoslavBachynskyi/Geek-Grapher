using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    internal class PaletteCalculator : ColorCalculator
    {
        private Color[] palette;

        public PaletteCalculator(Color[] palette)
        {
            this.palette = palette;
        }

        internal override Color Calculate(double iteration)
        {
            if (iteration == Drawer.MaxIterations) return Color.Black;

            return palette[(int)iteration % palette.Length];
        }
    }
}
