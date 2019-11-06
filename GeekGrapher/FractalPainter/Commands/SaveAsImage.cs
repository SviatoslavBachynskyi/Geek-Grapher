using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace GeekGrapher.FractalPainter.Commands
{
    internal class SaveAsImage : ICommand
    {
        private readonly FractalPainterViewModel _windowViewModel;

        public SaveAsImage(FractalPainterViewModel windowViewModel)
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
            MessageBox.Show("Save");
        }
    }
}
