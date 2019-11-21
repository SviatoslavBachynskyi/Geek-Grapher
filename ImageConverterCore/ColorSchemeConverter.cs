using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GeekGrapher.ImageConverterCore
{
    public static class ColorSchemeConverter
    {
        public static HSLColor RGBtoHSL(Color rgb)
        {
            // Convert RGB to a 0.0 to 1.0 range.
            double double_r = rgb.R / 255.0;
            double double_g = rgb.G / 255.0;
            double double_b = rgb.B / 255.0;
            double h, s, l;

            // Get the maximum and minimum RGB components.
            double max = double_r;
            if (max < double_g) max = double_g;
            if (max < double_b) max = double_b;

            double min = double_r;
            if (min > double_g) min = double_g;
            if (min > double_b) min = double_b;

            double diff = max - min;
            l = (max + min) / 2;
            if (Math.Abs(diff) < 0.00001)
            {
                s = 0;
                h = 0;  // H is really undefined.
            }
            else
            {
                if (l <= 0.5) s = diff / (max + min);
                else s = diff / (2 - max - min);

                double r_dist = (max - double_r) / diff;
                double g_dist = (max - double_g) / diff;
                double b_dist = (max - double_b) / diff;

                if (double_r == max) h = b_dist - g_dist;
                else if (double_g == max) h = 2 + r_dist - b_dist;
                else h = 4 + g_dist - r_dist;

                h = h * 60;
                if (h < 0) h += 360;
            }

            return new HSLColor(h, s * 100, l * 100);
        }

        public static Color CMYKtoRGB(CMYKColor cmyk)
        {
            double r = 255 * (1 - cmyk.Cyan / 255.0) * (1 - cmyk.Black / 255.0);
            double g = 255 * (1 - cmyk.Magenda / 255.0) * (1 - cmyk.Black / 255.0);
            double b = 255 * (1 - cmyk.Yellow / 255.0) * (1 - cmyk.Black / 255.0);

            return Color.FromRgb((byte)Math.Round(r), (byte)Math.Round(g), (byte)Math.Round(b));
        }

        public static HSLColor ChangeYellowSaturation(HSLColor color, double coef)
        {
            var result = new HSLColor(color.Hue, color.Saturation, color.Lightness);
            if (result.Hue >= 45 && result.Hue <= 75) 
                result.Saturation = ((result.Saturation * coef > 100)? 100: result.Saturation * coef);
            return result;
        }

        private static double QqhToRgb(double q1, double q2, double hue)
        {
            if (hue > 360) hue -= 360;
            else if (hue < 0) hue += 360;

            if (hue < 60) return q1 + (q2 - q1) * hue / 60;
            if (hue < 180) return q2;
            if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
            return q1;
        }

        public static CMYKColor HSLtoCMYK(HSLColor hsl)
        {
            double h = hsl.Hue;
            double s = hsl.Saturation/ 100;
            double l = hsl.Lightness / 100;
            //hsl to rgb
            double p2;
            if (l <= 0.5) p2 = l * (1 + s);
            else p2 = l + s - l * s;

            double p1 = 2 * l - p2;
            double double_r, double_g, double_b;
            if (s == 0)
            {
                double_r = l;
                double_g = l;
                double_b = l;
            }
            else
            {
                double_r = QqhToRgb(p1, p2, h + 120);
                double_g = QqhToRgb(p1, p2, h);
                double_b = QqhToRgb(p1, p2, h - 120);
            }

            // Convert RGB to the 0 to 255 range.
            double r = (int)(double_r * 255.0);
            double g = (int)(double_g * 255.0);
            double b = (int)(double_b * 255.0);

            //rgb to cmyk
            double tempR = r / 255;
            double tempG = g / 255;
            double tempB = b / 255;

            double black = 1 - (tempR > tempG ? (tempR > tempB ? tempR : tempB) : (tempG > tempB ? tempG : tempB));

            double cyan = (1 - tempR - black) / (1 - black);
            double magenda = (1 - tempG - black) / (1 - black);
            double yellow = (1 - tempB - black) / (1 - black);
            if (cyan < 0) cyan = 0;
            if (magenda < 0) magenda = 0;
            if (yellow < 0) yellow = 0;

            if(black == 1)
            {
                cyan = 0;
                magenda = 0;
                yellow = 0;
            }

            return new CMYKColor((byte)Math.Round(cyan * 255), (byte)Math.Round(magenda * 255), (byte)Math.Round(yellow * 255), (byte)Math.Round(black * 255));
        }

    }
}
