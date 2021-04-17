using System;

var M = 2;
var N = 3;
var array = new int[M, N];

// 新建一个二维数组
for (var i = 0; i < M; i++)
{
    for (var j = 0; j < N; j++)
    {
        array[i, j] = i + j;
    }
}

Console.WriteLine(@"Origin");
PrintArray2D(array, M, N);
Console.WriteLine(@"Transposed");
PrintArrayTranspose2D(array, M, N);

// 转置输出
static void PrintArrayTranspose2D(int[,] array, int rows, int columns)
{
    // 交换行、列输出顺序
    for (var i = 0; i < columns; i++)
    {
        for (var j = 0; j < rows; j++)
        {
            Console.Write($"\t{array[j, i]}");
        }

        Console.Write("\n");
    }
}

// 正常输出
static void PrintArray2D(int[,] array, int rows, int columns)
{
    for (var i = 0; i < rows; i++)
    {
        for (var j = 0; j < columns; j++)
        {
            Console.Write($"\t{array[i, j]}");
        }

        Console.Write("\n");
    }
}