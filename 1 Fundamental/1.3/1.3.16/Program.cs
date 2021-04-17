using System;
using _1._3._16;

// 输入结束后按 Ctrl + Z 标记结尾
// 输入格式：06/30/2017
// 以回车分隔
var date = Date.ReadDates();
foreach (var d in date)
{
    Console.WriteLine(d);
}