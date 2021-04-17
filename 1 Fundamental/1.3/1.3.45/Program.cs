using System;
using Generics;

// 给定输入序列，判断是否会出现下溢出。
var input = "- 0 1 2 3 4 5 6 7 8 9 - - - - - - - - -";
Console.WriteLine(IsUnderflow(input.Split(' '))); //True
input = "0 - 1 - 2 - 3 - 4 - 5 - 6 - 7 - 8 - 9 -";
Console.WriteLine(IsUnderflow(input.Split(' '))); //False

// 给定输出序列，判定是否可能。
int[] output = { 4, 3, 2, 1, 0, 9, 8, 7, 6, 5 };
Console.WriteLine(IsOutputPossible(output)); //True
output = new[] { 4, 6, 8, 7, 5, 3, 2, 9, 0, 1 };
Console.WriteLine(IsOutputPossible(output)); //False

static bool IsUnderflow(string[] input)
{
    // 记录栈中元素数量，如果元素数量小于 0 则会出现下溢出。
    var count = 0;

    foreach (var s in input)
    {
        if (count < 0)
        {
            return true;
        }

        if (s.Equals("-"))
        {
            count--;
        }
        else
        {
            count++;
        }
    }

    return false;
}

static bool IsOutputPossible(int[] output)
{
    var input = 0;
    var n = output.Length;
    var stack = new Stack<int>();

    foreach (var i in output)
    {
        // 如果栈为空，则从输入序列中压入一个数。
        if (stack.IsEmpty())
        {
            stack.Push(input);
            input++;
        }

        // 如果输入序列中的所有数都已经入栈过了，跳出循环。
        if (input == n && stack.Peek() != i)
        {
            break;
        }

        // 如果输出序列的下一个数不等于栈顶的数，那么就从输入序列中压入一个数。
        while (stack.Peek() != i && input < n)
        {
            stack.Push(input);
            input++;
        }

        // 如果栈顶的数等于输出的数，弹出它。
        if (stack.Peek() == i)
        {
            stack.Pop();
        }
    }

    return stack.IsEmpty();
}