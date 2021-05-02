using System;
using SymbolTable;

// 删除末尾的版权许可： Monseigneur
// 不删除末尾的版权许可：Gutenberg-tm
// tale.txt:https://introcs.cs.princeton.edu/java/data/tale.txt
var st = new St<string, int>();
var most = FrequencyCounter.MostFrequentlyWord("tale.txt", 10, st);
Console.WriteLine(most);