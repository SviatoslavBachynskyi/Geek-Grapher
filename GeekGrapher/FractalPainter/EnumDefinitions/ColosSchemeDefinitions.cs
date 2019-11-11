using GeekGrapher.FractalCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalPainter.EnumDefinitions
{
    internal class ColosSchemeDefinitions
    {
        public static Dictionary<ColorScheme, string> ColorSchemes = new Dictionary<ColorScheme, string>()
        {
            {ColorScheme.BlackAndWhite, "Black and white" },
            {ColorScheme.HSVBased, "HSV based" },
            //{ColorScheme.PaletteBased, "Palette" },
            //{ ColorScheme.HistogramHSV, "HSV based with histogram" },
        };
    }
}
