using System;
using UnionFind;

namespace _1._5._18
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = RandomGrid.Generate(5);
            foreach (var i in result)
            {
                Console.WriteLine($@"({i.P}, {i.Q})");
            }
        }
    }
}
