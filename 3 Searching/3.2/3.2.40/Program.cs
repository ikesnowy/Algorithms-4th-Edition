using System;
using BinarySearchTree;

namespace _3._2._40
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 10000;
            var trials = 100;

            for (var i = 0; i < 3; i++)
            {
                var items = new int[n];
                
                for (var j = 0; j < n; j++)
                {
                    items[j] = j;
                }

                var aveHeight = 0d;
                for (var j = 0; j < trials; j++)
                {
                    var bst = new Bst<int, int>();
                    Shuffle(items);
                    foreach (var item in items)
                    {
                        bst.Put(item, item);
                    }

                    aveHeight += bst.Height();
                }

                aveHeight /= trials;
                var c = 4.31107d;
                var expectHeightLuc = c * Math.Log(n);
                var expectHeightMichael = c * Math.Log(n) - (3 * c / (2 * (c - 1))) * Math.Log(Math.Log(n));
                Console.WriteLine("n:" + n);
                Console.WriteLine("Actual Height:" + aveHeight);
                Console.WriteLine("Devroye: " + expectHeightLuc + "\tDiff: " + (float)(expectHeightLuc - aveHeight));
                Console.WriteLine("Michael: " + expectHeightMichael + "\tDiff: " + (float)(expectHeightMichael - aveHeight));

                n *= 10;
            }
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
