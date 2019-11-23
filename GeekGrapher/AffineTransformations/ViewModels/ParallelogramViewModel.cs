using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GeekGrapher.AffineTransformations.ViewModels
{
    public class ParallelogramViewModel : BaseViewModel
    {
        public VertexViewModel A { get; set; }
        public VertexViewModel B { get; set; }
        public VertexViewModel C { get; set; }
        public VertexViewModel D { get; set; }

        public RotationViewModel Rotation
        { get; set; } = new RotationViewModel()
        {
            Ratio = "1",
            Angle = "45"
        };

        public StyleViewModel Style
        { get; set; } = new StyleViewModel()
        {
            LineColor = Color.FromRgb(0, 0, 0),
            FillColor = Color.FromRgb(0, 0, 255)
        };

    }
}
