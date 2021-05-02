using System;
using SymbolTable;

var st = new MoveToFrontArraySt<string, string>();
st.Put("alpha", "α");
st.Put("beta", "β");
st.Put("omega", "ω");

foreach (var s in st.Keys())
{
    Console.WriteLine(s);
}

st.Get("beta");
Console.WriteLine(@"Get(""beta"")");

foreach (var s in st.Keys())
{
    Console.WriteLine(s);
}