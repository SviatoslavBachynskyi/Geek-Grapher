using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformations
{
    public class MatrixMultiply
    {
        public static double[] Multiply(double[] vector, double[,] matrix)
        {
            var result = new double[vector.Length];
            for (int i = 0; i < result.Length; i++)
            {
                var elem = 0.0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    elem += vector[j] * matrix[j, i];
                }
                result[i] = elem;
            }
            return result;
        }
    }
}
