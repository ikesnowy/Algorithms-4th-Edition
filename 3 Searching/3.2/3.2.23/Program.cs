using System;
using BinarySearchTree;

namespace _3._2._23
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst1 = BuildBst();
            Console.WriteLine(bst1);

            Console.WriteLine(@"Delete 5 then delete 3");
            bst1.Delete(5);
            bst1.Delete(3);
            Console.WriteLine(bst1);

            Console.WriteLine(@"Delete 3 then delete 5");
            var bst2 = BuildBst();
            bst2.Delete(3);
            bst2.Delete(5);
            Console.WriteLine(bst2);
        }

        static BST<int, int> BuildBst()
        {
            var bst = new BST<int, int>();
            bst.Put(10, 10);
            bst.Put(5, 5);
            bst.Put(8, 8);
            bst.Put(3, 3);
            bst.Put(8, 8);
            bst.Put(6, 6);
            bst.Put(9, 9);
            return bst;
        }
    }
}
