using System;

var a = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
for (var i = -1; i < 11; i++)
{
    Console.WriteLine(Rank(a, i));
}

static int Rank(int[] a, int key)
{
    // 使用斐波那契数列作为缩减范围的依据
    var fk = 1;
    var fk1 = 1;
    var fk2 = 0;

    // 获得 Fk，Fk需要大于等于数组的大小，复杂度 lgN
    while (fk < a.Length)
    {
        fk = fk + fk1;
        fk1 = fk1 + fk2;
        fk2 = fk - fk1;
    }

    var lo = 0;

    // 按照斐波那契数列缩减查找范围，复杂度 lgN
    while (fk2 >= 0)
    {
        var i = lo + fk2 > a.Length - 1 ? a.Length - 1 : lo + fk2;
        if (a[i] < key)
        {
            lo = lo + fk2;
        }
        else if (a[i] == key)
        {
            return i;
        }

        fk = fk1;
        fk1 = fk2;
        fk2 = fk - fk1;
    }

    return -1;
}