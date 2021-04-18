using System;
using System.Diagnostics;

var random = new Random();
Console.WriteLine(@"number	Build	Sort	Ratio");
var n = 1000; // 当数据量到达 10^9 时会需要 2G 左右的内存
var multiTen = 7;
for (var i = 0; i < multiTen; i++)
{
    var data = GetRandomArray(n);
    var fullSort = new Stopwatch();
    var buildHeap = new Stopwatch();

    fullSort.Restart();

    buildHeap.Restart();
    BuildHeap(data);
    buildHeap.Stop();

    HeapSort(data);
    fullSort.Stop();

    var buildTime = buildHeap.ElapsedMilliseconds;
    var fullTime = fullSort.ElapsedMilliseconds;
    Console.WriteLine(n + "\t" + buildTime + "\t" + fullTime + "\t" + (double)buildTime / fullTime);
    n *= 10;
}

short[] GetRandomArray(int number)
{
    var data = new short[number];
    for (var i = 0; i < number; i++)
    {
        data[i] = (short)random.Next();
    }

    return data;
}

// 将数组构造成堆。
void BuildHeap(short[] data)
{
    var count = data.Length;
    for (var k = count / 2; k >= 1; k--)
    {
        Sink(data, k, count);
    }
}

// 利用已经生成的堆排序。
void HeapSort(short[] heap)
{
    var count = heap.Length;
    while (count > 1)
    {
        Exch(heap, 1, count--);
        Sink(heap, 1, count);
    }
}

// 令堆中的元素下沉。
void Sink(short[] pq, int k, int number)
{
    while (2 * k <= number)
    {
        var j = 2 * k;
        if (j < number && Less(pq, j, j + 1))
            j++;
        if (!Less(pq, k, j))
            break;
        Exch(pq, k, j);
        k = j;
    }
}

// 比较堆中下标为 a 的元素是否小于下标为 b 的元素。
static bool Less(short[] pq, int a, int b) => pq[a - 1].CompareTo(pq[b - 1]) < 0;

// 交换堆中的两个元素。
static void Exch(short[] pq, int a, int b)
{
    var temp = pq[a - 1];
    pq[a - 1] = pq[b - 1];
    pq[b - 1] = temp;
}