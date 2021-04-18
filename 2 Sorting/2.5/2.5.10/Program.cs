using System;

var versions = new Version[3];
versions[0] = new Version("155.10.1");
versions[1] = new Version("155.1.1");
versions[2] = new Version("155.10.2");
Array.Sort(versions);
for (var i = 0; i < versions.Length; i++)
{
    Console.WriteLine(versions[i]);
}