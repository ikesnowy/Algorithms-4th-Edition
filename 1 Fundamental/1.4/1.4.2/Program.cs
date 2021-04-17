using System;
using Measurement;

// 将 a[i] + a[j] + a[k] 改为 (long)a[i] + a[j] + a[k] 即可。
// 此时整个式子将按照精度最高（也就是 long）的标准计算。
var a = new int[4];
a[0] = int.MaxValue;
a[1] = int.MaxValue;
a[2] = int.MinValue;
a[3] = 1;

Console.WriteLine(ThreeSum.Count(a)); // 2