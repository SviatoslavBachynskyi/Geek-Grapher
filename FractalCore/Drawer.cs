using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore
{
    public class Drawer
    {
        private Func<Complex, Complex, Complex> _func;

        public Drawer(Func<Complex, Complex, Complex> func)
        {
            this._func = func;
        }

        public double XStart { get; set; } = -2;
        public double XFinish { get; set; } = 1;
        public double YStart { get; set; } = -1.5;
        public double YFinish { get; set; } = 1.5;

        public int Height { get; set; } = 400;

        public int Width { get; set; } = 600;

        public byte[] Draw()
        {
            var result = new byte[Height * Width * 3];
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    var z = new Complex(XStart + (XFinish - XStart) * x / Width,
                        YStart + (YFinish - YStart) * y / Height);
                    var iter = Calculation.CalculateIteration(_func, z);
                    var color = 255 - (iter * 255) / Calculation.MaxIter;
                    result[3 * (y * Width + x)] = (byte)color;
                    result[3 * (y * Width + x) +1] = (byte)color;
                    result[3 * (y * Width + x) + 2] = (byte)color;
                }

            return result;
        }
    }
}
