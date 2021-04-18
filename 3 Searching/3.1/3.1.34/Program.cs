using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._34
{
    class Program
    {
        static readonly Random random = new();

        static void Main(string[] args)
        {
            var n = 1000;
            var multiplyBy10 = 4;

            // 调和级数
            var harmonicNumber = new double[n * (int)Math.Pow(10, multiplyBy10)];
            harmonicNumber[0] = 1;
            for (var i = 1; i < harmonicNumber.Length; i++)
            {
                harmonicNumber[i] = harmonicNumber[i - 1] + 1 / (i + 1);
            }

            for (var i = 0; i < multiplyBy10; i++)
            {
                Console.WriteLine("n=" + n);
                // 构造表
                var mst1 = new MoveToFrontArrayST<string, int>(n);
                var mst2 = new MoveToFrontArrayST<string, int>(n);
                var keys = SearchCompare.GetRandomArrayString(n, 3, 20);
                for (var j = 0; j < n; j++)
                {
                    mst1.Put(keys[j], j);
                    mst2.Put(keys[j], j);
                }
                // 构造查询
                Array.Sort(keys);
                var queryZipf = new string[10 * n];
                int queryIndex = 0, keyIndex = 0;
                while (queryIndex < queryZipf.Length)
                {
                    var searchTimes = (int)Math.Ceiling(queryZipf.Length / (harmonicNumber[keyIndex + 1] * (i + 1)));

                    for (var j = 0; j < searchTimes && queryIndex < queryZipf.Length; j++)
                    {
                        queryZipf[queryIndex++] = keys[keyIndex];
                    }
                    keyIndex++;
                }

                var querys = new string[10 * n];
                queryIndex = 0;
                keyIndex = 0;
                while (queryIndex < querys.Length)
                {
                    var searchTimes = (int)Math.Ceiling((Math.Pow(0.5, keyIndex + 1) * querys.Length));

                    for (var j = 0; j < searchTimes && queryIndex < querys.Length; j++)
                    {
                        querys[queryIndex++] = keys[keyIndex];
                    }
                    keyIndex++;
                }
                // Shuffle(querys);

                var sw = new Stopwatch();
                // 测试 3.1.33 的序列
                sw.Start();
                for (var j = 0; j < queryZipf.Length; j++)
                {
                    mst1.Get(querys[j]);
                }
                sw.Stop();
                Console.WriteLine("3.1.33 Best: " + sw.ElapsedMilliseconds);

                // 测试 Zipf
                sw.Restart();
                for (var j = 0; j < queryZipf.Length; j++)
                {
                    mst2.Get(queryZipf[j]);
                }
                sw.Stop();
                Console.WriteLine("Zipf: " + sw.ElapsedMilliseconds);

                n *= 10;
            }
        }

        static void Shuffle<T>(T[] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var r = i + random.Next(data.Length - i);
                var temp = data[r];
                data[r] = data[i];
                data[i] = temp;
            }
        }
    }
}
