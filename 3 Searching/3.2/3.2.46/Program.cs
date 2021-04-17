using System;
using BinarySearchTree;

namespace _3._2._46
{
    class Program
    {
        static void Main(string[] args)
        {
            // 翻译有问题，其实指的是用 N 个 double 构造一个 BST 和 BinarySearchST 的速度对比
            // Get 速度上 BST 是不会比 BinarySearchST 快的。（1.39lgN > lgN）
            //
            // 构造一个 BinarySearchST 的成本：1/2 + 2/2 + 3/2 + ... + (N-1)/2 = N(N-1)/4
            // 构造 BST 的成本：
            // 1.39(lg1 + lg2 + lg3 + lg4 + ... + lg(N-1))
            // = 1.39lg(N-1)!
            // = 1.39(N-1)lg(N-1) (斯特灵公式，约数）
            //
            // 接下来解方程即可：
            // 10 倍： 13.9(N-1)lg(N-1) = N(N-1)/4, N = 499
            // 100 倍：139(N-1)lg(N-1) = N(N-1)/4, N = 7115
            // 1000 倍：1390(N-1)lg(N-1) = N(N-1)/4, N = 91651

            Console.WriteLine(@"N	Array	Tree	Ratio");
            Test(499);
            Test(7115);
            Test(91651);
        }

        static void Test(int n)
        {
            Console.Write(n + "\t");
            var data = new double[n];
            var random = new Random(n);
            for (var i = 0; i < n; i++)
            {
                data[i] = random.NextDouble() * n;
            }

            var bst = new BSTAnalysis<double, int>();
            var binarySearch = new BinarySearchSTAnalysis<double, int>();
            foreach (var d in data)
            {
                binarySearch.Put(d, 1);
            }
            
            var binarySearchTime = (double)binarySearch.CompareAndExchangeTimes;
            Console.Write(binarySearchTime + "\t");
            foreach (var d in data)
            {
                bst.Put(d, 1);
            }

            var binaryTreeTime = (double)bst.CompareTimes;
            Console.Write(binaryTreeTime + "\t");
            Console.WriteLine(binarySearchTime / binaryTreeTime);
        }
    }
}
