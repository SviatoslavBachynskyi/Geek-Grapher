using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.Main.Commands
{
    internal class OpenImageConverter : ICommand
    {
        MainViewModel MainViewModel { get; set; }

        public OpenImageConverter(MainViewModel mainViewModel)
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
            new ImageConverter().Show();
            MainViewModel.Window.Close();
        }
    }
}
