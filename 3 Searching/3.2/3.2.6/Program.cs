using System;

namespace _3._2._6
{
    class Program
    {
        static void Main(string[] args)
        {
            var recursiveHeight = new BSTRecursive<int, int>();
            var constantHeight = new BSTConstant<int, int>();

            int[] testCase = {5, 6, 2, 3, 9, 1, 0, 7};

            foreach (var key in testCase)
            {
                recursiveHeight.Put(key, key);
                constantHeight.Put(key, key);
            }

            Console.WriteLine(@"Recursive Height Method:");
            Console.WriteLine(recursiveHeight);
            Console.WriteLine("Height: " + recursiveHeight.Height());

            Console.WriteLine(@"Constant Height Method");
            Console.WriteLine(constantHeight);
            Console.WriteLine("Height: " + constantHeight.Height());
        }
    }
}
