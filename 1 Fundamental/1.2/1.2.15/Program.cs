using System;
using System.IO;

var tinyT = ReadInts("tinyT.txt");
foreach (var n in tinyT)
{
    Console.WriteLine(n);
}

static int[] ReadInts(string path)
{
    var allLines = File.ReadAllLines(path);
    var result = new int[allLines.Length];

    for (var i = 0; i < allLines.Length; i++)
    {
        result[i] = int.Parse(allLines[i]);
    }

    return result;
}