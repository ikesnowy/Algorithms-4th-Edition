using System;
using System.IO;
using System.Linq;
// ReSharper disable PossibleNullReferenceException

// 获取当前目录
var path = Directory.GetCurrentDirectory();
path = Directory.GetParent(path).FullName;
path = Directory.GetParent(path).FullName;
// 获取文件
Console.WriteLine(path + "中的所有文件");
Search(path, 0);

static void Search(string path, int tabs)
{
    var dirs = Directory.GetDirectories(path);
    var files = Directory.GetFiles(path);

    foreach (var p in dirs)
    {
        for (var i = 0; i < tabs; i++)
        {
            Console.Write(@"  ");
        }

        Console.WriteLine(p.Split('\\').Last());
        Search(p, tabs + 1);
    }

    foreach (var f in files)
    {
        for (var i = 0; i < tabs; i++)
        {
            Console.Write(@"  ");
        }

        Console.WriteLine(f.Split('\\').Last());
    }
}