using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore.IterationCalculators
{
    internal class MandelbrotCalculator : IterationCalculator
    {
        internal override int Calculate(double x, double y)
        {
            //TODO: Check this
            Complex z = Drawer.C;
            Complex c = new Complex(x, y);
            for (int i = 0; i < Drawer.MaxIteration; i++)
            {
                z = Drawer.Function(z, c);
                if (Complex.Abs(z) > 2) return i;
            }

            return Drawer.MaxIteration;
        }
    }
}
