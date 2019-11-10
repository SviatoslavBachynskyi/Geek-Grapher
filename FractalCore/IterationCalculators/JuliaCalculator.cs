using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore.IterationCalculators
{
    internal class JuliaCalculator : IterationCalculator
    {
        internal override int Calculate(double x, double y)
        {
            Complex z = new Complex(x, y);
            Complex c = Drawer.C;
            for (int i = 0; i < Drawer.MaxIteration; i++)
            {
                z = Drawer.Function(z, c);
                if (Complex.Abs(z) > 2) return i;
            }

            return Drawer.MaxIteration;
        }
    }
}
