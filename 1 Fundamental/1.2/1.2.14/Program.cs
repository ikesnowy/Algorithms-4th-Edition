using System;
using Commercial;

var a = new Transaction("Turing 01/01/1991 12.12");
var b = new Transaction("Turing 01/01/1991 12.12");
var c = new Transaction("Turing 01/01/1991 12.13");

Console.WriteLine(a.Equals(b)); // True
Console.WriteLine(a.Equals(c)); // False