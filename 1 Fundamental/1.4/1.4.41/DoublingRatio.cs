using System;
using Measurement;

namespace _1._4._41
{
    public delegate int Count(int[] a);
    static class DoublingRatio
    {
        /// <summary>
        /// 从指定字符串中读入按行分割的整型数据。
        /// </summary>
        /// <param name="inputString">源字符串。</param>
        /// <returns>读入的整型数组</returns>
        private static int[] ReadAllInts(string inputString)
        {
            var split = new char[1] { '\n' };
            var input = inputString.Split(split, StringSplitOptions.RemoveEmptyEntries);
            var a = new int[input.Length];
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(input[i]);
            }
            return a;
        }

        /// <summary>
        /// 使用给定的数组进行一次测试，返回耗时（毫秒）。
        /// </summary>
        /// <param name="count">要测试的方法。</param>
        /// <param name="a">测试用的数组。</param>
        /// <returns>耗时（秒）。</returns>
        public static double TimeTrial(Count count, int[] a)
        {
            var timer = new Stopwatch();
            count(a);
            return timer.ElapsedTimeMillionSeconds();
        }

        /// <summary>
        /// 对 TwoSum、TwoSumFast、ThreeSum 或 ThreeSumFast 的 Count 方法做测试。
        /// </summary>
        /// <param name="count">相应类的 Count 方法。</param>
        /// <returns>随着数据量倍增，方法耗时增加的比率。</returns>
        public static double Test(Count count)
        {
            double ratio = 0;
            double times = 3;

            // 1K
            var a = ReadAllInts(TestCase.Properties.Resources._1Kints);
            var prevTime = TimeTrial(count, a);
            Console.WriteLine(@"数据量	耗时	比值");
            Console.WriteLine($@"1000	{prevTime / 1000}	");

            // 2K
            a = ReadAllInts(TestCase.Properties.Resources._2Kints);
            var time = TimeTrial(count, a);
            Console.WriteLine($@"2000	{time / 1000}	{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            // 4K
            a = ReadAllInts(TestCase.Properties.Resources._4Kints);
            time = TimeTrial(count, a);
            Console.WriteLine($@"4000	{time / 1000}	{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            // 8K
            a = ReadAllInts(TestCase.Properties.Resources._8Kints);
            time = TimeTrial(count, a);
            Console.WriteLine($@"8000	{time / 1000}	{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            return ratio / times;
        }

        /// <summary>
        /// 对 TwoSumFast 的 Count 方法做测试。
        /// </summary>
        /// <param name="count">TwoSumFast 的 Count 方法</param>
        /// <returns>随着数据量倍增，方法耗时增加的比率。</returns>
        public static double TestTwoSumFast(Count count)
        {
            double ratio = 0;
            double times = 2;

            // 8K
            var a = ReadAllInts(TestCase.Properties.Resources._8Kints);
            var prevTime = TimeTrial(count, a);
            Console.WriteLine(@"数据量	耗时	比值");
            Console.WriteLine($@"8000	{prevTime / 1000}	");

            // 16K
            a = ReadAllInts(TestCase.Properties.Resources._16Kints);
            var time = TimeTrial(count, a);
            Console.WriteLine($@"16000	{time / 1000}	{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            // 32K
            a = ReadAllInts(TestCase.Properties.Resources._32Kints);
            time = TimeTrial(count, a);
            Console.WriteLine($@"32000	{time / 1000}	{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            return ratio / times;
        }
    }
}
