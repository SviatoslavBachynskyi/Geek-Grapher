using GeekGrapher.General;
using GeekGrapher.ImageConverter.Commands;
using GeekGrapher.ImageConverterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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
                CalculateCMYK();
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
                OnPropertyChanged(nameof(HSLText));
                OnPropertyChanged(nameof(CMYKText));
            }
        }

        public string HSLText { get{
                if (OriginalImage == null) return "HSV(h,s,v)";
                int x = (int) MousePosition.X;
                int y = (int)MousePosition.Y;
                var color = HSLColors[y, x];
                return $"HSL({color.Hue.ToString("F0")}, {color.Saturation.ToString("F2")}, {color.Lightness.ToString("F2")})";
            } }

        public string CMYKText
        {
            get
            {
                if (OriginalImage == null) return "CMYK(c,m,y,k)";
                int x = (int)MousePosition.X;
                int y = (int)MousePosition.Y;
                var color = CMYKColors[y, x];
                return $"CMYK({color.Cyan.ToString("F0")}, {color.Magenda.ToString("F0")}, {color.Yellow.ToString("F0")}, {color.Black.ToString("F0")})";
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
                CalculateRGB();
            }
        }
        private Color[,] _rgbColors;
        public Color[,] RGBColors
        {
            get => _rgbColors;
            set
            {
                _rgbColors = value;
                OnPropertyChanged(nameof(RGBColors));
                CalculateHSL();
            }
        }

        private HSLColor[,] _HSLColors;
        public HSLColor[,] HSLColors
        {
            get => _HSLColors;
            set
            {
                _HSLColors = value;
                OnPropertyChanged(nameof(HSLColors));
                CalculateCMYK();
            }
        }

        private CMYKColor[,] _CMYKColors;
        public CMYKColor[,] CMYKColors
        {
            get => _CMYKColors;
            set
            {
                _CMYKColors = value;
                OnPropertyChanged(nameof(CMYKColors));
                CalculateConvertedImage();
            }
        }

        private WriteableBitmap _convertedImage;
        public WriteableBitmap ConvertedImage
        {
            get => _convertedImage;
            set
            {
                _convertedImage = value;
                OnPropertyChanged(nameof(ConvertedImage));
            }
        }


        private void CalculateRGB()
        {
            if (_originalImage == null) return;
            var bytes = new byte[_originalImage.PixelWidth * _originalImage.PixelHeight * 4];
            var Colors = new Color[_originalImage.PixelHeight, _originalImage.PixelWidth];
            _originalImage.CopyPixels(bytes, _originalImage.PixelWidth * 4, 0);
            for (int y = 0; y < _originalImage.PixelHeight; y++)
            {
                for (int x = 0; x < _originalImage.PixelWidth; x++)
                {
                    var offset = 4 * (y * _originalImage.PixelWidth + x);
                    Colors[y, x] = Color.FromRgb(bytes[offset + 2], bytes[offset + 1], bytes[offset]);
                }
            }
            RGBColors = Colors;
        }

        private void CalculateHSL()
        {
            if (_originalImage == null) return;
            var colors = new HSLColor[_originalImage.PixelHeight, _originalImage.PixelWidth];
            for (int y = 0; y < _originalImage.PixelHeight; y++)
            {
                for (int x = 0; x < _originalImage.PixelWidth; x++)
                {
                    colors[y, x] = ColorSchemeConverter.RGBtoHSL(RGBColors[y, x]);
                }
            }
            HSLColors = colors;
        }

        private void CalculateCMYK()
        {
            if (_originalImage == null) return;
            var colors = new CMYKColor[_originalImage.PixelHeight, _originalImage.PixelWidth];
            for (int y = 0; y < _originalImage.PixelHeight; y++)
            {
                for (int x = 0; x < _originalImage.PixelWidth; x++)
                {
                    colors[y, x] = ColorSchemeConverter.HSLtoCMYK(
                       ColorSchemeConverter.ChangeYellowSaturation(HSLColors[y, x], Saturation));
                }
            }
            CMYKColors = colors;
        }

        private void CalculateConvertedImage()
        {
            if (_originalImage == null) return;
            var colors = new Color[_originalImage.PixelHeight, _originalImage.PixelWidth];
            for (int y = 0; y < _originalImage.PixelHeight; y++)
            {
                for (int x = 0; x < _originalImage.PixelWidth; x++)
                {
                    colors[y, x] = ColorSchemeConverter.CMYKtoRGB(CMYKColors[y,x]);
                }
            }
            var bitmap = new WriteableBitmap(_originalImage.PixelWidth, _originalImage.PixelHeight, 96, 96, PixelFormats.Bgr24, null);

            var int32Rect = new Int32Rect(0, 0, _originalImage.PixelWidth, _originalImage.PixelHeight);

            var pixels = ColorsToBytesConverter.Convert(colors);

            bitmap.WritePixels(int32Rect, pixels, 3 * _originalImage.PixelWidth, 0);
            ConvertedImage = bitmap;
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
        private ICommand _emptyCommand;
        public ICommand EmptyCommand
        {
            get
            {
                if (_emptyCommand == null)
                {
                    _emptyCommand = new EmptyCommand();
                }
                return _emptyCommand;
            }
        }
        private ICommand _saveAsImage;
        public ICommand SaveAsImage
        {
            get
            {
                if (_saveAsImage == null)
                {
                    _saveAsImage = new SaveAsImage(this);
                }
                return _saveAsImage;
            }
        }
        #endregion
    }
}
