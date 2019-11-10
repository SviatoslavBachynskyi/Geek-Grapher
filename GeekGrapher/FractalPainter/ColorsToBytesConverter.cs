using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalPainter
{
    static class ColorsToBytesConverter
    {
        public static byte[] Convert(Color[,] colors)
        {
            var result = new byte[colors.Length * 3];

            var xStart = colors.GetLowerBound(1);
            var xFinish = colors.GetUpperBound(1);
            var yStart = colors.GetLowerBound(0);
            var yFinish = colors.GetUpperBound(0);
            var width = xFinish - xStart+1;

            for (int y = yStart; y <= yFinish; y++)
                for (int x = xStart; x <= xFinish; x++)
                {
                    result[3 * ((y-yStart) * width + (x-xStart))] = (byte)colors[y, x].B;
                    result[3 * ((y-yStart) * width + (x-xStart)) + 1] = (byte)colors[y, x].G;
                    result[3 * ((y-xStart) * width + (x-xStart)) + 2] = (byte)colors[y, x].R;
                }
            return result;
        }
    }
}
