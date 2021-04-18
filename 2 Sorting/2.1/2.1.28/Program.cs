using System;
using Sort;

var n = 1024;
var random = new Random();

double insertionPrev = 1;
double selectionPrev = 1;

while (n < 65538)
{
    var testInsertion = new int[n];
    var testSelection = new int[n];

    for (var i = 0; i < n; i++)
    {
        testInsertion[i] = random.Next(2);
        testSelection[i] = testInsertion[i];
    }

    Console.WriteLine("数组大小：" + n);

    Console.Write(@"Insertion Sort:");
    var insertionNow = SortCompare.Time(new InsertionSort(), testInsertion);
    Console.WriteLine(insertionNow + "\tNow/Prev=" + insertionNow / insertionPrev);
    Console.Write(@"Selection Sort:");
    var selectionNow = SortCompare.Time(new SelectionSort(), testSelection);
    Console.WriteLine(selectionNow + "\tNow/Prev=" + selectionNow / selectionPrev);
    Console.WriteLine();

    insertionPrev = insertionNow;
    selectionPrev = selectionNow;

    n *= 2;
}