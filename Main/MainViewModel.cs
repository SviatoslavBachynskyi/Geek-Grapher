using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekGrapher.Main.Commands;

namespace GeekGrapher.Main
{
    internal class MainViewModel
    {
        private ICommand _openHelp;

        public ICommand OpenHelp
        {
            get
            {
                if (_openHelp == null)
                {
                    _openHelp = new OpenHelp();
                }
                return _openHelp;
            }
        }

        private ICommand _openSettings;

        public ICommand OpenSettings
        {
            get
            {
                if (_openSettings == null)
                {
                    _openSettings = new OpenSettings();
                }
                return _openSettings;
            }
        }
    }
}
