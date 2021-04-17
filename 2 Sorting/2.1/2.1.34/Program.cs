using System;
using Sort;

namespace _2._1._34
{
    class Program
    {
        static void Main(string[] args)
        {
            var insertionSort = new InsertionSort();
            var selectionSort = new SelectionSort();
            var shellSort = new ShellSort();

            // 逆序
            Console.WriteLine(@"逆序");
            Console.WriteLine("Insertion Sort Time: " + ReverseSortTest(insertionSort));
            Console.WriteLine("Selection Sort Time: " + ReverseSortTest(selectionSort));
            Console.WriteLine("Shell Sort Time: " + ReverseSortTest(shellSort));

            // 顺序
            Console.WriteLine(@"顺序");
            Console.WriteLine("Insertion Sort Time: " + SortedSortTest(insertionSort));
            Console.WriteLine("Selection Sort Time: " + SortedSortTest(selectionSort));
            Console.WriteLine("Shell Sort Time: " + SortedSortTest(shellSort));

            // 主键相同
            Console.WriteLine(@"主键相同");
            Console.WriteLine("Insertion Sort Time: " + EqualSortTest(insertionSort));
            Console.WriteLine("Selection Sort Time: " + EqualSortTest(selectionSort));
            Console.WriteLine("Shell Sort Time: " + EqualSortTest(shellSort));

            // 二元数组
            Console.WriteLine(@"二元数组");
            Console.WriteLine("Insertion Sort Time: " + BinarySortTest(insertionSort));
            Console.WriteLine("Selection Sort Time: " + BinarySortTest(selectionSort));
            Console.WriteLine("Shell Sort Time: " + BinarySortTest(shellSort));

            // 空数组
            Console.WriteLine(@"空数组");
            Console.WriteLine("Insertion Sort Time: " + ZeroArraySizeSort(insertionSort));
            Console.WriteLine("Selection Sort Time: " + ZeroArraySizeSort(selectionSort));
            Console.WriteLine("Shell Sort Time: " + ZeroArraySizeSort(shellSort));

            // 只有一个元素的数组
            Console.WriteLine(@"只有一个元素的数组");
            Console.WriteLine("Insertion Sort Time: " + OneArraySizeSort(insertionSort));
            Console.WriteLine("Selection Sort Time: " + OneArraySizeSort(selectionSort));
            Console.WriteLine("Shell Sort Time: " + OneArraySizeSort(shellSort));
        }

        /// <summary>
        /// 构造逆序数组并用其对指定输入算法进行测试。
        /// </summary>
        /// <param name="sort">需要做测试的算法。</param>
        /// <returns>算法耗时。</returns>
        static double ReverseSortTest(BaseSort sort)
        {
            var array = new int[10000];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = array.Length - i;
            }

            return SortCompare.Time(sort, array);
        }

        /// <summary>
        /// 构造已排序的数组并用其对指定排序算法测试。
        /// </summary>
        /// <param name="sort">需要做测试的排序算法。</param>
        /// <returns>算法的耗时。</returns>
        static double SortedSortTest(BaseSort sort)
        {
            return SortCompare.TimeSortedInput(sort, 10000, 1);
        }

        /// <summary>
        /// 构造只有一个值的数组并用其对指定排序算法做测试。
        /// </summary>
        /// <param name="sort">需要做测试的排序算法。</param>
        /// <returns>算法的耗时。</returns>
        static double EqualSortTest(BaseSort sort)
        {
            var array = new int[10000];
            var random = new Random();
            var num = random.Next();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = num;
            }

            return SortCompare.Time(sort, array);
        }

        /// <summary>
        /// 构造只有两种取值的数组并用其对指定排序算法做测试。
        /// </summary>
        /// <param name="sort">需要做测试的排序算法。</param>
        /// <returns>排序算法的耗时。</returns>
        static double BinarySortTest(BaseSort sort)
        {
            var array = new int[10000];
            var random = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(2);
            }

            return SortCompare.Time(sort, array);
        }

        /// <summary>
        /// 构造空数组并用其对指定排序算法做测试。
        /// </summary>
        /// <param name="sort">需要做测试的排序算法。</param>
        /// <returns>排序算法的耗时。</returns>
        static double ZeroArraySizeSort(BaseSort sort)
        {
            var array = new int[0];

            return SortCompare.Time(sort, array);
        }

        /// <summary>
        /// 构造只有一个元素的数组并用其对指定排序算法做测试。
        /// </summary>
        /// <param name="sort">需要做测试的排序算法。</param>
        /// <returns>排序算法的耗时。</returns>
        static double OneArraySizeSort(BaseSort sort)
        {
            var array = new int[1];
            var random = new Random();
            array[0] = random.Next();

            return SortCompare.Time(sort, array);
        }
    }
}
