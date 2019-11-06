using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekGrapher.StartWindow.Commands
{
    internal class OpenImageConverter : ICommand
    {
        private readonly StartWindowViewModel _windowViewModel;

        public OpenImageConverter(StartWindowViewModel windowViewModel)
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
            new ImageConverter.ImageConverter().Show();
            _windowViewModel.Window.Close();
        }
    }
}
