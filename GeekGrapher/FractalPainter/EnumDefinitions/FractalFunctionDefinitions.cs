using GeekGrapher.FractalCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalPainter.EnumDefinitions
{
    internal class FractalFunctionDefinitions
    {
        public static Dictionary<FractalFunction, string> FractalFunctions =
            new Dictionary<FractalFunction, string>()
            {
                {FractalFunction.Shz, "z = sh(z) + C" },
                {FractalFunction.Chz, "z = ch(z) + C" },
                {FractalFunction.SinzCosz, "z = sin(z)*cos(z) + C" }
            };
    }
}
