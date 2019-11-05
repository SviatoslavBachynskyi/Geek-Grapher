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
using GeekGrapher.Fractals;

namespace GeekGrapher
{
    /// <summary>
    /// Interaction logic for FractalPainter.xaml
    /// </summary>
    public partial class FractalPainter : Window
    {
        private FractalViewModel _viewModel;
        internal FractalViewModel ViewModel
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

            ViewModel = new FractalViewModel(this);
        }
    }
}
