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

namespace GeekGrapher.ImageConverter
{
    /// <summary>
    /// Interaction logic for ImageConverter.xaml
    /// </summary>
    public partial class ImageConverter : Window
    {
        private ImageConverterViewModel _viewModel;
        public ImageConverterViewModel ViewModel { get => _viewModel; set
            {
                _viewModel = value;
                DataContext = value;
            }
        }
        public ImageConverter()
        {
            InitializeComponent();
            ViewModel = new ImageConverterViewModel();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
           var position =  e.GetPosition((IInputElement)sender);
        }
    }
}
