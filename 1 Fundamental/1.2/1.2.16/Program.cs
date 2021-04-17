using System;
using _1._2._16;

var a = new Rational(15, 20);
var b = new Rational(2, -9);

Console.WriteLine(a + " + " + b + "=" + a.Plus(b));
Console.WriteLine(a + " - " + b + "=" + a.Minus(b));
Console.WriteLine(a + " * " + b + "=" + a.Multiply(b));
Console.WriteLine(a + " / " + b + "=" + a.Divide(b));