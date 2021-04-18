using System;
using BinarySearchTree;

namespace _3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new Bst<string, string>();
            var input = "E A S Y Q U E S T I O N".Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var key in input)
            {
                bst.Put(key, key);
            }
            Console.WriteLine(bst);
        }
    }
}
