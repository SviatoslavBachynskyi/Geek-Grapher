using GeekGrapher.FractalCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GeekGrapher.FractalPainter.Commands
{
    internal class Draw : ICommand
    {
        private readonly FractalPainterViewModel WindowViewModel;

        public Draw(FractalPainterViewModel _windowViewModel)
        {
            WindowViewModel = _windowViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            var drawer = DrawerFactory.CreateDrawer(
                WindowViewModel.SelectedFractalFunction,
                WindowViewModel.SelectedColorScheme,
                IterationPrinciple.Julia);
            drawer.C = new Complex(WindowViewModel.CReal, WindowViewModel.CImaginary);
            drawer.Smooth = false;
            drawer.MaxIterations = WindowViewModel.MaxIterations;

            int height;
            int width;
            ImageFitter.Fit(
                (int)WindowViewModel.Window.Canvas.ActualWidth,
            (int)WindowViewModel.Window.Canvas.ActualHeight,
            (drawer.XFinish - drawer.XStart),
            (drawer.YFinish - drawer.YStart),
            out width,
            out height);

            drawer.Height = height;
            drawer.Width = width;
            var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);

            var int32Rect = new Int32Rect(0, 0, width, height);

            var pixels = ColorsToBytesConverter.Convert(drawer.Draw());

            bitmap.WritePixels(int32Rect, pixels, 3 * width, 0);

            WindowViewModel.Window.Image.Source = bitmap;
        }
    }
}
