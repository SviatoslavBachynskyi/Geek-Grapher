using GeekGrapher.AffineTransformations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Transformations;

namespace GeekGrapher.AffineTransformations
{
    public class Plot
    {
        double Top { get; set; }
        double Left { get; set; }
        double Bottom { get; set; }
        double Right { get; set; }

        Point Center { get; set; }

        Canvas Canvas { get; set; }

        double xPixels { get; set; }
        double yPixels { get; set; }

        Point DownLimit { get; set; }

        public Plot(Canvas canvas, Point upLimit, Point downLimit)
        {
            Canvas = canvas;


            if (Canvas.ActualHeight < Canvas.ActualWidth)
            {
                var align = (Canvas.ActualWidth - Canvas.ActualHeight) / 2;
                Top = 0;
                Left = align;
                Bottom = Canvas.ActualHeight;
                Right = Canvas.ActualWidth - align;
                Center = new Point((Left + Right) / 2, (Top + Bottom) / 2);
            }

            xPixels = (Right - Left) / (upLimit.X - downLimit.X);
            yPixels = (Top - Bottom) / (upLimit.Y - downLimit.Y);
        }
        private List<Shape> DrawXAxe()
        {

            var axeStroke = Brushes.Black;
            var thickness = 2;
            var arrowWidth = 10;
            var arrowHeight = 10;

            var x = new Line()
            {
                Y1 = Center.Y,
                Y2 = Center.Y,
                X1 = Left,
                X2 = Right,
                Stroke = axeStroke,
                StrokeThickness = thickness
            };

            var arrow = new Polygon()
            {
                Fill = axeStroke,
                Points = new PointCollection() {
                    new Point(Right,Center.Y),
                    new Point(Right - arrowWidth, Center.Y - arrowHeight/2),
                    new Point(Right - arrowWidth, Center.Y + arrowHeight/2),
                }
            };

            return new List<Shape>()
            {
                  x, arrow
            };

        }

        private List<Shape> DrawYAxe()
        {
            var x = DrawXAxe();
            x.ForEach(
                (s) => s.RenderTransform = new RotateTransform(-90, Center.X,Center.Y)
                );
            return x;
        }
        public void Draw()
        {
            Canvas.Children.Clear();

            Canvas.Children.Add(DrawXAxe());
            Canvas.Children.Add(DrawYAxe());
        }

        private Point CalculateCoordinates(Point point)
        {
            point.X = Center.X + point.X* xPixels;
            point.Y= Center.Y + point.Y * yPixels;
            return point;
        }

        public void Draw(Parallelogram parallelogram)
        {
            var parallelogramShape = new Polygon()
            {
                Stroke = new SolidColorBrush(parallelogram.Stroke),
                Fill = new SolidColorBrush(parallelogram.Fill),
                Points = new PointCollection() {
                    CalculateCoordinates(parallelogram.A),
                    CalculateCoordinates(parallelogram.B),
                    CalculateCoordinates(parallelogram.C),
                    CalculateCoordinates(parallelogram.D),
                }
            };
            Canvas.Children.Add(parallelogramShape);
        }
    }
}

internal static class PlotExtensions{
    public static UIElementCollection Add(this UIElementCollection collection, IEnumerable<UIElement> elements)
    {
        foreach(var element in elements)
        {
            collection.Add(element);
        }
        return collection;
    }
    }
