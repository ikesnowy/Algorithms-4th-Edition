using System;
using _2._1._12;

// 查看最后结果
// 可以发现相同的 h 在数组大小不同时所产生的比值十分接近。
var random = new Random();
var sort = new ShellSort();

var size = 100;
for (var i = 0; i < 5; i++)
{
    var a = new double[size];
    for (var j = 0; j < size; j++)
    {
        a[j] = random.NextDouble() * 100;
    }

    Console.WriteLine("ArraySize:" + size);
    sort.Sort(a);
    size *= 10;
}