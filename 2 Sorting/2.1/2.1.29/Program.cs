using System;
using System.Diagnostics;

namespace _2._1._29
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] h1 = { 1, 5, 19, 41, 109, 209, 505, 929, 2161, 3905, 8929, 16001, 36289, 64769, 146305, 260609 };
            var h2 = new int[h1.Length];

            var hTemp = 1;
            for (var i = 0; i < h1.Length; i++)
            {          
                h2[i] = hTemp;
                hTemp = hTemp * 3 + 1;
            }

            var n = 512;
            var shellSort = new ShellSort();
            var timer = new Stopwatch();

            int[] array1, array2;

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("array size:" + n);
                array1 = GetRandomInput(n);
                array2 = new int[n];
                array1.CopyTo(array2, 0);

                Console.Write(@"	new sequence");
                timer.Restart();
                shellSort.Sort(array1, h1);
                Console.WriteLine("\ttime:" + timer.ElapsedMilliseconds);

                Console.Write(@"	origin sequence");
                timer.Restart();
                shellSort.Sort(array2, h2);
                Console.WriteLine("\ttime:" + timer.ElapsedMilliseconds);

                n *= 2;
            }
        }

        /// <summary>
        /// 获取一个随机整数数组。
        /// </summary>
        /// <param name="n">随机整数数组的大小。</param>
        /// <returns>随机整数数组。</returns>
        static int[] GetRandomInput(int n)
        {
            var random = new Random();
            var array = new int[n];

            for (var i = 0; i < n; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }
    }
}
