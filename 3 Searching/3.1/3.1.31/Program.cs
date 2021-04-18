using System;
using SymbolTable;

namespace _3._1._31
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 1000;
            var multiplyBy2 = 5;
            var repeatTime = 3;
            var averageHit = 10;

            for (var i = 0; i < multiplyBy2; i++)
            {
                Console.WriteLine("n = " + n);
                long sumSequential = 0, sumBinary = 0;
                for (var j = 0; j < repeatTime; j++)
                {
                    sumBinary += SearchCompare.Performance(new BinarySearchSt<string, int>(), n, averageHit);
                    sumSequential += SearchCompare.Performance(new SequentialSearchSt<string, int>(), n, averageHit);
                }
                Console.WriteLine("BinarySearchST: " + sumBinary / repeatTime);
                Console.WriteLine("SequentialSearchST: " + sumSequential / repeatTime);
                n *= 2;
            }
        }
    }
}