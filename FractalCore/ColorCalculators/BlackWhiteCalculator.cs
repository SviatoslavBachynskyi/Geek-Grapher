using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    internal class BlackWhiteCalculator : IColorCalculator
    {
        private int _maxIteration;
        public BlackWhiteCalculator(int maxIteration)
        {
            _maxIteration = maxIteration;
        }
        public Color Calculate(int iteration)
        {
            var Hue = 255 - (iteration * 255) / _maxIteration;
            return Color.FromArgb(Hue, Hue, Hue);
        }
    }
}
