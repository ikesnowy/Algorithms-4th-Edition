using System;
using System.IO;
using SymbolTable;

// 事实上指的是最近一次访问的键，而非访问最频繁的。

var sr = new StreamReader(File.OpenRead("tale.txt"));
var data = sr.ReadToEnd().Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

var repeatTimes = 1;

Console.WriteLine(@"BinarySearchST");
Console.WriteLine(@"Origin	Cached	Ratio");
long bstTimes = 0, bstcTimes = 0;

var bst = new BinarySearchSt<string, int>();
var bstc = new BinarySearchStCached<string, int>();

bstTimes += SearchCompare.Time(bst, data);
bstcTimes += SearchCompare.Time(bstc, data);
Console.WriteLine(bstTimes / repeatTimes + "\t" + bstcTimes / repeatTimes + "\t" + (double)bstTimes / bstcTimes);

Console.WriteLine(@"SequentialSearchST");
Console.WriteLine(@"Origin	Cached	Ratio");
long sstTimes = 0, sstcTimes = 0;

var sst = new SequentialSearchSt<string, int>();
var sstc = new SequentialSearchStCached<string, int>();

sstTimes += SearchCompare.Time(sst, data);
sstcTimes += SearchCompare.Time(sstc, data);
Console.WriteLine(sstTimes + "\t" + sstcTimes + "\t" + (double)sstTimes / sstcTimes);