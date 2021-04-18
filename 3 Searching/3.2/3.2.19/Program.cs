using System;
using System.Linq;
using BinarySearchTree;

namespace _3._2._19
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

            while (!bst.IsEmpty())
            {
                Console.WriteLine(bst);
                bst.Delete(bst.ToKeyArray().First());
            }
        }
    }
}
