using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GeekGrapher.FractalCore
{
    internal static class Calculation
    {
        public const int MaxIter = 50;
        internal static int CalculateIteration(Func<Complex, Complex, Complex> function, Complex c)
        {
            Complex z = new Complex();
            for(int i =0; i< MaxIter; i++)
            {
                z = function(z, c);
                if (Complex.Abs(z) > 2) return i;
            }

            return MaxIter;
        }
    }
}
