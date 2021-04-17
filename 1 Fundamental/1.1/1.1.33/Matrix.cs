using System;

namespace _1._1._33
{
    public class Matrix
    {
        /// <summary>
        /// 计算两个向量的点积。
        /// </summary>
        /// <param name="x">需要点乘的向量。</param>
        /// <param name="y">需要点乘的另一个向量。</param>
        /// <returns>返回点乘的结果。</returns>
        /// <exception cref="FormatException"></exception>
        public static double Dot(double[] x, double[] y)
        {
            // 确保两向量等长
            if (x.Length != y.Length)
            {
                throw new FormatException("the length of two vectors must be equal");
            }

            // 点乘
            double result = 0;
            for (var i = 0; i < x.Length; i++)
            {
                result += x[i] * y[i];
            }

            return result;
        }

        /// <summary>
        /// 计算两个矩阵相乘的结果，返回一个矩阵。
        /// </summary>
        /// <param name="a">用交错数组表示的 m * p 矩阵。</param>
        /// <param name="b">用交错数组表示的 p * n 矩阵。</param>
        /// <returns>返回 m * n 的矩阵。</returns>
        /// <exception cref="FormatException"></exception>
        /// <example>
        ///     a = {(1,2,3),(4,5,6)}
        ///     b = {(1,4),(2,5),(3,6)}
        ///     Mult(a, b) = {(14,32),(32,77)}
        /// </example>
        public static double[][] Mult(double[][] a, double[][] b)
        {
            if (a[0].Length != b.GetLength(0))
            {
                throw new FormatException("a's column number must be equal to b's row number");
            }

            var m = a.GetLength(0);
            var n = b[0].Length;
            var p = a[0].Length;

            var result = new double[m][];

            for (var i = 0; i < m; i++)
            {
                var resultrow = new double[n];
                for (var j = 0; j < n; j++)
                {
                    // result[i][j] = 行向量 a[i] 与列向量 b[j] 的点积
                    var row = a[i];
                    var col = new double[p];
                    // 取得列向量
                    for (var k = 0; k < p; k++)
                    {
                        col[k] = b[k][j];
                    }
                    // 点积
                    resultrow[j] = Dot(row, col);
                }
                result[i] = resultrow;
            }
            return result;
        }

        /// <summary>
        /// 将一个矩阵转置。
        /// </summary>
        /// <param name="a">待转置的矩阵。</param>
        /// <returns>返回转置后的数组。</returns>
        public static double[][] Transpose(double[][] a)
        {
            var trans = new double[a[0].Length][];
            for (var i = 0; i < a[0].Length; i++)
            {
                var row = new double[a.GetLength(0)];
                for (var j = 0; j < a.GetLength(0); j++)
                {
                    row[j] = a[j][i];
                }
                trans[i] = row;
            }
            return trans;
        }

        /// <summary>
        /// 计算矩阵与向量的乘积。
        /// </summary>
        /// <param name="a">左乘的矩阵。</param>
        /// <param name="x">列向量。</param>
        /// <returns>返回一个向量。</returns>
        /// <exception cref="FormatException"></exception>
        public static double[] Mult(double[][] a, double[] x)
        {
            if (a[0].Length != x.Length)
            {
                throw new FormatException("a's column number must be equal to x's length");
            }

            var result = new double[a.GetLength(0)];

            for (var i = 0; i < a.GetLength(0); i++)
            {
                result[i] = Dot(a[i], x);
            }

            return result;
        }

        /// <summary>
        /// 计算向量与矩阵的乘积。
        /// </summary>
        /// <param name="x">行向量。</param>
        /// <param name="a">矩阵。</param>
        /// <returns>返回一个向量。</returns>
        /// <exception cref="FormatException"></exception>
        public static double[] Mult(double[] x, double[][] a)
        {
            if (a.GetLength(0) != x.Length)
            {
                throw new FormatException("a's column number must be equal to x's length");
            }

            var result = new double[a[0].Length];

            for (var i = 0; i < a[0].Length; i++)
            {
                var colVector = new double[a.GetLength(0)];
                for (var j = 0; j < colVector.Length; j++)
                {
                    colVector[j] = a[j][i];
                }
                result[i] = Dot(x, colVector);
            }

            return result;
        }

        /// <summary>
        /// 在控制台上输出矩阵。
        /// </summary>
        /// <param name="a">需要输出的矩阵。</param>
        public static void PrintMatrix(double[][] a)
        {
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a[i].Length; j++)
                {
                    Console.Write($@"	{a[i][j]}");
                }
                Console.Write(@"
");
            }
        }

        /// <summary>
        /// 在控制台上输出一行向量。
        /// </summary>
        /// <param name="a">需要输出的向量。</param>
        public static void PrintVector(double[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                Console.Write($@"	{a[i]}");
            }
            Console.Write(@"
");
        }
    }
}
