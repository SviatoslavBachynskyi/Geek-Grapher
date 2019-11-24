using GeekGrapher.AffineTransformations.ViewModels;
using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public override void Execute(object parameter)
        {
            var plot = new Plot(ViewModel.Window.Canvas, new Point(10, 10), new Point(-10, -10));
            plot.Draw();
            plot.Draw(ViewModel.ToParallelogram());
            var angle = Convert.ToDouble(ViewModel.Rotation.Angle);
            if (ViewModel.Rotation.Direction == Direction.Right)
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

            var newParallelogram = ViewModel.ToParallelogram().Rotate(angle, center);
            newParallelogram.Fill = Colors.AliceBlue;
            plot.Draw(newParallelogram);
        }
    }
}
