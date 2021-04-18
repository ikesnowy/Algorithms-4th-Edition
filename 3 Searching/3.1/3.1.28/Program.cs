using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._28
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 100000;

            var sw = new Stopwatch();
            var bst = new BinarySearchSt<int, int>();
            var bstOrdered = new BinarySearchStOrderedInsertion<int, int>();

            Console.WriteLine("n = " + n);
            Console.Write(@"Origin: ");
            sw.Start();
            for (var i = 0; i < n; i++)
                bst.Put(i, i);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.Write(@"Modified: ");
            sw.Restart();
            for (var i = 0; i < n; i++)
                bstOrdered.Put(i, i);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}