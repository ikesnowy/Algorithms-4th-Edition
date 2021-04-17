using System;
using Generics;

// 其实就是把右括号换成相应运算符
// 对于 (A + B)，忽略左括号，数字直接输出，运算符入栈，遇到右括号时再弹出
// 结果 A B +，变成后序表达式
var stack = new Stack<string>();
var input = "( 1 + ( 1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) ) )".Split(' ');
foreach (var n in input)
{
    if (n == " ")
        continue;
    else if (n == "+" || n == "-" || n == "*" || n == "/")
    {
        stack.Push(n);
    }
    else if (n == ")")
    {
        Console.Write(stack.Pop() + " ");
    }
    else if (n == "(")
    {
        continue;
    }
    else
    {
        Console.Write(n + " ");
    }
}

Console.WriteLine();