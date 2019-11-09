using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeekGrapher.FractalCore.ColorCalculators;

namespace GeekGrapher.FractalCore
{
    public class Drawer
    {
        private Func<Complex, Complex, Complex> _func;
        private IColorCalculator _colorCalculator;

        internal Drawer(Func<Complex, Complex, Complex> func, IColorCalculator colorCalculator)
        {
            this._func = func;
            this._colorCalculator = colorCalculator;
        }

        public double XStart { get; set; } = -2;
        public double XFinish { get; set; } = 2;
        public double YStart { get; set; } = -2;
        public double YFinish { get; set; } = 2;

        public int Height { get; set; } = 400;

        public int Width { get; set; } = 600;

        public Complex C { get; set; }

        public int MaxIteration { get; set; } = 80;

        //TODO: maybe return Color array and change it in viewmodel
        /// <summary>
        /// Calculate color value for each pixel
        /// </summary>
        /// <returns> linear byte array with color value 
        /// </returns>
        public byte[] Draw()
        {
            var result = new byte[Height * Width * 3];
            var calculator = new IterationCalculator()
            {
                MaxIteration = MaxIteration
            };
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    var z = new Complex(XStart + (XFinish - XStart) * x / Width,
                        YStart + (YFinish - YStart) * y / Height);
                    var iter = calculator.Calculate(_func, z, C);

                    var color = _colorCalculator.Calculate(iter);
                    result[3 * (y * Width + x)] = (byte)color.R;
                    result[3 * (y * Width + x) +1] = (byte)color.G;
                    result[3 * (y * Width + x) + 2] = (byte)color.B;
                }

            return result;
        }
    }
}
