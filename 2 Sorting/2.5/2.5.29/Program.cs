using System;
using System.IO;
using System.Collections.Generic;
// ReSharper disable PossibleNullReferenceException
// ReSharper disable StringCompareToIsCultureSpecific

var arguments = Console.ReadLine().Split(' ');
var directoryPath = arguments[0];
var filenames = Directory.GetFiles(directoryPath);
var fileInfos = new FileInfo[filenames.Length];
for (var i = 0; i < filenames.Length; i++)
    fileInfos[i] = new FileInfo(filenames[i]);

var comparers = new List<Comparer<FileInfo>>();
for (var i = 1; i < arguments.Length; i++)
{
    var command = arguments[i];
    switch (command)
    {
        case "-t":
            comparers.Add(new FileTimeStampComparer());
            break;
        case "-s":
            comparers.Add(new FileSizeComparer());
            break;
        case "-n":
            comparers.Add(new FileNameComparer());
            break;
    }
}

InsertionSort(fileInfos, comparers.ToArray());
for (var i = 0; i < fileInfos.Length; i++)
{
    Console.WriteLine(fileInfos[i].Name + "\t" + fileInfos[i].Length + "\t" + fileInfos[i].LastWriteTime);
}

static bool Less<T>(T[] keys, int x, int y, Comparer<T>[] comparables)
{
    var cmp = 0;
    for (var i = 0; i < comparables.Length && cmp == 0; i++)
    {
        cmp = comparables[i].Compare(keys[x], keys[y]);
    }

    return cmp < 0;
}

static void InsertionSort<T>(T[] keys, Comparer<T>[] comparers)
{
    for (var i = 0; i < keys.Length; i++)
    for (var j = i; j > 0 && Less(keys, j, j - 1, comparers); j--)
    {
        var temp = keys[j];
        keys[j] = keys[j - 1];
        keys[j - 1] = temp;
    }
}

class FileSizeComparer : Comparer<FileInfo>
{
    public override int Compare(FileInfo x, FileInfo y)
    {
        return x.Length.CompareTo(y.Length);
    }
}

class FileNameComparer : Comparer<FileInfo>
{
    public override int Compare(FileInfo x, FileInfo y)
    {
        return x.FullName.CompareTo(y.FullName);
    }
}

class FileTimeStampComparer : Comparer<FileInfo>
{
    public override int Compare(FileInfo x, FileInfo y)
    {
        return x.LastWriteTime.CompareTo(y.LastWriteTime);
    }
}