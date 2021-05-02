using System;
using BinarySearchTree;

var random = new Random();
for (var n = 100; n <= 10000; n *= 10)
{
    Console.WriteLine(@"n = " + n + @" sqrt(n) = " + (int)(Math.Sqrt(n)));
    var data = new int[n * n + n];
    for (var i = 0; i < data.Length; i++)
    {
        data[i] = i;
    }

    Shuffle(data);

    var bstHibbard = new Bst<int, int>();
    var bstNonHibbard = new BstNonHibbard<int, int>();

    // build
    for (var i = 0; i < n; i++)
    {
        bstHibbard.Put(data[i], i);
        bstNonHibbard.Put(data[i], i);
    }

    var avePathHibbardBefore = bstHibbard.AverageInternalPathLength();
    var avePathNonHibbardBefore = bstNonHibbard.AverageInternalPathLength();
    Console.WriteLine(@"stage	Hibbard	NonHibbard");
    Console.WriteLine(@"before	" + avePathHibbardBefore + @"	" + avePathNonHibbardBefore);

    // test
    for (var i = n; i < n * n; i++)
    {
        var rank = random.Next(n);
        bstHibbard.Delete(bstHibbard.Select(rank));
        bstHibbard.Put(data[i], i);

        bstNonHibbard.Delete(bstNonHibbard.Select(rank));
        bstNonHibbard.Put(data[i], i);
    }

    var avePathHibbardAfter = bstHibbard.AverageInternalPathLength();
    var avePathNonHibbardAfter = bstNonHibbard.AverageInternalPathLength();
    Console.WriteLine($@"after	{avePathHibbardAfter}	{avePathNonHibbardAfter}");
    Console.WriteLine(
        $@"diff	{(avePathHibbardAfter - avePathHibbardBefore)}	{(avePathNonHibbardAfter - avePathNonHibbardBefore)}");
    Console.WriteLine();
}

static void Shuffle<T>(T[] a)
{
    var random = new Random();
    for (var i = 0; i < a.Length; i++)
    {
        var r = i + random.Next(a.Length - i);
        var temp = a[i];
        a[i] = a[r];
        a[r] = temp;
    }
}