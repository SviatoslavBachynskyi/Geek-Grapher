using GeekGrapher.General;
using GeekGrapher.ImageConverter.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GeekGrapher.ImageConverter
{
    public class ImageConverterViewModel : BaseViewModel
    {
        private double _saturation = 1.0;
        public double Saturation
        {
            get => _saturation;
            set
            {
                _saturation = value;
                OnPropertyChanged(nameof(Saturation));
            }
        }

        private Point _mousePosition;

        public Point MousePosition
        {
            get => _mousePosition;
            set
            {
                _mousePosition = value;
                OnPropertyChanged(nameof(MousePosition));
            }
        }

        private BitmapImage _originalImage;
        public BitmapImage OriginalImage
        {
            get => _originalImage;
            set
            {
                _originalImage = value;
                OnPropertyChanged(nameof(OriginalImage));
            }
        }

        #region Commands
        private ICommand _openImage;
        public ICommand OpenImage
        {
            get
            {
                if (_openImage == null)
                {
                    _openImage = new OpenImage(this);
                }
                return _openImage;
            }
        }
        #endregion
    }
}
