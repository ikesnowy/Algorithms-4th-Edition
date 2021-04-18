using System;
using SymbolTable;

namespace _3._1._1
{
    class Program
    {
        // 官方解答：https://algs4.cs.princeton.edu/31elementary/GPA.java.html
        // ST.java：https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/ST.java.html
        static void Main(string[] args)
        {
            var st = new St<string, double>();
            st.Put("A+", 4.33);
            st.Put("A", 4.00);
            st.Put("A-", 3.67);
            st.Put("B+", 3.33);
            st.Put("B", 3.00);
            st.Put("B-", 2.67);
            st.Put("C+", 2.33);
            st.Put("C", 2.00);
            st.Put("C-", 1.67);
            st.Put("D", 1.00);
            st.Put("F", 0.00);

            double total = 0;
            var gpas = Console.ReadLine().Split(' ');
            foreach (var gpa in gpas)
                total += st.Get(gpa);
            total /= gpas.Length;
            Console.WriteLine("GPA=" + total);
        }
    }
}