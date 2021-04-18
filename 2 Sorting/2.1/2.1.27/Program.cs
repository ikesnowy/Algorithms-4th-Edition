using System;
using Sort;

var n = 128;
var random = new Random();

double shellPrev = 1;
double insertionPrev = 1;
double selectionPrev = 1;


while (n < 65538)
{
    var testShell = new int[n];
    var testInsertion = new int[n];
    var testSelection = new int[n];

    for (var i = 0; i < n; i++)
    {
        testShell[i] = random.Next();
        testInsertion[i] = testShell[i];
        testSelection[i] = testShell[i];
    }

    Console.WriteLine("数组大小：" + n);

    Console.Write(@"Shell Sort:");
    var shellNow = SortCompare.Time(new ShellSort(), testShell);
    Console.WriteLine(shellNow + "\t\tNow/Prev=" + shellNow / shellPrev);
    Console.Write(@"Insertion Sort:");
    var insertionNow = SortCompare.Time(new InsertionSort(), testInsertion);
    Console.WriteLine(insertionNow + "\tNow/Prev=" + insertionNow / insertionPrev);
    Console.Write(@"Selection Sort:");
    var selectionNow = SortCompare.Time(new SelectionSort(), testSelection);
    Console.WriteLine(selectionNow + "\tNow/Prev=" + selectionNow / selectionPrev);
    Console.WriteLine();

    shellPrev = shellNow;
    insertionPrev = insertionNow;
    selectionPrev = selectionNow;

    n *= 2;
}