using System;
using SymbolTable;

// 官方实现：https://algs4.cs.princeton.edu/31elementary/BinarySearchST.java.html

var st = new BinarySearchSt<string, string>();
st.Put("alpha", "α");
st.Put("beta", "β");
st.Put("gamma", "γ");

foreach (var s in st.Keys())
{
    Console.WriteLine(s);
}

st.Delete("beta");
Console.WriteLine();

foreach (var s in st.Keys())
{
    Console.WriteLine(s);
}