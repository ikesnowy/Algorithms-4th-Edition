using System;
using SymbolTable;

namespace _3._1._37
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 1000000;
            var m = 10;
            var addBy10 = 3;

            for (var i = 0; i < addBy10; i++)
            {
                var bst = new BinarySearchStAnalysis<long, int>(n);
                var data = SearchCompare.GetRandomArrayLong(n, (long)Math.Pow(2, m), (long)Math.Pow(2, m + 1));
                FrequencyCounter.MostFrequentlyKey(bst, data);
                Console.WriteLine("m=" + m + "\t" + bst.GetTimer.ElapsedMilliseconds + "\t" + bst.PutTimer.ElapsedMilliseconds + "\t" + bst.PutTimer.ElapsedMilliseconds / (double)bst.GetTimer.ElapsedMilliseconds);
                m += 10;
            }

            var st = new BinarySearchStAnalysis<string, int>();
            FrequencyCounter.MostFrequentlyWord("tale.txt", 0, st);
            Console.WriteLine("tales\t" + st.GetTimer.ElapsedMilliseconds + "\t" + st.PutTimer.ElapsedMilliseconds + "\t" + st.PutTimer.ElapsedMilliseconds / (double)st.GetTimer.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}