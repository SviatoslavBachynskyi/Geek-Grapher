using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekGrapher.General.Commands;
using GeekGrapher.StartWindow.Commands;

namespace GeekGrapher.StartWindow
{
    internal class StartWindowViewModel
    {
        public StartWindow Window { get; set; }

        public StartWindowViewModel(StartWindow mainWindow)
        {
            Window = mainWindow;
        }

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

        private ICommand _openAffineTransformations;

        public ICommand OpenAffineTransformations
        {
            get
            {
                if (_openAffineTransformations == null)
                {
                    _openAffineTransformations = new OpenAffineTransformations(this);
                }
                return _openAffineTransformations;
            }
        }

        private ICommand _openFractalPainter;

        public ICommand OpenFractalPainter
        {
            get
            {
                if (_openFractalPainter == null)
                {
                    _openFractalPainter = new OpenFractalPainter(this);
                }
                return _openFractalPainter;
            }
        }

        private ICommand _openImageConverter;

        public ICommand OpenImageConverter
        {
            get
            {
                if (_openImageConverter == null)
                {
                    _openImageConverter = new OpenImageConverter(this);
                }
                return _openImageConverter;
            }
        }

    }
}
