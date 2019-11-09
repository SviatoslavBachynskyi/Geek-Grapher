using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GeekGrapher.FractalCore
{
    internal class IterationCalculator
    {
        public int MaxIteration { get; set; } = 80;
        //TODO: you can change parameters to current pixel, it will be more flexible this way
        internal int Calculate(Func<Complex, Complex, Complex> function, Complex z, Complex c)
        {
            for(int i =0; i< MaxIteration; i++)
            {
                z = function(z, c);
                if (Complex.Abs(z) > 2) return i;
            }

            return MaxIteration;
        }
    }
}
