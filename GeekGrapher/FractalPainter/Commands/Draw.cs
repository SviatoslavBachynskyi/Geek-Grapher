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
    internal class Draw : ChangableCommand
    {
        private readonly FractalPainterViewModel WindowViewModel;

        public Draw(FractalPainterViewModel _windowViewModel)
        {
            WindowViewModel = _windowViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return WindowViewModel.IsValid();
        }

        public override void Execute(object parameter)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                var drawer = WindowViewModel.Drawer;
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

                WindowViewModel.Frames.RemoveRange(WindowViewModel.FrameIndex, WindowViewModel.Frames.Count - WindowViewModel.FrameIndex);
                WindowViewModel.Frames.Add(new Frame()
                {
                    Image = bitmap,
                    XStart = drawer.XStart,
                    XFinish = drawer.XFinish,
                    YStart = drawer.YStart,
                    YFinish = drawer.YFinish
                });
                WindowViewModel.FrameIndex++;

                WindowViewModel.Window.Image.Source = bitmap;
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}
