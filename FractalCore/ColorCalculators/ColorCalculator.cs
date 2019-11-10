using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    public abstract class ColorCalculator
    {
        protected Drawer Drawer;
        internal void PreCalculate(Drawer drawer)
        {
            this.Drawer = drawer;
        }

        internal abstract Color Calculate(int iteration);
    }
}
