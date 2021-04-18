using System;
using BinarySearchTree;

namespace _3._2._43
{
    class Program
    {
        static void Main(string[] args)
        {
            const int trials = 10;
            var putTime = 0L;
            var setTime = 0L;
            for (var j = 0; j < trials; j++)
            {
                var random = new Random();
                var bst = new BstTimer<int, int>();
                var data = new int[1000000];
                for (var i = 0; i < data.Length; i++)
                {
                    data[i] = random.Next();
                }

                FrequencyCounter.MostFrequentlyKey(bst, data);
                putTime += bst.PutTime;
                setTime += bst.SetTime;
            }

            putTime /= trials;
            setTime /= trials;
            Console.WriteLine("Put: " + putTime + "ms Get: " + setTime + "ms ratio: " + (double)putTime / setTime);

        }
    }
}
