using System;
using _1._3._17;

// 用 Ctrl + Z 标记结束输入
var t = Transaction.ReadTransactions();

foreach (var n in t)
{
    Console.WriteLine(n.ToString());
}