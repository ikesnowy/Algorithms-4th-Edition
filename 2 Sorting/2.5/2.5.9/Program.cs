using System;
using System.IO;
using System.Collections.Generic;
using _2._5._9;
// ReSharper disable PossibleNullReferenceException

// 数据示例
// 1 - Oct - 28           3500000
// 2 - Oct - 28           3850000
// 3 - Oct - 28           4060000
// 4 - Oct - 28           4330000
// 5 - Oct - 28           4360000
var sr = new StreamReader(File.OpenRead("DJIA.prn"));
var list = new List<Djia>();
while (!sr.EndOfStream)
{
    var blocks = sr.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    list.Add(new Djia(blocks[0], long.Parse(blocks[1])));
}

var array = list.ToArray();
Array.Sort(array);
for (var i = 0; i < 10; i++)
{
    Console.WriteLine(array[i].Date + "\t" + array[i].Volume);
}
