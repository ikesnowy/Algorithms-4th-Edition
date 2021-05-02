using System;
using SymbolTable;

const int repeatTimes = 20;
const int multiplyBy2 = 5;
var n = 2000;
for (var i = 0; i < multiplyBy2; i++)
{
    Console.WriteLine("n=" + n);
    Console.WriteLine(@"Binary	Interp	Ratio");
    long bstTimes = 0, istTimes = 0;

    for (var j = 0; j < repeatTimes; j++)
    {
        var bst = new BinarySearchSt<double, int>();
        var ist = new InterpolationSearchSt();
        var data = SearchCompare.GetRandomArrayDouble(n);

        bstTimes += SearchCompare.Time(bst, data);
        istTimes += SearchCompare.Time(ist, data);
    }

    Console.WriteLine(bstTimes / repeatTimes + "\t" + istTimes / repeatTimes + "\t" + (double)bstTimes / istTimes);
    n *= 2;
}