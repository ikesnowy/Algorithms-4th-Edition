using System;

namespace Measurement
{
    /// <summary>
    /// ThreeSum 测试类。
    /// </summary>
    public static class DoubleTest
    {
        private static readonly int MaximumInteger = 1000000;

        /// <summary>
        /// 返回对 n 个随机整数的数组进行一次 ThreeSum 所需的时间。
        /// </summary>
        /// <param name="n">随机数组的长度。</param>
        /// <returns>运行时间，单位为毫秒。</returns>
        public static double TimeTrial(int n)
        {
            var a = new int[n];
            var random = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < n; i++)
            {
                a[i] = random.Next(-MaximumInteger, MaximumInteger);
            }
            var timer = new Stopwatch();
            ThreeSum.Count(a);
            return timer.ElapsedTime();
        }
    }
}
