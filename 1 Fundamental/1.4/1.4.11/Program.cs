using System;
using Measurement;

var a = new[] { 5, 5, 5, 5, 1 };
var set = new StaticSeTofInts(a);
Console.WriteLine(set.HowMany(5));