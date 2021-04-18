using System;
using PriorityQueue;

// 在 MaxPQ 中添加一个字段，用来记录当前的最小值。
// 每次插入的时候都去更新这个最小值即可。
// 当最后一个元素被删除的时候需要更新最小值。
var pq = new MaxPQWithMin<string>();
pq.Insert("9");
Console.WriteLine(pq.Min());
pq.Insert("8");
Console.WriteLine(pq.Min());
pq.DelMax();
pq.DelMax();
if (pq.Min() == null)
{
    Console.WriteLine(@"null");
}