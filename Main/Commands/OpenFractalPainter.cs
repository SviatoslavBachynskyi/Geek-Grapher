using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.Main.Commands
{
    internal class OpenFractalPainter : ICommand
    {
        MainViewModel MainViewModel { get; set; }

        public OpenFractalPainter(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            new FractalPainter().Show();
            MainViewModel.Window.Close();
        }
    }
}
