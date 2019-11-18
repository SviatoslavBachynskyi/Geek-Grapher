using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.FractalPainter.Commands
{
    internal class Exit : ICommand
    {
        private readonly FractalPainterViewModel WindowViewModel;

        public Exit(FractalPainterViewModel _windowViewModel)
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
            throw new NotImplementedException();
        }
    }
}
