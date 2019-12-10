using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GeekGrapher.General.Commands
{
    class OpenStartPage : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Window _window;

        public OpenStartPage(Window window)
        {
            _window = window;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            new StartWindow.StartWindow().Show();
            _window.Close();
        }
    }
}
