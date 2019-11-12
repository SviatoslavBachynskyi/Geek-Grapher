using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

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
        }

        bool mouseDown = false; // Set to 'true' when mouse is held down.
        Point mouseDownPos;

        private void Selection_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Capture and track the mouse.
            mouseDown = true;
            mouseDownPos = e.GetPosition(Image);
            Image.CaptureMouse();

            // Initial placement of the drag selection box.         
            Canvas.SetLeft(selectionBox, mouseDownPos.X);
            Canvas.SetTop(selectionBox, mouseDownPos.Y);
            selectionBox.Width = 0;
            selectionBox.Height = 0;

            // Make the drag selection box visible.
            selectionBox.Visibility = Visibility.Visible;
        }

        private void Selection_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Release the mouse capture and stop tracking it.
            mouseDown = false;
            Image.ReleaseMouseCapture();

            // Hide the drag selection box.
            selectionBox.Visibility = Visibility.Collapsed;

            Point mouseUpPos = e.GetPosition(Image);
            mouseUpPos.X = Limit(mouseUpPos.X, 0, Image.ActualWidth);
            mouseUpPos.Y = Limit(mouseUpPos.Y, 0, Image.ActualHeight);


            var left = Math.Min(mouseUpPos.X, mouseDownPos.X);
            var top = Math.Min(mouseUpPos.Y, mouseDownPos.Y);
            var right = Math.Max(mouseUpPos.X, mouseDownPos.X);
            var bottom = Math.Max(mouseUpPos.Y, mouseDownPos.Y);

            var width = ViewModel.Drawer.XFinish - ViewModel.Drawer.XStart;
            var height = ViewModel.Drawer.YFinish - ViewModel.Drawer.YStart;

            ViewModel.Drawer.XStart += (left / Image.ActualWidth) * width;
            ViewModel.Drawer.XFinish -= ((Image.ActualWidth - right) / Image.ActualWidth) * width;
            ViewModel.Drawer.YStart += (top / Image.ActualHeight) * height;
            ViewModel.Drawer.YFinish -= ((Image.ActualHeight - bottom) / Image.ActualHeight) * height;

            ViewModel.Draw.Execute(null);

            // TODO: 
            //
            // The mouse has been released, check to see if any of the items 
            // in the other canvas are contained within mouseDownPos and 
            // mouseUpPos, for any that are, select them!
            //
        }

        private double Limit(double pos, double lowerBound, double upperBound)
        {
            if (pos < lowerBound) return lowerBound;
            if (pos > upperBound) return upperBound;
            return pos;
        }

        private void Selection_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                // When the mouse is held down, reposition the drag selection box.
                Point mousePos = e.GetPosition(Image);
                mousePos.X = Limit(mousePos.X, 0, Image.ActualWidth);
                mousePos.Y = Limit(mousePos.Y, 0, Image.ActualHeight);

                if (mouseDownPos.X < mousePos.X)
                {
                    Canvas.SetLeft(selectionBox, mouseDownPos.X);
                    selectionBox.Width = mousePos.X - mouseDownPos.X;
                }
                else
                {
                    Canvas.SetLeft(selectionBox, mousePos.X);
                    selectionBox.Width = mouseDownPos.X - mousePos.X;
                }

                if (mouseDownPos.Y < mousePos.Y)
                {
                    Canvas.SetTop(selectionBox, mouseDownPos.Y);
                    selectionBox.Height = mousePos.Y - mouseDownPos.Y;
                }
                else
                {
                    Canvas.SetTop(selectionBox, mousePos.Y);
                    selectionBox.Height = mouseDownPos.Y - mousePos.Y;
                }
            }
        }
    }
}
