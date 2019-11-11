using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace GeekGrapher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        StreamWriter _streamWriter;
        BindingErrorListener _bindingErrorListener;
        public App()
        {
#if DEBUG
            _streamWriter = new StreamWriter(new FileStream("BindingErrors.txt", FileMode.Create));
            _bindingErrorListener =
            new BindingErrorListener(msg =>
            {
                _streamWriter.WriteLine(msg);
            });
#endif
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _streamWriter?.Close();
            _streamWriter?.Dispose();
            _bindingErrorListener?.Dispose();
        }
    }
}
