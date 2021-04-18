using System;
using Measurement;

namespace _1._4._37
{
    /// <summary>
    /// FixedCapacityStackOfInts 测试类。
    /// </summary>
    public static class DoubleTest
    {
        private static readonly int MaximumInteger = 1000000;

        /// <summary>
        /// 返回对 n 个随机整数的栈进行 n 次 push 和 n 次 pop 所需的时间。
        /// </summary>
        /// <param name="n">随机数组的长度。</param>
        /// <returns></returns>
        public static double TimeTrial(int n)
        {
            var a = new int[n];
            var stack = new FixedCapacityStackOfInts(n);
            var random = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < n; i++)
            {
                a[i] = random.Next(-MaximumInteger, MaximumInteger);
            }
            var timer = new Stopwatch();
            for (var i = 0; i < n; i++)
            {
                stack.Push(a[i]);
            }
            for (var i = 0; i < n; i++)
            {
                stack.Pop();
            }
            return timer.ElapsedTimeMillionSeconds();
        }

        /// <summary>
        /// 返回对 n 个随机整数的栈进行 n 次 push 和 n 次 pop 所需的时间。
        /// </summary>
        /// <param name="n">随机数组的长度。</param>
        /// <returns></returns>
        public static double TimeTrialGeneric(int n)
        {
            var a = new int[n];
            var stack = new FixedCapacityStack<int>(n);
            var random = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < n; i++)
            {
                a[i] = random.Next(-MaximumInteger, MaximumInteger);
            }
            var timer = new Stopwatch();
            for (var i = 0; i < n; i++)
            {
                stack.Push(a[i]);
            }
            for (var i = 0; i < n; i++)
            {
                stack.Pop();
            }
            return timer.ElapsedTimeMillionSeconds();
        }
    }
}
