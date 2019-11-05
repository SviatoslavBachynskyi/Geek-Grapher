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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeekGrapher.Main;

namespace GeekGrapher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        internal MainViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                this.DataContext = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainViewModel(this);
        }

        private void AffineTransformations_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel.OpenAffineTransformations.CanExecute(null))
            {
                ViewModel.OpenAffineTransformations.Execute(null);
            }
        }

        private void FractalPainter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel.OpenFractalPainter.CanExecute(null))
            {
                ViewModel.OpenFractalPainter.Execute(null);
            }
        }

        private void ImageConverter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel.OpenImageConverter.CanExecute(null))
            {
                ViewModel.OpenImageConverter.Execute(null);
            }
        }
    }
}
