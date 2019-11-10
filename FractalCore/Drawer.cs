using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeekGrapher.FractalCore.ColorCalculators;
using GeekGrapher.FractalCore.IterationCalculators;

namespace GeekGrapher.FractalCore
{
    public class Drawer
    {
        internal Func<Complex, Complex, Complex> Function { get; set; }
        public ColorCalculator ColorCalculator { get; set; }

        public IterationCalculator IterationCalculator { get; set; }

        internal Drawer(Func<Complex, Complex, Complex> function, ColorCalculator colorCalculator, IterationCalculator iterationCalculator)
        {
            this.Function = function;
            this.ColorCalculator = colorCalculator;
            this.IterationCalculator = iterationCalculator;
        }

        public double XStart { get; set; } = -2;
        public double XFinish { get; set; } = 2;
        public double YStart { get; set; } = -2;
        public double YFinish { get; set; } = 2;

        public int Height { get; set; } = 400;

        public int Width { get; set; } = 600;

        public Complex C { get; set; }

        public int MaxIteration { get; set; } = 80;

        internal int[,] Iterations { get; set; }

        public Color[,] Draw()
        {
            var result = new Color[Height, Width];

            Iterations = new int[Height, Width];

            IterationCalculator.PreCalculate(this);

            Parallel.For(0, Height,
                (y) =>
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Iterations[y, x] = IterationCalculator.Calculate(
                           XStart + (XFinish - XStart) * x / Width,
                           YStart + (YFinish - YStart) * y / Height);
                    }
                }
                );

            ColorCalculator.PreCalculate(this);

            Parallel.For(0, Height,
                (y) =>
                {
                    for (int x = 0; x < Width; x++)
                    {
                        result[y, x] = ColorCalculator.Calculate(Iterations[y, x]);
                    }
                }
                );

            return result;
        }
    }
}
