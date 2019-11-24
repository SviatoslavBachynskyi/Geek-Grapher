using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Transformations
{
    public static class Transformations
    {
        private static double[] Transform(this double[] vector, List<double[,]> transformations)
        {
            foreach(var transformation in transformations)
            {
                vector = MatrixMultiply.Multiply(vector, transformation);
            }
            return vector;
        }
        private static double[] ToVector(this Point point)
        {
            return new double[3] {
                point.X, point.Y, 1
            };
        }
        private static Point ToPoint(this double[] vector)
        {
            return new Point(vector[0], vector[1]);
        }
        private static Parallelogram Transform(this Parallelogram parallelogram, List<double[,]> transformations)
        {
            parallelogram.A = (parallelogram.A.ToVector().Transform(transformations)).ToPoint();
            parallelogram.B = (parallelogram.B.ToVector().Transform(transformations)).ToPoint();
            parallelogram.C = (parallelogram.C.ToVector().Transform(transformations)).ToPoint();
            parallelogram.D = (parallelogram.D.ToVector().Transform(transformations)).ToPoint();
            return parallelogram;
        }
        public static Parallelogram Rotate(this Parallelogram parallelogram, double angle, Point center)
        {
            var transformations = new List<double[,]>()
            {
                BaseTransformations.Move(-center.X, -center.Y),
                BaseTransformations.Rotate(angle),
                BaseTransformations.Move(center.X, center.Y),
            };

            parallelogram.Transform(transformations);
            return parallelogram;
        }
    }
}
