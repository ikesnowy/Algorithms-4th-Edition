using System;
using System.IO;

// 官方解答见：https://algs4.cs.princeton.edu/25applications/Frequency.java.html
var filename = "tale.txt";
var sr = new StreamReader(File.OpenRead(filename));
var a = sr.ReadToEnd().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
Array.Sort(a);

var records = new Record[a.Length];
var word = a[0];
var freq = 1;
var m = 0;
for (var i = 0; i < a.Length; i++)
{
    if (!a[i].Equals(word))
    {
        records[m++] = new Record(word, freq);
        word = a[i];
        freq = 0;
    }

    freq++;
}

records[m++] = new Record(word, freq);

Array.Sort(records, 0, m);
// 只显示频率为前 1% 的单词
for (var i = m - 1; i >= m * 0.99; i--)
{
    Console.WriteLine(records[i].Value + " " + records[i].Key);
}

class Record : IComparable<Record>
{
    public string Key { get; set; } // 单词
    public int Value { get; set; } // 频率

    public Record(string key, int value)
    {
        Key = key;
        Value = value;
    }

    public int CompareTo(Record other)
    {
        return Value.CompareTo(other.Value);
    }
}