using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._33
{
    class Program
    {
        static readonly Random Random = new();

        static void Main(string[] args)
        {
            var n = 1000;
            var multiplyBy10 = 4;
            for (var i = 0; i < multiplyBy10; i++)
            {
                Console.WriteLine("n=" + n);
                // 构造表
                var bst = new BinarySearchSt<string, int>(n);
                var mst = new MoveToFrontArraySt<string, int>(n);
                var keys = SearchCompare.GetRandomArrayString(n, 3, 20);
                for (var j = 0; j < n; j++)
                {
                    bst.Put(keys[j], j);
                    mst.Put(keys[j], j);
                }
                // 构造查询
                Array.Sort(keys);
                var querys = new string[10 * n];
                int queryIndex = 0, keyIndex = 0;
                while (queryIndex < querys.Length)
                {
                    var searchTimes = (int)Math.Ceiling((Math.Pow(0.5, keyIndex + 1) * querys.Length));

                    for (var j = 0; j < searchTimes && queryIndex < querys.Length; j++)
                    {
                        querys[queryIndex++] = keys[keyIndex];
                    }
                    keyIndex++;
                }
                Shuffle(querys);

                var sw = new Stopwatch();
                // 测试 MoveToFrontArrayST
                sw.Start();
                for (var j = 0; j < querys.Length; j++)
                {
                    mst.Get(querys[j]);
                }
                sw.Stop();
                Console.WriteLine("MoveToFrontArrayST: " + sw.ElapsedMilliseconds);

                // 测试 BinarySearchST
                sw.Restart();
                for (var j = 0; j < querys.Length; j++)
                {
                    bst.Get(querys[j]);
                }
                sw.Stop();
                Console.WriteLine("BinarySearchST: " + sw.ElapsedMilliseconds);

                n *= 10;
            }
        }

        static void Shuffle<T>(T[] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var r = i + Random.Next(data.Length - i);
                var temp = data[r];
                data[r] = data[i];
                data[i] = temp;
            }
        }
    }
}
