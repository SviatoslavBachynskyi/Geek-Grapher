using GeekGrapher.FractalCore.ColorCalculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore
{
    public enum FractalFunction
    {
        Shz,
        Chz,
        SinzCosz
    }
    public enum ColorScheme
    {
        BlackAndWhite,
        HSVBased,
        SmoothHSV,
        HistogramHSV,
        PaleteBased
    }
    public static class DrawerFactory
    {
        public static Drawer Create(FractalFunction function, ColorScheme colorScheme)
        {
            Drawer result;
            IColorCalculator colorCalculator;
            int maxIteration = 80;

            switch(colorScheme){
                case ColorScheme.BlackAndWhite:
                    colorCalculator = new BlackWhiteCalculator(maxIteration);
                    break;
                default:
                    throw new NotImplementedException();
            }
            switch (function)
            {
                case FractalFunction.Chz:
                    result = new Drawer((z, c) => Complex.Cosh(z) + c, colorCalculator)
                    {
                        XStart = -2,
                        XFinish = 2,
                        YStart = -2,
                        YFinish = 2
                    };
                    break;
                case FractalFunction.Shz:
                    result = new Drawer((z, c) => Complex.Sinh(z) + c,colorCalculator)
                    {
                        XStart = -2,
                        XFinish = 2,
                        YStart = -2,
                        YFinish = 2
                    };
                    break;
                case FractalFunction.SinzCosz:
                    result = new Drawer((z, c) => Complex.Sin(z) * Complex.Cos(z) + c, colorCalculator)
                    {
                        XStart = -2,
                        XFinish = 2,
                        YStart = -2,
                        YFinish = 2
                    };
                    break;
                default:
                    throw new NotImplementedException();
            }

            result.MaxIteration = maxIteration;

            return result;
        }
    }
}
