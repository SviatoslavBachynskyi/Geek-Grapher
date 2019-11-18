using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore
{
    public class ImageFitter
    {
        //only increases
        public static void Fit(int desiredWidth, int desiredHeight, double givenWidth, double givenHeight, out int width, out int height)
        {
            var widthRatio = desiredWidth / givenWidth;
            var heightRatio = desiredHeight / givenHeight;
            var ratio = Math.Min(widthRatio, heightRatio);
            width = (int)(givenWidth * ratio); ;
            height = (int)(givenHeight * ratio);
        }
    }
}
