using System;
using System.Collections.Generic;
using Sort;

namespace _2._1._37
{

    class Program
    {
        // 选择排序的性能只与数组大小有关，以上三种情况耗时都是近似的。
        // 插入排序的性能与逆序对数量有关，部分有序的情况下耗时会小于完全随机。
        // 希尔排序与插入排序类似。
        static void Main(string[] args)
        {
            var insertionSort = new InsertionSort();
            var selectionSort = new SelectionSort();
            var shellSort = new ShellSort();
            var n = 10000;
            var selectionArray = new int[n];
            var insertionArray = new int[n];
            var shellArray = new int[n];

            // 完全随机的对照
            Console.WriteLine(@"totally random");
            Console.WriteLine("Selection Sort:" + SortCompare.TimeRandomInput(selectionSort, n, 1));
            Console.WriteLine("Insertion Sort:" + SortCompare.TimeRandomInput(insertionSort, n, 1));
            Console.WriteLine("Shell Sort:" + SortCompare.TimeRandomInput(shellSort, n, 1));

            // 95% 有序，其余部分为随机值。
            selectionArray = Sorted95Random5(n);
            selectionArray.CopyTo(insertionArray, 0);
            selectionArray.CopyTo(shellArray, 0);

            Console.WriteLine(@"95% sorted + 5% random");
            Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, selectionArray));
            Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, insertionArray));
            Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, shellArray));

            // 所有元素和它们的正确位置的距离都不超过 10。
            selectionArray = RandomIn10(n);
            selectionArray.CopyTo(insertionArray, 0);
            selectionArray.CopyTo(shellArray, 0);

            Console.WriteLine(@"a sorted array that left shift 6 times");
            Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, selectionArray));
            Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, insertionArray));
            Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, shellArray));

            // 5% 的元素随机分布在整个数组中，剩下的数据都是有序的。
            selectionArray = RandomIn10(n);
            selectionArray.CopyTo(insertionArray, 0);
            selectionArray.CopyTo(shellArray, 0);

            Console.WriteLine(@"95% elements is sorted while 5% elements are placed randomly");
            Console.WriteLine("Selection Sort:" + SortCompare.Time(selectionSort, selectionArray));
            Console.WriteLine("Insertion Sort:" + SortCompare.Time(insertionSort, insertionArray));
            Console.WriteLine("Shell Sort:" + SortCompare.Time(shellSort, shellArray));
        }

        /// <summary>
        /// 生成 95% 有序，最后 5% 随机的 <see cref="int"/> 数组。
        /// </summary>
        /// <param name="n">数组的大小。</param>
        /// <returns>95% 有序，最后 5% 随机的 <see cref="int"/> 数组。</returns>
        static int[] Sorted95Random5(int n)
        {
            var array = new int[n];
            var randomStart = (int)(n * 0.05);
            var random = new Random();

            for (var i = 0; i < n - randomStart; i++)
            {
                array[i] = i;
            }

            for (var i = n - randomStart; i < n; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }

        /// <summary>
        /// 返回一个 <see cref="int"/> 数组，其中的每个元素和它的正确位置的距离都不超过 10。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>一个 <see cref="int"/> 数组，其中的每个元素和它的正确位置的距离都不超过 10。</returns>
        static int[] RandomIn10(int n)
        {
            var array = new Queue<int>();
            var random = new Random();

            for (var i = 0; i < n; i++)
            {
                array.Enqueue(i);
            }

            for (var i = 0; i < 6; i++)
            {
                array.Enqueue(array.Dequeue());
            }

            return array.ToArray();
        }

        /// <summary>
        /// 生成 5% 元素随机分布，剩余有序的 <see cref="int"/> 数组。
        /// </summary>
        /// <param name="n">需要生成的数组大小。</param>
        /// <returns>5% 元素随机分布，剩余有序的 <see cref="int"/> 数组。</returns>
        static int[] Shuffle5Percent(int n)
        {
            var random = new Random();
            var percent5 = (int)(n * 0.05);

            var randomIndex = new int[percent5];
            for (var i = 0; i < percent5; i++)
            {
                randomIndex[i] = random.Next(percent5);
            }

            var randomValue = new int[percent5];
            for (var i = 0; i < percent5; i++)
            {
                randomValue[i] = randomIndex[i];
            }
            Shuffle(randomValue);

            var array = new int[n];
            for (var i = 0; i < n; i++)
            {
                array[i] = i;
            }

            for (var i = 0; i < percent5; i++)
            {
                array[randomIndex[i]] = randomValue[i];
            }

            return array;
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <param name="a">需要打乱的数组。</param>
        static void Shuffle(int[] a)
        {
            var N = a.Length;
            var random = new Random();
            for (var i = 0; i < N; i++)
            {
                var r = i + random.Next(N - i);// 等于StdRandom.uniform(N-i)
                var temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}
