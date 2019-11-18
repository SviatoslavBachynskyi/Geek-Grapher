using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GeekGrapher.FractalPainter
{
    public class Frame
    {
        public WriteableBitmap Image { get; set; }
        public double XStart { get; set; }
        public double XFinish { get; set; }
        public double YStart { get; set; }
        public double YFinish { get; set; }
    }
}
