using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.Fractals.Commands
{
    internal class Exit : ICommand
    {
        FractalViewModel FractalViewModel { get; set; }

        public Exit(FractalViewModel fractalViewModel)
        {
            FractalViewModel = fractalViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
