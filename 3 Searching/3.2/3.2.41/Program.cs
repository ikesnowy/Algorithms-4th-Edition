using System;
using System.Diagnostics;
using BinarySearchTree;

namespace _3._2._41
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 10000;
            
            for (var i = 0; i < 3; i++)
            {
                var bst = new BST<int, int>();
                var bstArray = new BSTArray<int, int>(n);

                Console.WriteLine(@"BST");
                Test(n, bst);
                Console.WriteLine(@"BST Array");
                Test(n, bstArray);

                n *= 10;
            }
        }

        static void Test(int n, IST<int, int> st)
        {
            var data = new int[n];
            for (var i = 0; i < n; i++)
            {
                data[i] = i;
            }

            Shuffle(data);
            var sw = Stopwatch.StartNew();
            foreach (var item in data)
            {
                st.Put(item, item);
            }
            sw.Stop();
            Console.WriteLine("Random Put " + n + ":" + sw.ElapsedMilliseconds + "ms");

            Shuffle(data);
            sw.Restart();
            foreach (var item in data)
            {
                st.Get(item);
            }
            sw.Stop();
            Console.WriteLine("Random Get " + n + ":" + sw.ElapsedMilliseconds + "ms");

            Shuffle(data);
            sw.Restart();
            foreach (var item in data)
            {
                st.Delete(item);
            }
            sw.Stop();
            Console.WriteLine("Random Delete " + n + ":" + sw.ElapsedMilliseconds + "ms");
        }

        static void Shuffle<T>(T[] a)
        {
            var random = new Random();
            for (var i = 0; i < a.Length; i++)
            {
                var r = i + random.Next(a.Length - i);
                var temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}
