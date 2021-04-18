using System;
using PriorityQueue;

// 其实就是同时维护两个堆，一个最大堆一个最小堆。
// 插入元素时复制成两个孪生结点，分别插入到最大堆和最小堆中。
// 孪生结点中存有元素的值，自身在数组的下标以及指向另一个孪生结点的指针。
// 重写最大堆和最小堆的 Exch 函数，只交换元素值以及指针，不交换下标的值。
// 删除结点时需要去另一个堆删除对应的孪生结点。
// 方法是令待删除结点与最后一个结点交换，然后删除最后一个结点
// 随后对交换后的结点做一次 Swim 和 Sink，维持堆的状态。
var pq = new MinMaxPq<int>();
pq.Insert(1);
pq.Insert(2);
pq.Insert(3);
Console.WriteLine(pq.DelMin());
Console.WriteLine(pq.DelMax());
pq.Insert(3);
Console.WriteLine(pq.DelMin());
Console.WriteLine(pq.DelMax());