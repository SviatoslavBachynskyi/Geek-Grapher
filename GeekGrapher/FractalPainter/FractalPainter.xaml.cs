using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GeekGrapher.FractalCore;

namespace GeekGrapher.FractalPainter
{
    /// <summary>
    /// Interaction logic for FractalPainter.xaml
    /// </summary>
    public partial class FractalPainter : Window
    {
        private FractalPainterViewModel _viewModel;
        internal FractalPainterViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                this.DataContext = value;
            }
        }

        public FractalPainter()
        {
            InitializeComponent();

            ViewModel = new FractalPainterViewModel(this);

            var width = 700;
            var height = 700;

            var drawer = DrawerFactory.Create(FractalFunction.SinzCosz, ColorScheme.HSVBased);
            drawer.Width = width;
            drawer.Height = height;
            drawer.C = new Complex(-0.4, 0.6);

            var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);

            var int32Rect = new Int32Rect(0, 0, width, height);

            var pixels = drawer.Draw();

            bitmap.WritePixels(int32Rect, pixels, 3 * width, 0);

            Image.Source = bitmap;
        }
    }
}
