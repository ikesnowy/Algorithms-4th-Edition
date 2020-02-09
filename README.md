# Algorithms-4th-Edition in C#

| dev                                                          | master                                                       |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [![Build Status](https://dev.azure.com/ikesnowy/Algorithms%204th%20Solutions/_apis/build/status/ikesnowy.Algorithms-4th-Edition-in-Csharp?branchName=dev)](https://dev.azure.com/ikesnowy/Algorithms%204th%20Solutions/_build/latest?definitionId=2&branchName=dev) | [![Build Status](https://dev.azure.com/ikesnowy/Algorithms%204th%20Solutions/_apis/build/status/ikesnowy.Algorithms-4th-Edition-in-Csharp?branchName=master)](https://dev.azure.com/ikesnowy/Algorithms%204th%20Solutions/_build/latest?definitionId=2&branchName=master) |

算法（第4版）习题题解 C# 版，勘误感谢名单：[THANKS.md](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/blob/master/THANKS.md)

当前已经完成到 3.2。

可以在这个网站搜索题解：https://alg4.ikesnowy.com/

章节类库的 API 文档：https://alg4.ikesnowy.com/docs/api/index.html

## 目录

- [1.基础 Fundamental](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental)
  - [1.1 基础编程模型 Programming Model](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.1)
  - [1.2 数据抽象 Data Abstraction](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.2)
  - [1.3 背包、队列和栈 Bags, Queues, and Stacks](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.3)
  - [1.4 算法分析 Analysis of Algorithms](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.4)
  - [1.5 案例研究：union-find 算法 CaseStudy: UnionFind](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.5)

- [2.排序 Sorting](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting)
  - [2.1 初级排序算法 Elementary Sorts](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.1)
  - [2.2 归并排序 Mergesort](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.2)
  - [2.3 快速排序 Quicksort](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.3)
  - [2.4 优先队列 Priority Queues](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.4)
  - [2.5 应用 Sorting Applications](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.5)

- [3.查找 Searching](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/3%20Searching)
  - [3.1 符号表 Elementary Symbol Tables](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/3%20Searching/3.1)
  - [3.2 二叉搜索树 Binary Search Trees](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/3%20Searching/3.2)
  - [3.3 平衡查找树 Balanced Search Trees](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/3%20Searching/3.3)

## 使用方法 & 开发环境

### 使用方法

有时题目标号文件夹下只有用例（即 Main 方法），实际编写的类位于章节对应的类库中。

有关章节类库和 API 文档的说明请见：[如何：查找 API 说明](https://alg4.ikesnowy.com/如何：查找-API-说明/)

配置运行题解代码的详细教程见：[如何：运行题解代码？](https://alg4.ikesnowy.com/如何%EF%BC%9A运行题解代码/)。

获取图文版解答可以参考 [我的博客](https://www.cnblogs.com/ikesnowy/) （博客园）或者 [题解网站](https://alg4.ikesnowy.com/) （GitHub Pages）。

### 文件说明

#### 控制台应用程序  

Program.cs 是程序的运行代码。 

需要实现的类会位于其他源文件中，例如实现有理数类的代码就会在同项目下的 Rational.cs 文件中。  

#### Windows 窗体应用程序

题目说明位于 Program.cs 文件中，绘图和逻辑部分代码可能在窗体文件，也可能在 Program.cs 中。  

### 运行/开发环境：

Visual Studio 2019 + .NET Core 3.1

需要绘图的部分只能在 Windows 上运行。

## 代码规范

主要参照 [Framework Design Guidelines](https://docs.microsoft.com/zh-cn/dotnet/standard/design-guidelines/)（本人翻译的 [版本](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/blob/master/C%23%20框架设计指南.md)） 和 [C# 编程指南](https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/index) ，以及以下几条附加内容。

1. 单行注释（"//"）和注释内容之间必须有一个空格。中英文字符之间也需要有一个空格。例如：

   ```csharp
   // 这是一行 C# 注释内容。
   ```

2. 尽量不要使用 C# 中特有的，初学者难以理解的语法特性，例如 `??` 和 `?`。

3. 不要使用三目运算符 `?:` 这会增加理解难度。

## 相关资料  

官方 MOOC 课程： 

Part1 https://www.coursera.org/learn/algorithms-part1

Part2 https://www.coursera.org/learn/algorithms-part2

官方资料站 (English): https://algs4.cs.princeton.edu/
