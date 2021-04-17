using System;

var a = new int[10];
for (var i = 0; i < 10; i++)
{
    a[i] = 9 - i;
}

// a[10] = {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
for (var i = 0; i < 10; i++)
{
    a[i] = a[a[i]];
}

// a[0] = a[9] = 0; a[1] = a[8] = 1; a[2] = a[7] = 2;......
for (var i = 0; i < 10; i++)
{
    Console.WriteLine(a[i]);
}
