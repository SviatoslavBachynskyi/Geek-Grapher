using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GeekGrapher.General;
using GeekGrapher.UserManual.ViewModels;

namespace GeekGrapher.UserManual.Commands
{
    class LoadFromFile : ChangableCommand
    {
        private ManualViewModel _manualViewModel;
        public LoadFromFile(ManualViewModel manualViewModel)
        {
            _manualViewModel = manualViewModel;
        }
        public override void Execute(object parameter)
        {
            string path = (string)parameter;
            string text;
            try
            {
                text = File.ReadAllText(path);
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "Не вдалося прочитати файл з інструкцією, переконайтеся, що програма містить всі файли",
                    "Помилка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                text = _manualViewModel.Text;
            }

            _manualViewModel.Text = text;
        }
    }
}
