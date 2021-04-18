using System;
using Measurement;

namespace _1._4._39
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
        /// <param name="repeatTimes">重复测试的次数。</param>
        /// <returns></returns>
        public static double TimeTrial(int n, int repeatTimes)
        {
            var a = new int[n];
            double sum = 0;
            var random = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < n; i++)
            {
                a[i] = random.Next(-MaximumInteger, MaximumInteger);
            }
            for (var i = 0; i < repeatTimes; i++)
            {
                var timer = new Stopwatch();
                ThreeSum.Count(a);
                sum += timer.ElapsedTime();
            }
            return sum / repeatTimes;
        }
    }
}
