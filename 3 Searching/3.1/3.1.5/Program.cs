using System;
using SymbolTable;

// 官方实现见：https://algs4.cs.princeton.edu/31elementary/SequentialSearchST.java.html
var input = "S E A R C H E X A M P L E".Split(' ');
var st = new SequentialSearchSt<string, int>();

for (var i = 0; i < input.Length; i++)
{
    st.Put(input[i], i);
}

foreach (var s in st.Keys())
{
    Console.WriteLine(s + " " + st.Get(s));
}