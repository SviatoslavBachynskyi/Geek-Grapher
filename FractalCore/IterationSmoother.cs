using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore
{
    internal static class IterationSmoother
    {
        internal static double MakeSmooth(Drawer drawer, int iteration, Complex z)
        {
            if (iteration == drawer.MaxIterations) return iteration;

            var result = iteration + 1 - Math.Log(Math.Log(Complex.Abs(z), 2));

            if (result > drawer.MaxIterations) result = drawer.MaxIterations;
            if (result < 0) result = 0;

            return result;
        }
    }
}
