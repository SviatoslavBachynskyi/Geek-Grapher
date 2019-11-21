using GeekGrapher.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GeekGrapher.FractalCore.ColorCalculators
{
    class HistogramHSVCalculator : ColorCalculator
    {
        private Dictionary<int, double> HueForIteration; 
        internal override void PreCalculate(Drawer drawer)
        {
            base.PreCalculate(drawer);

            var pixelsPerIteration = new Dictionary<int, int>(Drawer.MaxIterations);
            HueForIteration = new Dictionary<int, double>(Drawer.MaxIterations);

            for(int i = 0; i < drawer.MaxIterations; i++)
            {
                pixelsPerIteration[i] = 0;
            }

            foreach(var iteration in drawer.Iterations) {
                if((int)iteration != drawer.MaxIterations)
                pixelsPerIteration[(int)iteration]++;
            }
            var total = pixelsPerIteration.Values.Sum();

            var pixels = 0;

            for(int i =0; i< drawer.MaxIterations; i++)
            {
                HueForIteration[i] = ((double)pixels) / total * Constants.MaxHue;
                pixels += pixelsPerIteration[i];
            }
        }

        internal override Color Calculate(double iteration)
        {
            if (HueForIteration == null) throw new InvalidOperationException("Call PreCalculate fisrt");
            if (iteration == Drawer.MaxIterations) return Color.FromRgb(0, 0, 0);

            double current,next;
            current = HueForIteration[(int)iteration];
            if ((int)iteration == Drawer.MaxIterations - 1)
                next = Constants.MaxHue;
            else next = HueForIteration[(int)iteration + 1];

            var hue = current + (next - current) * (iteration - (int)iteration);

            return ColorModelConverter.ColorFromHSV(
                hue, 1.0, 1.0);
        }

    }
}
