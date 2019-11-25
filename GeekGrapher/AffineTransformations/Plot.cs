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

        Canvas CanvasObj { get; set; }

        double xPixels { get; set; }
        double yPixels { get; set; }

        Point DownLimit { get; set; }
        Point UpLimit { get; set; }

        public Plot(Canvas canvas, Point upLimit, Point downLimit)
        {
            CanvasObj = canvas;
            UpLimit = upLimit;
            DownLimit = downLimit;

            if (CanvasObj.ActualHeight < CanvasObj.ActualWidth)
            {
                var align = (CanvasObj.ActualWidth - CanvasObj.ActualHeight) / 2;
                Top = 0;
                Left = align;
                Bottom = CanvasObj.ActualHeight;
                Right = CanvasObj.ActualWidth - align;
                Center = new Point((Left + Right) / 2, (Top + Bottom) / 2);
            }

            xPixels = (Right - Left) / (upLimit.X - downLimit.X);
            yPixels = (Top - Bottom) / (upLimit.Y - downLimit.Y);
        }
        private List<Shape> DrawXArrow()
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

        private List<Shape> DrawYArrow()
        {
            var x = DrawXArrow();
            x.ForEach(
                (s) => s.RenderTransform = new RotateTransform(-90, Center.X, Center.Y)
                );
            return x;
        }

        private void DrawXAxe()
        {
            CanvasObj.Children.Add(DrawXArrow());
            CanvasObj.Children.Add(DrawXLabel());
            for (double x = DownLimit.X + 1; x < UpLimit.X; x++)
            {
                if (x == 0) continue;
                var textBlock = new TextBlock();
                textBlock.Text = x.ToString("F0");
                textBlock.FontSize = 14;
                textBlock.Foreground = Brushes.Black;
                var xPos = Center.X + x * xPixels;
                Canvas.SetLeft(textBlock, xPos - 10);
                Canvas.SetTop(textBlock, Center.Y);
                var line = new Line()
                {
                    X1 = xPos,
                    X2 = xPos,
                    Y1 = Top,
                    Y2 = Bottom,
                    Stroke = Brushes.Gray
                };
                CanvasObj.Children.Add(textBlock);
                CanvasObj.Children.Add(line);
            }
        }
        public List<UIElement> DrawXLabel()
        {
            var textBlock = new TextBlock();
            textBlock.Text = "x";

            textBlock.FontSize = 20;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, Right - 10);
            Canvas.SetTop(textBlock, Center.Y);

            return new List<UIElement>()
            {
                textBlock
            };
        }

        private void DrawYAxe()
        {
            CanvasObj.Children.Add(DrawYArrow());
            CanvasObj.Children.Add(DrawYLabel());
            for (double y = DownLimit.Y + 1; y < UpLimit.Y; y++)
            {
                if (y == 0) continue;
                var textBlock = new TextBlock();
                textBlock.Text = y.ToString("F0");
                textBlock.FontSize = 14;
                textBlock.Foreground = Brushes.Black;
                Canvas.SetLeft(textBlock, Center.X + 5);
                var yPos = Center.Y + y * yPixels;
                Canvas.SetTop(textBlock, yPos - 10);
                var line = new Line()
                {
                    X1 = Left,
                    X2 = Right,
                    Y1 = yPos,
                    Y2 = yPos,
                    Stroke = Brushes.Gray
                };
                CanvasObj.Children.Add(textBlock);
                CanvasObj.Children.Add(line);
            }
        }
        public List<UIElement> DrawYLabel()
        {
            var textBlock = new TextBlock();
            textBlock.Text = "y";

            textBlock.FontSize = 20;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, Center.X - 15);
            Canvas.SetTop(textBlock, Top - 10);

            return new List<UIElement>()
            {
                textBlock
            };
        }
        public void Draw()
        {
            CanvasObj.Children.Clear();
            DrawXAxe();
            DrawYAxe();
        }

        private Point CalculateCoordinates(Point point)
        {
            point.X = Center.X + point.X * xPixels;
            point.Y = Center.Y + point.Y * yPixels;
            return point;
        }

        private static Size ShapeMeasure(TextBlock tb)
        {
            // Measured Size is bounded to be less than maxSize
            Size maxSize = new Size(
                 double.PositiveInfinity,
                 double.PositiveInfinity);
            tb.Measure(maxSize);
            return tb.DesiredSize;
        }
        public TextBlock DrawText(string text, Point point, bool up = true)
        {
            var textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize = 15;
            textBlock.FontWeight = FontWeights.Bold;
            textBlock.Foreground = Brushes.Black;
            var size = ShapeMeasure(textBlock);
            Canvas.SetLeft(textBlock, point.X - size.Width / 2);
            if (up)
            {
                Canvas.SetTop(textBlock, point.Y - size.Height);
            }
            else
            {
                Canvas.SetTop(textBlock, point.Y);
            }

            return textBlock;
        }

        public TextBlock CalculateText(string text, Point fst, Point snd, Point real)
        {
            return DrawText(text + $"({fst.X.ToString("F2")}, {fst.Y.ToString("F2")})", real, fst.Y > snd.Y);
        }

        public void Draw(Parallelogram parallelogram, string add = "", bool displayLabels = false)
        {
            Point a = CalculateCoordinates(parallelogram.A),
                b = CalculateCoordinates(parallelogram.B),
                c = CalculateCoordinates(parallelogram.C),
                d = CalculateCoordinates(parallelogram.D);
            var parallelogramShape = new Polygon()
            {
                Stroke = new SolidColorBrush(parallelogram.Stroke),
                Fill = new SolidColorBrush(parallelogram.Fill),
                Points = new PointCollection() {
                    a,
                    b,
                    c,
                    d,
                }
            };
            CanvasObj.Children.Add(parallelogramShape);
            if (displayLabels)
            {
                CanvasObj.Children.Add(CalculateText("A" + add, parallelogram.A, parallelogram.C, a));
                CanvasObj.Children.Add(CalculateText("B" + add, parallelogram.B, parallelogram.D, b));
                CanvasObj.Children.Add(CalculateText("C" + add, parallelogram.C, parallelogram.A, c));
                CanvasObj.Children.Add(CalculateText("D" + add, parallelogram.D, parallelogram.B, d));
            }
        }
    }
}

internal static class PlotExtensions
{
    public static UIElementCollection Add(this UIElementCollection collection, IEnumerable<UIElement> elements)
    {
        foreach (var element in elements)
        {
            collection.Add(element);
        }
        return collection;
    }
}
