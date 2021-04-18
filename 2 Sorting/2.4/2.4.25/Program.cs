using System;
using System.IO;
using _2._4._25;
using PriorityQueue;

var n = 1000000;

var pq = new MinPq<CubeSum>();
Console.WriteLine(@"正在初始化");
for (var i = 0; i <= n; i++)
{
    pq.Insert(new CubeSum(i, i));
}

var ostream = new FileStream("./result.txt", FileMode.Create, FileAccess.Write);
var sw = new StreamWriter(ostream);
Console.WriteLine(@"正在写入文件……");
var prev = new CubeSum(-1, -1);
long pairCount = 0;
while (!pq.IsEmpty())
{
    var s = pq.DelMin();
    if (s.sum == prev.sum)
    {
        sw.WriteLine(s + " = " + prev.i + "^3 + " + prev.j + "^3");
        pairCount++;
    }

    if (s.j < n)
        pq.Insert(new CubeSum(s.i, s.j + 1));
    prev = s;
}

sw.WriteLine("共找到" + pairCount + "对数据");
Console.WriteLine("共找到" + pairCount + "对数据");
sw.Close();
Console.WriteLine(@"结果已经保存到程序所在目录下的 result.txt 文件中");