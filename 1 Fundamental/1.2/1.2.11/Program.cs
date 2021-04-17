using System;
using _1._2._11;
using Commercial;

var d = new Date(2, 29, 2017);
Console.WriteLine(d);

var sd = new SmartDate(2, 29, 2017); //抛出异常
Console.WriteLine(sd);