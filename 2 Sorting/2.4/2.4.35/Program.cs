using System;
using _2._4._35;

// 题目有翻译问题，应该是 random() 返回索引 i 的概率为 p[i]/T
// 同时应该是和堆的实现一样使用数组而非指针来代表二叉树
double[] testData = { 0.2, 0.1, 0.3, 0.3, 0.1 };
var sample = new Sample(testData);
var n = 100000;

// 一般测试
Test(n, sample);
// 修改权值测试
sample.Change(3, 0.1);
sample.Change(4, 0.2);
sample.Change(1, 0.2);
Test(n, sample);

// 执行一次测试。
static void Test(int n, Sample sample)
{
    var testResult = new int[sample.P.Length - 1];
    for (var i = 0; i < n; i++)
    {
        testResult[sample.Random()]++;
    }

    // 一般测试
    Console.WriteLine("重复次数=" + n);
    Console.Write(@"预设概率：");
    for (var i = 1; i < sample.P.Length; i++)
    {
        Console.Write(sample.P[i] + "\t");
    }

    Console.WriteLine();
    Console.Write(@"出现次数：");
    for (var i = 0; i < testResult.Length; i++)
    {
        Console.Write(testResult[i] + "\t");
    }

    Console.WriteLine();
}