using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GeekGrapher.AffineTransformations.ViewModels
{
    public class VertexViewModel : BaseViewModel
    {
        private string _x = "0.0";
        public string X { get => _x;
            set {
                _x = value;
                OnPropertyChanged(nameof(X));
            } }
        private string _y = "0.0";
        public string Y { get => _y;
            set {
                _y = value;
                OnPropertyChanged(nameof(Y));
            } }
        public Point ToPoint()
        {
            return new Point(Convert.ToDouble(X), Convert.ToDouble(Y));
        }
    }
}
