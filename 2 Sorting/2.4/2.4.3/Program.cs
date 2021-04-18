using System;
using PriorityQueue;

// | 实现    | insert() | delMax() |
// | ------- | -------- | -------- |
// | 有序数组 |    N     |     1    |
// | 有序链表 |    N     |     1    |
// | 无序数组 |    1     |     N    |
// | 无序链表 |    1     |     N    |
Test(new OrderedArrayMaxPQ<string>(10));
Test(new UnorderedArrayMaxPQ<string>(10));
Test(new OrderedLinkedMaxPQ<string>());
Test(new UnorderedLinkedMaxPQ<string>());

static void Test(IMaxPQ<string> pq)
{
    Console.WriteLine(pq.ToString());
    pq.Insert("this");
    pq.Insert("is");
    pq.Insert("a");
    pq.Insert("test");
    while (!pq.IsEmpty())
        Console.Write(pq.DelMax() + " ");
    Console.WriteLine();
}