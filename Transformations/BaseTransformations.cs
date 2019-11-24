using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Transformations
{
    public static class BaseTransformations
    {
        public static double[,] Move(double x, double y)
        {
            return new double[,]
            {

             { 1, 0,0 },
             { 0, 1,0 },
             { x, y,1}
            };
        }
        public static double[,] Rotate(double angle)
        {
            double radian = angle / 180 * Math.PI;
            return new double[,]
            {

             { Math.Cos(radian), Math.Sin(radian),0 },
             { Math.Sin(-radian), Math.Cos(radian),0 },
             { 0, 0,1}
            };
        }
    }
}
