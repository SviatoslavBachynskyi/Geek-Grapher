using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GeekGrapher.FractalCore;

namespace GeekGrapher.FractalPainter
{
    /// <summary>
    /// Interaction logic for FractalPainter.xaml
    /// </summary>
    public partial class FractalPainter : Window
    {
        private FractalPainterViewModel _viewModel;
        internal FractalPainterViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                this.DataContext = value;
            }
        }

        public FractalPainter()
        {
            InitializeComponent();

            ViewModel = new FractalPainterViewModel(this);

            var drawer = new Drawer((z, c) => z * z + c);

        }
    }
}
