using System;

var array = new[,] { { true, true }, { false, false }, { true, false } };

PrintArray2D(array); // 打印二维数组

static void PrintArray2D(bool[,] array)
{
    var rows = array.GetLength(0); // 获取行数
    var columns = array.GetLength(1); // 获取列数

    //输出列号
    for (var i = 0; i < columns; i++)
    {
        Console.Write($"\t{i + 1}");
    }

    Console.Write("\n");

    for (var i = 0; i < rows; i++)
    {
        // 输出行号
        Console.Write($"{i + 1}");
        for (var j = 0; j < columns; j++)
        {
            if (array[i, j])
            {
                Console.Write($"\t*");
            }
            else
            {
                Console.Write($"\t ");
            }
        }

        Console.Write("\n");
    }
}
