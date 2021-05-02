using System;
using SymbolTable;

var items = new[]
{
    new Item<string, string> { Key = "gamma", Value = "γ" },
    new Item<string, string> { Key = "alpha", Value = "α" },
    new Item<string, string> { Key = "beta", Value = "β" }
};
var st = new ItemBinarySearchSt<string, string>(items);

foreach (var s in st.Keys())
{
    Console.WriteLine(s + " " + st.Get(s));
}