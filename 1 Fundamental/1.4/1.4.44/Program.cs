using System;

var random = new Random();
const int n = 10000;
var a = new int[n];
var dupNum = 0;
int times;
for (times = 0; times < 500; times++)
{
    for (var i = 0; i < n; i++)
    {
        a[i] = random.Next(n);
        if (IsDuplicated(a, i))
        {
            dupNum += i;
            Console.WriteLine($@"生成{i + 1}个数字后发生重复");
            break;
        }
    }
}

Console.WriteLine($@"√(πN/2)={Math.Sqrt(Math.PI * n / 2.0)}，平均生成{dupNum / times}个数字后出现重复");

// 检查是否有重复的数字出现。
static bool IsDuplicated(int[] a, int i)
{
    for (var j = 0; j < i; j++)
    {
        if (a[j] == a[i])
        {
            return true;
        }
    }

    return false;
}