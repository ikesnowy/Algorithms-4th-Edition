using System;
using System.IO;
// ReSharper disable AssignNullToNotNullAttribute

// 官方解答：https://algs4.cs.princeton.edu/25applications/FileSorter.java.html
// 输入 ./ 获得当前目录文件。
var directoryName = Console.ReadLine();
if (!Directory.Exists(directoryName))
{
    Console.WriteLine(directoryName + " doesn't exist or isn't a directory");
    return;
}

var directoryFiles = Directory.GetFiles(directoryName);
Array.Sort(directoryFiles);
for (var i = 0; i < directoryFiles.Length; i++)
    Console.WriteLine(directoryFiles[i]);