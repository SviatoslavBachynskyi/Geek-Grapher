﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekGrapher.Shared;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    internal class HSVCalculator : IColorCalculator
    {
        private int _maxIteration;
        public HSVCalculator(int maxIteration)
        {
            _maxIteration = maxIteration;
        }
        public Color Calculate(int iteration)
        {
            if (iteration == _maxIteration) return Color.Black;

            return ColorModelConverter.ColorFromHSV(
                255.0 * iteration / _maxIteration, 1.0, 1.0);
        }
    }
}
