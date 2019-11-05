using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace GeekGrapher.Fractals.Commands
{
    internal class SaveAsImage : ICommand
    {
        FractalViewModel FractalViewModel { get; set; }

        public SaveAsImage(FractalViewModel fractalViewModel)
        {
            FractalViewModel = fractalViewModel;
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
