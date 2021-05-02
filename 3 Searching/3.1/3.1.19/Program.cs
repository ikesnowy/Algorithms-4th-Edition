using System;
using SymbolTable;

var st = new St<string, int>();
var mostFrequently = FrequencyCounter.MostFrequentlyWords("tale.txt", 20, st);
foreach (var s in mostFrequently)
{
    Console.WriteLine(s);
}