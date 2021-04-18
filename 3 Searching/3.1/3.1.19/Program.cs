using System;
using SymbolTable;

namespace _3._1._19
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new St<string, int>();
            var mostFrequently = FrequencyCounter.MostFrequentlyWords("tale.txt", 20, st);
            foreach (var s in mostFrequently)
                Console.WriteLine(s);
        }
    }
}
