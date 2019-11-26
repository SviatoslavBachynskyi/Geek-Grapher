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
        public static double[,] Multiply(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new ArgumentException("Matrix cannot be multiplied");
            var result = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {

                var elem = 0.0;
                for (int k = 0; k < b.GetLength(0); k++)
                {
                    elem += a[i,k] * b[k, j];
                }
                result[i,j] = elem;
                }
            }
            return result;
        }
    }
}
