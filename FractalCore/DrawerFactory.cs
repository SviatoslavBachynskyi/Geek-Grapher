using GeekGrapher.FractalCore.ColorCalculators;
using GeekGrapher.FractalCore.IterationCalculators;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        HistogramHSV,
        PaletteBased
    }
    public enum IterationPrinciple
    {
        Julia,
        Mandelbrot
    }
    public static class DrawerFactory
    {
        public static ColorCalculator CreateColorCalculator(ColorScheme colorScheme, Color[] palette)
        {
            switch (colorScheme)
            {
                case ColorScheme.BlackAndWhite:
                    return new BlackWhiteCalculator();
                case ColorScheme.HSVBased:
                    return new HSVCalculator();
                case ColorScheme.PaleteBased:
                    return new PaletteCalculator(palette);
                default:
                    throw new NotImplementedException();
            }
        }

        public static IterationCalculator CreateIterationCalculator(IterationPrinciple iterationPrinciple)
        {
            switch (iterationPrinciple)
            {
                case IterationPrinciple.Mandelbrot:
                    return new MandelbrotCalculator();
                case IterationPrinciple.Julia:
                    return new JuliaCalculator();
                default:
                    throw new NotImplementedException();
            }
        }

        public static Drawer CreateDrawer(FractalFunction function, ColorScheme colorScheme, IterationPrinciple iterationPrinciple, Color[] palette)
        {
            Drawer result;
            var colorCalculator = CreateColorCalculator(colorScheme, palette);
            var iterationCalculator = CreateIterationCalculator(iterationPrinciple);

            switch (function)
            {
                case FractalFunction.Chz:
                    result = new Drawer((z, c) => Complex.Cosh(z) + c, colorCalculator, iterationCalculator)
                    {
                        XStart = -2,
                        XFinish = 2,
                        YStart = -2,
                        YFinish = 2
                    };
                    break;
                case FractalFunction.Shz:
                    result = new Drawer((z, c) => Complex.Sinh(z) + c, colorCalculator, iterationCalculator)
                    {
                        XStart = -2,
                        XFinish = 2,
                        YStart = -2,
                        YFinish = 2
                    };
                    break;
                case FractalFunction.SinzCosz:
                    result = new Drawer((z, c) => Complex.Sin(z) * Complex.Cos(z) + c, colorCalculator, iterationCalculator)
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

            return result;
        }
    }
}
