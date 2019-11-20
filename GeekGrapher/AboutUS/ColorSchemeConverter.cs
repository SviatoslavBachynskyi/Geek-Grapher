using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.AboutUS
{
    class RGBColor
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }

        public RGBColor(double r, double g, double b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }
    }
    class HSLColor
    {
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Lightness { get; set; }

        public HSLColor(double h, double s, double l)
        {
            Hue = h;
            Saturation = s;
            Lightness = l;
        }
    }
    class CMYKColor
    {
        public double Cyan { get; set; }
        public double Magenda { get; set; }
        public double Yellow { get; set; }
        public double Black { get; set; }

        public CMYKColor(double c, double m, double y, double k)
        {
            Cyan = c;
            Magenda = m;
            Yellow = y;
            Black = k;
        }
    }
    class ColorConverter
    {
        public static HSLColor RGBtoHSL(RGBColor rgb)
        {
            double h = 0, s = 0, l = 0;

            double tempR = rgb.Red / 255;
            double tempG = rgb.Green / 255;
            double tempB = rgb.Blue / 255;

            double Cmax = tempR > tempG ? (tempR > tempB ? tempR : tempB) : (tempG > tempB ? tempG : tempB);
            double Cmin = tempR < tempG ? (tempR < tempB ? tempR : tempB) : (tempG < tempB ? tempG : tempB);

            double delta = Cmax - Cmin;

            // hue calculation

            if (Cmax == tempR)
            {
                h = (tempG - tempB) / delta;
            }
            else if (Cmax == tempG)
            {
                h = (tempB - tempR) / delta + 2;
            }
            else if (Cmax == tempB)
            {
                h = (tempR - tempG) / delta + 4;
            }
            else if (delta == 0)
            {
                h = 0;
            }

            // saturation calculation

            if (delta < 0.5)
            {
                s = (Cmax - Cmin) / (Cmax + Cmin);
            }
            else if (delta > 0.5)
            {
                s = (Cmax - Cmin) / (2 - Cmax - Cmin);
            }
            else if (delta == 0)
            {
                s = 0;
            }

            //lightness calculation
            l = (Cmax + Cmin) / 2;

            return new HSLColor(Math.Round(h * 60), Math.Round(s * 100), Math.Round(l * 100));
        }


        public static RGBColor CMYKtoRGB(CMYKColor cmyk)
        {
            double r = 255 * (1 - cmyk.Cyan / 100) * (1 - cmyk.Black / 100);
            double g = 255 * (1 - cmyk.Magenda / 100) * (1 - cmyk.Black / 100);
            double b = 255 * (1 - cmyk.Yellow / 100) * (1 - cmyk.Black / 100);

            return new RGBColor(Math.Round(r), Math.Round(g), Math.Round(b));
        }


        public static CMYKColor HSLtoCMYK(HSLColor hsl)
        {
            //hsl to rgb
            double h = hsl.Hue;
            double s = hsl.Saturation / 100;
            double l = hsl.Lightness / 100;

            double C = (1 - Math.Abs(2 * l - 1)) * s;
            double X = C * (1 - Math.Abs(h / 60 % 2 - 1));
            double m = l - C / 2;

            double tempR = 0, tempG = 0, tempB = 0;

            if (h >= 0 & h < 60)
            {
                tempR = C; tempG = X; tempB = 0;
            }
            else if (h >= 60 & h < 120)
            {
                tempR = X; tempG = C; tempB = 0;
            }
            else if (h >= 120 & h < 180)
            {
                tempR = 0; tempG = C; tempB = X;
            }
            else if (h >= 180 & h < 240)
            {
                tempR = 0; tempG = X; tempB = C;
            }
            else if (h >= 240 & h < 300)
            {
                tempR = X; tempG = 0; tempB = C;
            }
            else if (h >= 300 & h < 360)
            {
                tempR = C; tempG = 0; tempB = X;
            }

            double r = Math.Round((tempR + m) * 255);
            double g = Math.Round((tempG + m) * 255);
            double b = Math.Round((tempB + m) * 255);

            //rgb to cmyk
            tempR = r / 255;
            tempG = g / 255;
            tempB = b / 255;

            double black = 1 - (tempR > tempG ? (tempR > tempB ? tempR : tempB) : (tempG > tempB ? tempG : tempB));

            double cyan = (1 - tempR - black) / (1 - black);
            double magenda = (1 - tempG - black) / (1 - black);
            double yellow = (1 - tempB - black) / (1 - black);

            return new CMYKColor(Math.Round(cyan * 100), Math.Round(magenda * 100), Math.Round(yellow * 100), Math.Round(black * 100));
        }

    }
}
