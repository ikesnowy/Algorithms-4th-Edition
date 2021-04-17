using System;
using Generics;
// ReSharper disable RedundantJumpStatement

// 在计算中序表达式算法的基础上做修改
// 压入数字时将该数字所在的位置也一并压入
// 弹出数字进行运算时在位置靠前的数字前加上左括号
// A + B ) * C + D ) ) 为例
// A 压入栈中并记录位置                                        
// + 压入栈中
// B 压入栈中并记录位置                                             
// ) 计算，在 A 之前加入左括号，结果 E 压入栈中，位置为 A 的位置
// * 压入栈中
// C 压入栈中并记录位置
// + 压入栈中
// D 压入栈中并记录位置
// ) 计算，在 C 之前加入左括号，结果 F 压入栈中，位置为 C 的位置
// ) 计算，在 E 之前加入左括号（也就是 A 之前），结果 G 压入栈中，位置为 E 的位置。
var input = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
var operators = new Stack<char>();
var numbers = new Stack<Number>();
var leftBrackets = new int[input.Length];
for (var i = 0; i < input.Length; i++)
{
    if (input[i] == ' ')
    {
        continue;
    }
    else if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
    {
        operators.Push(input[i]);
    }
    else if (input[i] == ')')
    {
        var b = numbers.Pop();
        var a = numbers.Pop();
        var operation = operators.Pop();
        var c = new Number { Position = a.Position };
        leftBrackets[a.Position]++;

        switch (operation)
        {
            case '+':
                c.Value = a.Value + b.Value;
                break;
            case '-':
                c.Value = a.Value - b.Value;
                break;
            case '*':
                c.Value = a.Value * b.Value;
                break;
            case '/':
                c.Value = a.Value / b.Value;
                break;
        }

        numbers.Push(c);
    }
    else
    {
        var num = new Number { Position = i, Value = input[i] - '0' };
        numbers.Push(num);
    }
}

for (var i = 0; i < input.Length; i++)
{
    while (leftBrackets[i] != 0)
    {
        Console.Write("( ");
        leftBrackets[i]--;
    }

    Console.Write(input[i]);
}

struct Number
{
    public int Value;
    public int Position;
}