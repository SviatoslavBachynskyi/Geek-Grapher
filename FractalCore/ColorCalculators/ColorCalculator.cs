using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    public abstract class ColorCalculator
    {
        protected Drawer Drawer;
        internal void PreCalculate(Drawer drawer)
        {
            this.Drawer = drawer;
        }

        internal abstract Color Calculate(double iteration);
    }
}
