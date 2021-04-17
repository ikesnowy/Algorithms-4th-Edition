using System;
// ReSharper disable PossibleNullReferenceException
// ReSharper disable AssignNullToNotNullAttribute

/*
 * 输入示例：
 * 
 * 3
 * hi 1 2
 * hey 1 3
 * hello 1 4
 * 
 */
var columns = 2;
var rows = int.Parse(Console.ReadLine()); // 行号

var names = new string[rows]; // 姓名
var array = new int[rows, columns]; // 输入的两个整数
var results = new double[rows]; // 计算结果

for (var i = 0; i < rows; i++)
{
    var temp = Console.ReadLine();
    names[i] = temp.Split(' ')[0];
    for (var j = 0; j < columns; j++)
    {
        array[i, j] = int.Parse(temp.Split(' ')[j + 1]);
    }

    results[i] = (double)array[i, 0] / array[i, 1];
}

PrintArray2D(names, array, results);

static void PrintArray2D(string[] names, int[,] array, double[] results)
{
    var rows = array.GetLength(0); // 获取行数
    var columns = array.GetLength(1); // 获取列数

    for (var i = 0; i < rows; i++)
    {
        Console.Write($"\t{names[i]}");
        for (var j = 0; j < columns - 1; j++)
        {
            Console.Write($"\t{array[i, j]}");
        }

        Console.Write($"\t{array[i, columns - 1]}");
        Console.Write($"\t{results[i]:N3}"); // 变量名:N3 保留三位小数
        Console.Write("\n");
    }
}