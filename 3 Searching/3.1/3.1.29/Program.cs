using SymbolTable;

namespace _3._1._29
{
    class Program
    {
        static void Main(string[] args)
        {
            // 官方实现：https://algs4.cs.princeton.edu/31elementary/TestBinarySearchST.java.html
            // 官方实现有几处会抛出异常，这份代码已做了相应修改。
            TestBinarySearchSt.Test(new BinarySearchSt<string, int>());
        }
    }
}