using System;
// ReSharper disable CognitiveComplexity

namespace SymbolTable
{
    /// <summary>
    /// 测试 BinarySearchST 的用例。
    /// </summary>
    public class TestBinarySearchSt
    {
        /// <summary>
        /// 测试方法，测试 BinarySearchST。
        /// </summary>
        /// <param name="st">用于测试的符号表。</param>
        public static void Test(BinarySearchSt<string, int> st)
        {
            var test = "S E A R C H E X A M P L E";
            var keys = test.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = keys.Length;

            for (var i = 0; i < n; i++)
                st.Put(keys[i], i);

            Console.WriteLine("size = " + st.Size());
            Console.WriteLine("min = " + st.Min());
            Console.WriteLine("max = " + st.Max());
            Console.WriteLine();

            Console.WriteLine(@"Testing Keys()");
            Console.WriteLine(@"-----------------------------------");
            foreach (var s in st.Keys())
                Console.WriteLine(s + " " + st.Get(s));
            Console.WriteLine();

            Console.WriteLine(@"Testing Select()");
            Console.WriteLine(@"-----------------------------------");
            for (var i = 0; i < st.Size(); i++) // 循环条件不能有 '='
                Console.WriteLine(i + " " + st.Select(i));
            Console.WriteLine();

            Console.WriteLine(@"key Rank Floor Ceil");
            Console.WriteLine(@"-----------------------------------");
            for (var i = 'A'; i <= 'Z'; i++)
            {
                var s = i + "";
                Console.WriteLine($@"{s} {st.Rank(s)} {st.Floor(s)} {st.Ceiling(s)}");
            }
            Console.WriteLine();

            for (var i = 0; i < st.Size() / 2; i++)
                st.DeleteMin();
            Console.WriteLine("After deleting the smallest " + st.Size() / 2 + " keys"); 
            Console.WriteLine(@"-----------------------------------");
            foreach (var s in st.Keys())
                Console.WriteLine(s + " " + st.Get(s));
            Console.WriteLine();

            while (!st.IsEmpty())
                st.Delete(st.Select(st.Size() / 2));
            Console.WriteLine(@"After deleting the remaining keys");
            Console.WriteLine(@"-----------------------------------");
            // 异常处理
            try
            {
                foreach (var s in st.Keys())
                    Console.WriteLine(s + " " + st.Get(s));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            Console.WriteLine();

            Console.WriteLine(@"After adding back N keys");
            Console.WriteLine(@"-----------------------------------");
            for (var i = 0; i < n; i++)
                st.Put(keys[i], i);
            foreach (var s in st.Keys())
                Console.WriteLine(s + " " + st.Get(s));
            Console.WriteLine();
        }
    }
}
