using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.FractalPainter.Commands
{
    internal class Redo : ICommand
    {
        private readonly FractalPainterViewModel WindowViewModel;

        public Redo(FractalPainterViewModel _windowViewModel)
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
            if(WindowViewModel.FrameIndex < WindowViewModel.Frames.Count())
            {
                var frame = WindowViewModel.Frames[WindowViewModel.FrameIndex++];
                WindowViewModel.Window.Image.Source = frame.Image;
                WindowViewModel.Drawer.XStart = frame.XStart;
                WindowViewModel.Drawer.XFinish = frame.XFinish;
                WindowViewModel.Drawer.YStart = frame.YStart;
                WindowViewModel.Drawer.YFinish = frame.YFinish;
            }
        }
    }
}