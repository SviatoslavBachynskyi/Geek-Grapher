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

        public byte[] Draw()
        {
            var result = new byte[Height * Width * 3];

            IterationCalculator.PreCalculate(this);
            ColorCalculator.PreCalculate(this);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    var iter = IterationCalculator.Calculate(
                        XStart + (XFinish - XStart) * x / Width,
                        YStart + (YFinish - YStart) * y / Height);

                    var color = ColorCalculator.Calculate(iter);
                    result[3 * (y * Width + x)] = (byte)color.B;
                    result[3 * (y * Width + x) + 1] = (byte)color.G;
                    result[3 * (y * Width + x) + 2] = (byte)color.R;
                }

            return result;
        }
    }
}
