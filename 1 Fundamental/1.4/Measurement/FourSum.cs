using System;
// ReSharper disable CognitiveComplexity

namespace Measurement
{
    /// <summary>
    /// 用暴力方法查找数组中和为零的四元组。
    /// </summary>
    public static class FourSum
    {
        /// <summary>
        /// 输出数组中所有和为 0 的四元组。
        /// </summary>
        /// <param name="a">包含所有元素的数组。</param>
        public static void PrintAll(long[] a)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    for (var k = j + 1; k < n; k++)
                    {
                        for (var l = k + 1; l < n; l++)
                        {
                            if (a[i] + a[j] + a[k] + a[l] == 0)
                            {
                                Console.WriteLine($@"{a[i]} + {a[j]} + {a[k]} + {a[l]} = 0");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 计算和为零的四元组的数量。
        /// </summary>
        /// <param name="a">包含所有元素的数组。</param>
        /// <returns>和为零的四元组的数量。</returns>
        public static int Count(long[] a)
        {
            var n = a.Length;
            var cnt = 0;

            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    for (var k = j + 1; k < n; k++)
                    {
                        for (var l = k + 1; l < n; l++)
                        {
                            if (a[i] + a[j] + a[k] + a[l] == 0)
                            {
                                cnt++;
                            }
                        }
                    }
                }
            }

            return cnt;
        }
    }
}
