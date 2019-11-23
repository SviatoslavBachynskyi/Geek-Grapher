using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GeekGrapher.AffineTransformations.ViewModels
{
    public class StyleViewModel : BaseViewModel
    {
        private Color _lineColor;
        public Color LineColor
        {
            get => _lineColor;
            set
            {
                _lineColor = value;
                OnPropertyChanged(nameof(LineColor));
            }
        }
        private Color _fillColor;
        public Color FillColor { get => _fillColor;
            set {
                _fillColor = value;
                OnPropertyChanged(nameof(FillColor));
            } }
    }
}
