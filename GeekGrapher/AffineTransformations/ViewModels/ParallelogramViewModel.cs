using GeekGrapher.AffineTransformations.Commands;
using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Transformations;

namespace GeekGrapher.AffineTransformations.ViewModels
{
    public class ParallelogramViewModel : BaseViewModel
    {
        public AffineTransformations Window { get; set; }

        public ParallelogramViewModel(AffineTransformations window)
        {
            this.Window = window;
            A = new VertexViewModel()
            {
                X = "1",
                Y = "1"
            };
            B =
            new VertexViewModel()
            {
                X = "2",
                Y = "3"
            };
            C = new VertexViewModel()
            {
                X = "5",
                Y = "3"
            };
            D = new VertexViewModel();

            Rotation = new RotationViewModel(this)
            {
                Ratio = "1",
                Angle = "45"
            };

            Style = new StyleViewModel()
            {
                LineColor = Color.FromRgb(0, 0, 0),
                FillColor = Color.FromRgb(0, 0, 255)
            };
            CalculateVertexes();
        }
        public bool AreVertexesValid()
        {
            //TODO Add all groups
            if ((Window.A?.BindingGroup?.HasValidationError ?? true || A == null)
                || (Window.B?.BindingGroup?.HasValidationError ?? true || B == null)
                || (Window.C?.BindingGroup?.HasValidationError ?? true || C == null)
                || D == null)
                return false;

            if (Convert.ToDouble(D.X) < -10 || Convert.ToDouble(D.X) > 10
                || Convert.ToDouble(D.Y) < -10 || Convert.ToDouble(D.Y) > 10)
            {
                DError = "Coordinates must be in range -10, 10";
                return false;
            }
            Point a = A.ToPoint();
            Point b = B.ToPoint();
            Point d = D.ToPoint();
            if (ParallelogramArea(a, b, d) == 0)
            {
                Error = "Parallelogram area cannot equal 0";
                return false;
            }

            Error = "";
            return true;
        }
        private double ParallelogramArea(Point a, Point b, Point d)
        {
            Vector ab = b - a;
            Vector ad = d - a;
            var angle = Vector.AngleBetween(ab, ad);
            return ab.Length * ad.Length * Math.Sin(angle);
        }
        private void CalculateVertexes()
        {
            try
            {
                var ax = Convert.ToDouble(A.X);
                var bx = Convert.ToDouble(B.X);
                var cx = Convert.ToDouble(C.X);
                var ay = Convert.ToDouble(A.Y);
                var by = Convert.ToDouble(B.Y);
                var cy = Convert.ToDouble(C.Y);
                D.X = (ax + cx - bx).ToString();
                D.Y = (ay + cy - by).ToString();
                AreVertexesValid();
            }
            catch (FormatException)
            {
            }
            catch (NullReferenceException)
            {
            }
        }

        private string _error = "";

        public string Error
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        private string _dError = "";

        public string DError
        {
            get => _dError;
            set
            {
                _dError = value;
                OnPropertyChanged(nameof(DError));
            }
        }

        private VertexViewModel _a;
        public VertexViewModel A
        {
            get => _a;
            set
            {
                if (_a != null)
                {
                    _a.PropertyChanged -= VertexChanged;
                }

                _a = value;

                if (_a != null)
                    _a.PropertyChanged += VertexChanged;

                OnPropertyChanged(nameof(A));
                CalculateVertexes();
                void VertexChanged(object sender, PropertyChangedEventArgs args)
                {
                    OnPropertyChanged(nameof(A));
                    CalculateVertexes();
                }
            }
        }

        private VertexViewModel _b;
        public VertexViewModel B
        {
            get => _b;
            set
            {
                if (_b != null)
                {
                    _b.PropertyChanged -= VertexChanged;
                }

                _b = value;

                if (_b != null)
                    _b.PropertyChanged += VertexChanged;

                OnPropertyChanged(nameof(B));
                CalculateVertexes();
                void VertexChanged(object sender, PropertyChangedEventArgs args)
                {
                    OnPropertyChanged(nameof(B));
                    CalculateVertexes();
                }
            }
        }
        private VertexViewModel _c;
        public VertexViewModel C
        {
            get => _c;
            set
            {
                if (_c != null)
                {
                    _c.PropertyChanged -= VertexChanged;
                }

                _c = value;

                if (_c != null)
                    _c.PropertyChanged += VertexChanged;

                OnPropertyChanged(nameof(C));
                CalculateVertexes();
                void VertexChanged(object sender, PropertyChangedEventArgs args)
                {
                    OnPropertyChanged(nameof(C));
                    CalculateVertexes();
                }
            }
        }

        private VertexViewModel _d;
        public VertexViewModel D
        {
            get => _d;
            set
            {
                if (_d != null)
                {
                    _d.PropertyChanged -= VertexChanged;
                }

                _d = value;

                if (_d != null)
                    _d.PropertyChanged += VertexChanged;

                OnPropertyChanged(nameof(D));
                void VertexChanged(object sender, PropertyChangedEventArgs args)
                {
                    OnPropertyChanged(nameof(D));
                }
            }
        }


        public Parallelogram ToParallelogram()
        {
            return new Parallelogram()
            {
                A = A.ToPoint(),
                B = B.ToPoint(),
                C = C.ToPoint(),
                D = D.ToPoint(),
                Fill = Style.FillColor,
                Stroke = Style.LineColor
            };
        }

        public ICommand Draw { get => new Draw(this); }

        public RotationViewModel Rotation { get; set; }
        public StyleViewModel Style { get; set; }

    }
}
