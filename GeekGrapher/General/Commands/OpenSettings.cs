using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekGrapher.StartWindow;

namespace GeekGrapher.General.Commands
{
    internal class OpenSettings : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            new Settings.Settings().ShowDialog();
        }
    }
}
