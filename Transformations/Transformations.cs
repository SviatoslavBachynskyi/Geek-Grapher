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
        public static Parallelogram Transform(this Parallelogram parallelogram, double[,] transformation)
        {
            parallelogram.A = (parallelogram.A.ToVector().Transform(transformation)).ToPoint();
            parallelogram.B = (parallelogram.B.ToVector().Transform(transformation)).ToPoint();
            parallelogram.C = (parallelogram.C.ToVector().Transform(transformation)).ToPoint();
            parallelogram.D = (parallelogram.D.ToVector().Transform(transformation)).ToPoint();
            return parallelogram;
        }

        public static double[] Transform(this double[] vector, double[,] transformation)
        {
            return MatrixMultiply.Multiply(vector, transformation);
        }

        private static double[,] Multiply(this List<double[,]> transformations)
        {
            return transformations.Aggregate((a, b) => a = MatrixMultiply.Multiply(a, b));
        }
        public static double[,] RotateTransformation(double angle, double k, Point center)
        {
            var transformations = new List<double[,]>()
            {
                BaseTransformations.Move(-center.X, -center.Y),
                BaseTransformations.Rotate(angle),
                BaseTransformations.Scale(k,k),
                BaseTransformations.Move(center.X, center.Y),
            };

            return transformations.Multiply();
        }
    }
}
