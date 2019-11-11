using GeekGrapher.FractalPainter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.StartWindow.Commands
{
    internal class OpenFractalPainter : ICommand
    {
        private readonly StartWindowViewModel _windowViewModel;

        public OpenFractalPainter(StartWindowViewModel windowViewModel)
        {
            _windowViewModel = windowViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            new FractalPainter.FractalPainter().Show();
            _windowViewModel.Window.Close();
        }
    }
}
