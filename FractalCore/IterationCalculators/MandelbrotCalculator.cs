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
        internal override int Calculate(double x, double y, out Complex z)
        {
            //TODO: Check this
            z = Drawer.C;
            Complex c = new Complex(x, y);
            for (int i = 0; i < Drawer.MaxIterations; i++)
            {
                z = Drawer.Function(z, c);
                if (Complex.Abs(z) > 2) return i;
            }

            return Drawer.MaxIterations;
        }
    }
}
