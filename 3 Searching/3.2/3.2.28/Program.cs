using System;
using System.Diagnostics;
using BinarySearchTree;

namespace _3._2._28
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = BuildTree<Bst<int, int>>();
            var bstCached = BuildTree<BstCached<int, int>>();

            var watch = Stopwatch.StartNew();
            for (var i = 0; i < 1000000; i++)
            {
                bstCached.Put(20, i);
            }
            watch.Stop();
            Console.WriteLine("bstCached: " + watch.ElapsedMilliseconds + " ms");

            watch.Restart();
            for (var i = 0; i < 1000000; i++)
            {
                bst.Put(20, i);
            }
            watch.Stop();
            Console.WriteLine("bst:" + watch.ElapsedMilliseconds + " ms");
        }

        static T BuildTree<T>() where T : Bst<int, int>, new()
        {
            var bst = new T();
            bst.Put(4, 4);
            bst.Put(3, 3);
            bst.Put(9, 9);
            bst.Put(2, 2);
            bst.Put(1, 1);
            bst.Put(12, 12);
            bst.Put(18, 18);
            bst.Put(15, 15);
            bst.Put(16, 16);
            bst.Put(11, 11);
            bst.Put(8, 8);
            bst.Put(14, 14);
            bst.Put(20, 20);
            return bst;
        }
    }
}
