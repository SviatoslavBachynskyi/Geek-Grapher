using GeekGrapher.AffineTransformations.ViewModels;
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

namespace GeekGrapher.AffineTransformations
{
    /// <summary>
    /// Interaction logic for AffineTransformation.xaml
    /// </summary>
    public partial class AffineTransformations : Window
    {
        private ParallelogramViewModel _viewModel;
        public ParallelogramViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = value;
            }
        }
        public AffineTransformations()
        {
            InitializeComponent();

            ViewModel = new ParallelogramViewModel(this);
           
        }
    }
}
