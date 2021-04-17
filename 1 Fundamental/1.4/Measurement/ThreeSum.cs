using System;

namespace Measurement
{
    /// <summary>
    /// 用暴力方法寻找数组中和为零的三元组。
    /// </summary>
    public static class ThreeSum
    {
        /// <summary>
        /// 输出所有和为零的三元组。
        /// </summary>
        /// <param name="a">输入数组。</param>
        public static void PrintAll(int[] a)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    for (var k = j + 1; k < n; k++)
                    {
                        if ((long)a[i] + a[j] + a[k] == 0)
                        {
                            Console.WriteLine($@"{a[i]} + {a[j]} + {a[k]}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 计算和为零的三元组的数量。
        /// </summary>
        /// <param name="a">输入数组。</param>
        /// <returns>和为零的三元组的数量。</returns>
        public static int Count(int[] a)
        {
            var n = a.Length;
            var count = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    for (var k = j + 1; k < n; k++)
                    {
                        if ((long)a[i] + a[j] + a[k] == 0)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
