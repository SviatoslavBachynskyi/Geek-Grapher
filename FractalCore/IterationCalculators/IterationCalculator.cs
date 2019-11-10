using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore.IterationCalculators
{
    public abstract class IterationCalculator
    {
        protected Drawer Drawer;
        internal void PreCalculate(Drawer drawer)
        {
            this.Drawer = drawer;
        }

        internal abstract int Calculate(double x, double y);
    }
}
