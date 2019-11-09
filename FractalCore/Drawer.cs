using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        public double XFinish { get; set; } = 2;
        public double YStart { get; set; } = -2;
        public double YFinish { get; set; } = 2;

        public Bitmap Draw(Image image)
        {
            var result = new Bitmap(image);
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    var z = new Complex(XStart + (XFinish - XStart) * x / image.Width,
                        YStart + (YFinish - YStart) * y / image.Height);
                    var iter = Calculation.CalculateIteration(_func, z);
                    var color = 255 - (iter * 255) / Calculation.MaxIter;
                    result.SetPixel(x, y, Color.FromArgb(color, color, color));
                }

            return result;
        }
    }
}
