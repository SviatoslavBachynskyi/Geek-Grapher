using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekGrapher.FractalCore;
using GeekGrapher.FractalPainter.Commands;
using GeekGrapher.FractalPainter.EnumDefinitions;

namespace GeekGrapher.FractalPainter
{
    internal class FractalPainterViewModel
    {
        public FractalPainter Window { get; set; }

        public string CReal { get; set; } = "0";

        public string CImaginary { get; set; } = "0";

        public int MaxIterations { get; set; } = 50;

        public Dictionary<FractalFunction, string> FractalFunctions { get => FractalFunctionDefinitions.FractalFunctions; }

        public FractalFunction SelectedFractalFunction { get; set; } = FractalFunction.Shz;

        public Dictionary<ColorScheme, string> ColorSchemes { get => ColosSchemeDefinitions.ColorSchemes; }

        public ColorScheme SelectedColorScheme { get; set; } = ColorScheme.HSVBased;

        public FractalPainterViewModel(FractalPainter fractalPainter)
        {
            Window = fractalPainter;
        }
        #region Commands

        private ICommand _saveAsImage;

        public ICommand SaveAsImage
        {
            get
            {
                if (_saveAsImage == null)
                {
                    _saveAsImage = new SaveAsImage(this);
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
                    _close = new Close(this);
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
                    _exit = new Exit(this);
                }
                return _exit;
            }
        }

        private ICommand _draw;

        public ICommand Draw
        {
            get
            {
                if (_draw == null)
                {
                    _draw = new Draw(this);
                }
                return _draw;
            }
        }
        #endregion
    }
}
