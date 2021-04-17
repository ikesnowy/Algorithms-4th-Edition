using System;
using SymbolTable;

namespace _3._1._24
{
    class Program
    {
        static void Main(string[] args)
        {
            var repeatTimes = 20;
            var multiplyBy2 = 5;
            var n = 2000;

            for (var i = 0; i < multiplyBy2; i++)
            {
                Console.WriteLine("n=" + n);
                Console.WriteLine(@"Binary	Interp	Ratio");
                long bstTimes = 0, istTimes = 0;

                for (var j = 0; j < repeatTimes; j++)
                {
                    var bst = new BinarySearchST<double, int>();
                    var ist = new InterpolationSearchST();
                    var data = SearchCompare.GetRandomArrayDouble(n);

                    bstTimes += SearchCompare.Time(bst, data);
                    istTimes += SearchCompare.Time(ist, data);
                }
                Console.WriteLine(bstTimes / repeatTimes + "\t" + istTimes / repeatTimes + "\t" + (double)bstTimes / istTimes);
                n *= 2;
            }
        }
    }
}