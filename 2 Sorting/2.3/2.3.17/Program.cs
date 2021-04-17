using System;
using Quick;

namespace _2._3._17
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var quick = new QuickSort();
            var quickSortX = new QuickSortX();
            var arrayLength = 1000000;
            var a = SortCompare.GetRandomArrayInt(arrayLength);
            var b = new int[arrayLength];
            a.CopyTo(b, 0);

            var time1 = SortCompare.Time(quick, a);
            var time2 = SortCompare.Time(quickSortX, b);
            Console.WriteLine(@"QSort	QSort with Sentinels	");
            Console.WriteLine(time1 + "\t" + time2 + "\t");
        }
    }
}
