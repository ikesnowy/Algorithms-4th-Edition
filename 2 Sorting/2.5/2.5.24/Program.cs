using System;
using SortApplication;

// 官方解答：https://algs4.cs.princeton.edu/25applications/StableMinPQ.java.html

var pq = new MinPQStable<Wrapper<string>>();
var text = "it was the best of times it was the worst of times it was the ";
var texts = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

for (var i = 0; i < texts.Length; i++)
    pq.Insert(new Wrapper<string>(texts[i], i + 1));

while (!pq.IsEmpty())
{
    var w = pq.DelMin();
    Console.WriteLine(w.Value + " " + w.Index);
}

class Wrapper<T> : IComparable<Wrapper<T>> where T : IComparable<T>
{
    public T Value;
    public readonly int Index;

    public Wrapper(T value, int index)
    {
        Value = value;
        Index = index;
    }

    public int CompareTo(Wrapper<T> other)
    {
        return Value.CompareTo(other.Value);
    }
}