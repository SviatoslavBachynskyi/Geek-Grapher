using GeekGrapher.AffineTransformations.ViewModels;
using GeekGrapher.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GeekGrapher.AffineTransformations.Commands
{
    class Draw : ChangableCommand
    {
        ParallelogramViewModel ViewModel { get; set; }
        public Draw(ParallelogramViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return ViewModel.AreVertexesValid();
        }

        public override void Execute(object parameter)
        {
            var plot = new Plot(ViewModel.Window.Canvas, new Point(11, 11), new Point(-11, -11));
            plot.Draw();
            plot.Draw(ViewModel.ToParallelogram(),"",true);
        }
    }
}
