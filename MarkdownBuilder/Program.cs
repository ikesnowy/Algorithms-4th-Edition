using System;
using System.IO;
using System.Text;

Console.WriteLine(@"当前节：");
string section = Console.ReadLine();
Console.WriteLine(@"题目总数：");
int questionNum = int.Parse(Console.ReadLine()!);

StringBuilder sb = new StringBuilder();
sb.AppendLine("# 写在前面")
    .AppendLine()
    .AppendLine("整个项目都托管在了 Github 上：<https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp>")
    .AppendLine("查找更方便的版本见：<https://alg4.ikesnowy.com/>")
    .AppendLine("这一节内容可能会用到的库文件有 SymbolTable，同样在 Github 上可以找到。")
    .AppendLine("善用 Ctrl + F 查找题目。")
    .AppendLine()
    .AppendLine("### 习题&题解")
    .AppendLine();

for (int i = 1; i <= questionNum; i++)
{
    sb.AppendLine(section + "." + i)
        .AppendLine()
        .AppendLine("##### 解答")
        .AppendLine()
        .AppendLine("##### 代码")
        .AppendLine()
        .AppendLine("##### 另请参阅")
        .AppendLine();
}

var sw = new StreamWriter(File.OpenWrite(section + ".md"));
sw.Write(sb.ToString());
sw.Flush();
sw.Close();
Console.WriteLine("模板已生成到 " + section + ".md");