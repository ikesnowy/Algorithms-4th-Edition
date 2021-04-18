using System;
using System.Collections.Generic;
using _2._5._32;
// ReSharper disable PossibleNullReferenceException

var tiles = new TilesInWrongPlace(new BoardEqualityComparer());
var manhattan = new ManhattanDistance(new BoardEqualityComparer());
var manhattanSquare = new SquareOfManhattanDistance(new BoardEqualityComparer());

var start = new SearchNode() { Status = new[] { 0, 1, 3, 4, 2, 5, 7, 8, 6 }, Steps = 0 };

var goal = new SearchNode() { Status = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 }, Steps = 0 };

Console.WriteLine(@"Missing Tiles");
var path = tiles.GetPath(start, goal);
foreach (var s in path)
    PrintMatrix(s.Status);

Console.WriteLine(@"Manhattan");
path = manhattan.GetPath(start, goal);
foreach (var s in path)
    PrintMatrix(s.Status);

Console.WriteLine(@"Square Manhattan");
path = manhattanSquare.GetPath(start, goal);
foreach (var s in path)
    PrintMatrix(s.Status);

// 打印矩阵。
static void PrintMatrix(int[] current)
{
    for (var i = 0; i < 3; i++)
    {
        for (var j = 0; j < 3; j++)
        {
            Console.Write(current[i * 3 + j] + " ");
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}

/// <summary>
/// 用于检查状态相同的比较器。
/// </summary>
class BoardEqualityComparer : IEqualityComparer<SearchNode>
{
    public bool Equals(SearchNode x, SearchNode y)
    {
        for (var i = 0; i < x.Status.Length; i++)
            if (x.Status[i] != y.Status[i])
                return false;
        return true;
    }

    public int GetHashCode(SearchNode obj)
    {
        if (obj.Status.Length == 0)
            return 0;

        var hash = 1;
        foreach (var i in obj.Status)
        {
            hash = 31 * hash + i;
        }

        return hash;
    }
}

class SquareOfManhattanDistance : AStarSolverFor8Puzzles
{
    public SquareOfManhattanDistance(IEqualityComparer<SearchNode> e) : base(e)
    {
    }

    /// <summary>
    /// 计算曼哈顿距离的平方。
    /// </summary>
    /// <param name="start">起始状态。</param>
    /// <param name="goal">目标状态。</param>
    /// <returns></returns>
    protected override int HeuristicDistance(SearchNode start, SearchNode goal)
    {
        var manhattanSquareSum = 0;
        for (var i = 0; i < start.Status.Length; i++)
        {
            var goalIndex = 0;
            for (var j = 0; j < goal.Status.Length; j++)
                if (goal.Status[j] == start.Status[i])
                    goalIndex = j;

            var dx = Math.Abs(i % 3 - goalIndex % 3);
            var dy = Math.Abs(i / 3 - goalIndex / 3);
            manhattanSquareSum += (dx + dy) * (dx + dy);
        }

        return manhattanSquareSum;
    }
}

class ManhattanDistance : AStarSolverFor8Puzzles
{
    public ManhattanDistance(IEqualityComparer<SearchNode> e) : base(e)
    {
    }

    /// <summary>
    /// 计算曼哈顿距离之和。
    /// </summary>
    /// <param name="start">初始状态。</param>
    /// <param name="goal">目标状态。</param>
    /// <returns></returns>
    protected override int HeuristicDistance(SearchNode start, SearchNode goal)
    {
        var manhattanSum = 0;
        for (var i = 0; i < start.Status.Length; i++)
        {
            var goalIndex = 0;
            for (var j = 0; j < goal.Status.Length; j++)
                if (goal.Status[j] == start.Status[i])
                    goalIndex = j;

            var dx = Math.Abs(i % 3 - goalIndex % 3);
            var dy = Math.Abs(i / 3 - goalIndex / 3);
            manhattanSum += dx + dy;
        }

        return manhattanSum;
    }
}

class TilesInWrongPlace : AStarSolverFor8Puzzles
{
    public TilesInWrongPlace(IEqualityComparer<SearchNode> e) : base(e)
    {
    }

    /// <summary>
    /// 计算错误的格子数。
    /// </summary>
    /// <param name="start">初始状态。</param>
    /// <param name="goal">目标状态。</param>
    /// <returns></returns>
    protected override int HeuristicDistance(SearchNode start, SearchNode goal)
    {
        var missTile = 0;
        for (var i = 0; i < start.Status.Length; i++)
        {
            if (start.Status[i] != goal.Status[i])
                missTile++;
        }

        return missTile;
    }
}