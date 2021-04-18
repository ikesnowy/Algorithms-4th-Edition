using System;
using Quick;

// 证明
// 我们设 C0(n) 代表将 n 个不重复元素排序时大小为 0 的数组的数量。
// 同理有 C1(n) 和 C2(n) 代表大小为 1 的数组的数量和大小为 2 的数组的数量。
// 设 k 代表切分位置，显然切分位置随机且概率相等，在 1~n 之间均匀分布。
// 根据条件，三者都满足下式。
// C(n) = 1/n sum(C(k - 1) + C(n - k)), k=1,2,...,n
// 显然 sum(C(k - 1)) = sum(C(n - k)), k=1,2,...,n
// 于是可以化简为
// C(n) = 2/n sum(C(k - 1)), k=1,2,...,n
// nC(n) = 2 * sum(C(k-1)), k=1,2,...,n
// 同理有
// (n-1)C(n-1) = 2 * sum(C(k-1)), k = 1,2,...,n-1
// 相减得到递推式
// nC(n) - (n-1)C(n-1) = 2*C(n-1)
// C(n) = (n+1)/n * C(n-1)
// 利用累乘法可以求得通项公式
// C(n)=C(k)*(n+1)/(k+1), n>k
// 对于 C0 有 C0(0)=1, C0(1)=0
// C0(2)=C(0)+C(1)=1
// C0(n)=(n+1)/3, n>2
// 对于 C1 有 C1(0)=0, C1(1)=1
// C1(2)=C1(0)+C1(1)=1
// C1(n)=(n+1)/3, n>2
// 对于 C2 有 C2(0)=C2(1)=0, C2(2)=1
// C2(3)=1/3*2*(C2(0)+C2(1)+C2(2))=2/3
// C2(n)=C2(3)*(n+1)/4=(n+1)/6, n>3
// 结论
// C0(n)=C1(n)=(n+1)/3, C2(n)=(n+1)/6
var n = 1000;
var sort = new QuickSortAnalyze();
Console.WriteLine(@"n	0	1	2");
for (var i = 0; i < 5; i++)
{
    var a = new int[n];
    for (var j = 0; j < n; j++)
    {
        a[j] = j;
    }

    SortCompare.Shuffle(a);
    sort.Sort(a);
    Console.WriteLine(n + "\t" + sort.Array0Num + "\t" + sort.Array1Num + "\t" + sort.Array2Num);
    n *= 2;
}