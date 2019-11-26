using GeekGrapher.AffineTransformations.ViewModels;
using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Transformations;

namespace GeekGrapher.AffineTransformations.Commands
{
    class Rotate : ChangableCommand
    {
        ParallelogramViewModel ViewModel { get; set; }
        public Rotate(ParallelogramViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }
        private bool IsInRange(Point point, double downLimit, double upLimit)
        {
            if (point.X < downLimit) return false;
            if (point.X > upLimit) return false;
            if (point.Y < downLimit) return false;
            if (point.Y > upLimit) return false;
            return true;
        }

        public override bool CanExecute(object parameter)
        {
            return ViewModel.IsFormValid();
        }

        public override void Execute(object parameter)
        {
            var task = new Task(
                () =>
                {
                    var Frames = 60;
                    var time = 2000;
                    var plot = new Plot(ViewModel.Window.Canvas, new Point(11, 11), new Point(-11, -11));
                    var ratio = Convert.ToDouble(ViewModel.Rotation.Ratio);
                    var angle = Convert.ToDouble(ViewModel.Rotation.Angle);
                    if (ViewModel.Rotation.Direction == Direction.Left)
                        angle *= -1;
                    Point center;

                    switch (ViewModel.Rotation.RotationVertex)
                    {
                        case RotationVertex.A:
                            center = ViewModel.A.ToPoint();
                            break;
                        case RotationVertex.B:
                            center = ViewModel.B.ToPoint();
                            break;
                        case RotationVertex.C:
                            center = ViewModel.C.ToPoint();
                            break;
                        case RotationVertex.D:
                            center = ViewModel.D.ToPoint();
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    plot.Draw();
                    for (int i = 1; i <= Frames; i++)
                    {
                        if (i == Frames)
                        {
                            var oldParallelogram = ViewModel.ToParallelogram();
                            oldParallelogram.Fill = Colors.AliceBlue;
                            plot.Draw(oldParallelogram, "'", false,true);
                        }

                        var newParallelogram = ViewModel.ToParallelogram().Rotate(angle * (i) / Frames, 1 + (ratio - 1) * (i) / Frames, center);
                        if (
                            !IsInRange(newParallelogram.A, -10, 10)
                            || !IsInRange(newParallelogram.B, -10, 10)
                            || !IsInRange(newParallelogram.C, -10, 10)
                            || !IsInRange(newParallelogram.D, -10, 10)
                            )
                        {
                            ViewModel.Window.Dispatcher.Invoke(() =>
                            {
                                ViewModel.Window.Canvas.Children.Clear();
                            });
                            MessageBox.Show("Parallelogram is out of limit, try setting lower ratio", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        plot.Draw(newParallelogram, "'", false, i != Frames);
                        Thread.Sleep(time / Frames);
                    }
                }
                );
            task.Start();
        }
    }
}
