using System;
using System.IO;
using System.Collections.Generic;

namespace _2._5._16
{
    class Program
    {
        // 官方解答：https://algs4.cs.princeton.edu/25applications/California.java.html
        private class CandidateComparer : IComparer<string>
        {
            private static readonly string order = "RWQOJMVAHBSGZXNTCIEKUPDYFL";
            public int Compare(string x, string y)
            {
                var n = Math.Min(x.Length, y.Length);
                for (var i = 0; i < n; i++)
                {
                    var a = order.IndexOf(x[i]);
                    var b = order.IndexOf(y[i]);
                    if (a != b)
                        return a.CompareTo(b);
                }

                return x.Length.CompareTo(y.Length);
            }
        }

        static void Main(string[] args)
        {
            // 数据来源：https://introcs.cs.princeton.edu/java/data/california-gov.txt
            var sr = new StreamReader(File.OpenRead("california-gov.txt"));
            var names = 
                sr.ReadToEnd()
                .ToUpper()
                .Split
                (new[] { '\n', '\r' }, 
                StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(names, new CandidateComparer());
            for (var i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
