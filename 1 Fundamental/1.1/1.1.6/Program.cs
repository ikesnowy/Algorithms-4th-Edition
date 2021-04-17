using System;

var f = 0;
var g = 1;
for (var i = 0; i <= 15; i++)
{
    Console.WriteLine(f);
    f = f + g;
    g = f - g;
}