using System;
// ReSharper disable CognitiveComplexity

namespace _1._4._38
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
                for (var j = 0; j < n; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        if (i < j && j < k)
                        {
                            if ((long)a[i] + a[j] + a[k] == 0)
                            {
                                Console.WriteLine($@"{a[i]} + {a[j]} + {a[k]}");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 计算和为零的三元组的数量。
        /// </summary>
        /// <param name="a">输入数组。</param>
        /// <returns></returns>
        public static int Count(int[] a)
        {
            var n = a.Length;
            var count = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        if (i < j && j < k)
                        {
                            if ((long)a[i] + a[j] + a[k] == 0)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }
    }
}
