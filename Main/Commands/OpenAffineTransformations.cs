using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.Main.Commands
{
    internal class OpenAffineTransformations : ICommand
    {
        MainViewModel MainViewModel { get; set; }

        public OpenAffineTransformations(MainViewModel mainViewModel)
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
            new AffineTransformations().Show();
            MainViewModel.Window.Close();
        }
    }
}
