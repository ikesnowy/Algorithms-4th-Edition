using System;

namespace _2._5._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] { "dup", "aba", "dup", "aaaaa", "aba", "cs" };
            var distinct = Dedup(a);
            for (var i = 0; i < distinct.Length; i++)
            {
                Console.Write(distinct[i] + " ");
            }
        }

        static string[] Dedup(string[] a)
        {
            if (a.Length == 0)
                return a;

            var sorted = new string[a.Length];
            for (var i = 0; i < a.Length; i++)
            {
                sorted[i] = a[i];
            }
            Array.Sort(sorted);
            // sorted = sorted.Distinct().ToArray();
            var distinct = new string[sorted.Length];
            distinct[0] = sorted[0];
            var j = 1;
            for (var i = 1; i < sorted.Length; i++)
            {
                if (sorted[i].CompareTo(sorted[i - 1]) != 0)
                    distinct[j++] = sorted[i];
            }
            return distinct;
        }
    }
}