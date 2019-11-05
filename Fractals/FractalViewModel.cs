using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekGrapher.Fractals.Commands;

namespace GeekGrapher.Fractals
{
    internal class FractalViewModel
    {
        private ICommand _saveAsImage;

        public ICommand SaveAsImage
        {
            get
            {
                if(_saveAsImage == null)
                {
                    _saveAsImage = new SaveAsImage();
                }
                return _saveAsImage;
            }
        }

        private ICommand _close;

        public ICommand Close
        {
            get
            {
                if (_close == null)
                {
                    _close = new Close();
                }
                return _close;
            }
        }

        private ICommand _exit;

        public ICommand Exit
        {
            get
            {
                if (_exit == null)
                {
                    _exit = new Exit();
                }
                return _exit;
            }
        }
    }
}
