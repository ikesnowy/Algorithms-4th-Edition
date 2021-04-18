using System;
using BinarySearchTree;

namespace _3._2._39
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 10000;
            var trial = 100;
            for (var i = 0; i < 3; i++)
            {
                var odds = new int[n];
                var evens = new int[n];
                var bst = new BstAnalysis<int, int>();
                for (var j = 100; j < n; j++)
                {
                    evens[j] = j;
                    odds[j] = j + 1;
                }
                Shuffle(odds);
                foreach (var item in odds)
                {
                    bst.Put(item, item);
                }

                Console.WriteLine("n:" + n);
                // hit
                Shuffle(odds);
                Test(bst, odds, trial, "hit");

                // miss
                Shuffle(evens);
                Test(bst, evens, trial, "miss");

                n *= 10;
            }
        }

        static void Test(BstAnalysis<int, int> bst, int[] testCases, int trials, string label)
        {
            var testRecords = new long[trials];
            for (var j = 0; j < trials; j++)
            {
                bst.CompareTimes = 0;             // reset
                bst.Get(testCases[j]);            // test
                testRecords[j] = bst.CompareTimes; // record
            }

            var testAverage = 0d;        // 'd' for double
            foreach (var record in testRecords)
            {
                testAverage += record;
            }

            testAverage /= testRecords.Length;

            var testStandardDeviation = 0d;
            foreach (var record in testRecords)
            {
                testStandardDeviation += (record - testAverage) * (record - testAverage);
            }

            testStandardDeviation /= testRecords.Length;
            testStandardDeviation = Math.Sqrt(testStandardDeviation);
            // 2lnN + 2γ - 3
            var expect = 2 * Math.Log(testCases.Length) + 2 * 0.5772156649 - 3;
            Console.WriteLine(label + ": ActualAverage: " + testAverage + "\tExpectAverage: " + expect + "\tStandardDevitation:" + testStandardDeviation);
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
