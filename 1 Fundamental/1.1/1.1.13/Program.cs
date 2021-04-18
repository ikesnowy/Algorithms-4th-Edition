using System;

var m = 2;
var n = 3;
var array = new int[m, n];

// 新建一个二维数组
for (var i = 0; i < m; i++)
{
    for (var j = 0; j < n; j++)
    {
        array[i, j] = i + j;
    }
}

Console.WriteLine(@"Origin");
PrintArray2D(array, m, n);
Console.WriteLine(@"Transposed");
PrintArrayTranspose2D(array, m, n);

// 转置输出
static void PrintArrayTranspose2D(int[,] array, int rows, int columns)
{
    // 交换行、列输出顺序
    for (var i = 0; i < columns; i++)
    {
        for (var j = 0; j < rows; j++)
        {
            Console.Write($@"	{array[j, i]}");
        }

        Console.Write(@"
");
    }
}

// 正常输出
static void PrintArray2D(int[,] array, int rows, int columns)
{
    for (var i = 0; i < rows; i++)
    {
        for (var j = 0; j < columns; j++)
        {
            Console.Write($@"	{array[i, j]}");
        }

        Console.Write(@"
");
    }
}