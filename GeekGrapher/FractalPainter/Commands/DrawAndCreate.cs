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
    internal class DrawAndCreate : ICommand
    {
        private readonly FractalPainterViewModel WindowViewModel;

        public DrawAndCreate(FractalPainterViewModel _windowViewModel)
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
            var drawer =
        DrawerFactory.CreateDrawer(
            WindowViewModel.SelectedFractalFunction,
            WindowViewModel.SelectedColorScheme, WindowViewModel.Palette.Select(cw => cw.Value).ToArray(),
            IterationPrinciple.Julia);

            WindowViewModel.Drawer = drawer;

            var cReal = Double.Parse(WindowViewModel.CReal);
            var CImaginary = Double.Parse(WindowViewModel.CImaginary);
            var maxIterations = Int32.Parse(WindowViewModel.MaxIterations);

            drawer.C = new Complex(cReal, CImaginary);
            drawer.Smooth = true;
            drawer.MaxIterations = maxIterations;

            WindowViewModel.Frames = new List<Frame>();
            WindowViewModel.FrameIndex = 0;

            WindowViewModel.Draw.Execute(parameter);
        }
    }
}
