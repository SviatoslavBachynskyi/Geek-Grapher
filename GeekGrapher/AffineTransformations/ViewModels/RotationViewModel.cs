using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.AffineTransformations.ViewModels
{
    public enum Direction
    {
        Left,
        Right
    }

    public enum RotationVertex
    {
        A,
        B,
        C,
        D
    }

    public class RotationViewModel : BaseViewModel
    {
        private RotationVertex _rotationVertex;
        public RotationVertex RotationVertex
        {
            get => _rotationVertex;
            set
            {
                _rotationVertex = value;
                OnPropertyChanged(nameof(RotationVertex));
            }
        }

        private Direction _direction;
        public Direction Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                OnPropertyChanged(nameof(Direction));
            }
        }

        private string _angle;

        public string Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                OnPropertyChanged(nameof(Angle));
            }
        }

        private string _ratio;

        public string Ratio
        {
            get => _ratio;
            set
            {
                _ratio = value;
                OnPropertyChanged(nameof(Ratio));
            }
        }
    }
}
