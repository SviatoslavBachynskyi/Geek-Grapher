using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using GeekGrapher.FractalCore;
using GeekGrapher.FractalPainter.Commands;
using GeekGrapher.FractalPainter.EnumDefinitions;
using GeekGrapher.General;
using GeekGrapher.General.Commands;

namespace GeekGrapher.FractalPainter
{
    internal class FractalPainterViewModel : BaseViewModel
    {
        public FractalPainter Window { get; set; }

        public string CReal { get; set; } = "0";

        public string CImaginary { get; set; } = "0";

        public string MaxIterations { get; set; } = "50";

        public Dictionary<FractalFunction, string> FractalFunctions { get => FractalFunctionDefinitions.FractalFunctions; }

        public FractalFunction SelectedFractalFunction { get; set; } = FractalFunction.Shz;

        public Dictionary<ColorScheme, string> ColorSchemes { get => ColosSchemeDefinitions.ColorSchemes; }

        public ColorScheme _colorScheme = ColorScheme.HSVBased;
        public ColorScheme SelectedColorScheme
        {
            get
            {
                return _colorScheme;
            }
            set
            {
                _colorScheme = value;
                OnPropertyChanged(nameof(SelectedColorScheme));
            }
        }

        public string colorCount = "3";
        public string ColorCount
        {
            get => colorCount;
            set
            {
                colorCount = value;
                OnPropertyChanged(nameof(ColorCount));
                OnPropertyChanged(nameof(Palette));
            }
        }

        public ColorWrapper[] Palette
        {
            get
            {
                if (Window.ColorCount.BindingGroup.HasValidationError)
                    return null;
                return _palette.Take(Convert.ToInt32(ColorCount)).ToArray();
            }
        }

        public ColorWrapper[] _palette;

        public int MaxColors { get => 50; }

        public FractalPainterViewModel()
        {
            var random = new Random((int)DateTime.Now.ToBinary());
            _palette = new ColorWrapper[MaxColors];
            for (int i = 0; i < MaxColors; i++)
            {
                _palette[i] = new ColorWrapper()
                {
                    Value = Color.FromRgb((byte)random.Next(), (byte)random.Next(), (byte)random.Next())
                };
            }
        }

        public List<Frame> Frames { get; set; } = new List<Frame>();
        public int FrameIndex = 0;

        public Drawer Drawer { get; set; }

        public FractalPainterViewModel(FractalPainter fractalPainter)
            : this()
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

        private ICommand _undo;
        public ICommand Undo
        {
            get
            {
                if (_undo == null)
                {
                    _undo = new Undo(this);
                }
                return _undo;
            }
        }

        private ICommand _redo;
        public ICommand Redo
        {
            get
            {
                if (_redo == null)
                {
                    _redo = new Redo(this);
                }
                return _redo;
            }
        }

        private ICommand _drawAndCreate;
        public ICommand DrawAndCreate
        {
            get
            {
                if (_drawAndCreate == null)
                {
                    _drawAndCreate = new DrawAndCreate(this);
                }
                return _drawAndCreate;
            }
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
        #endregion
    }
}
