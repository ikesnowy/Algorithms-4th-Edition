using System;

namespace _1._5._20
{
    class Program
    {
        static void Main(string[] args)
        {
            var uf = new WeightedQuickUnionUF();
            char[] split = { '\r', '\n' };
            var input = TestCase.Properties.Resources.tinyUF.Split(split, StringSplitOptions.RemoveEmptyEntries);
            var size = int.Parse(input[0]);

            for (var i = 0; i < size; i++)
            {
                if (uf.NewSite() != i)
                {
                    Console.WriteLine(@"标识符不一致！");
                    return;
                }
            }

            string[] pair;
            int p, q;
            for (var i = 1; i < input.Length; i++)
            {
                pair = input[i].Split(' ');
                p = int.Parse(pair[0]);
                q = int.Parse(pair[1]);

                uf.Union(p, q);
            }

            var parent = uf.GetParent();
            foreach (var i in parent)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
