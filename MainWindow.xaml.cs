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

namespace GeekGrapher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            new Settings().ShowDialog();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            new UserManual().Show();
        }

        private void AffineTransformations_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AffineTransformations().Show();
            this.Close();
        }

        private void FractalPainter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new FractalPainter().Show();
            this.Close();
        }

        private void ImageConverter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new ImageConverter().Show();
            this.Close();
        }
    }
}
