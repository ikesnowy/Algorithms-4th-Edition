using System;
using System.Collections.Generic;
using SortApplication;

namespace _2._5._32
{
    /// <summary>
    /// 用于解决 8 字谜题的 A* 寻路器（没有实现 h(n) 函数）。
    /// </summary>
    abstract class AStarSolverFor8Puzzles : AStar<SearchNode>
    {
        /// <summary>
        /// 构造器不应该被外部访问。
        /// </summary>
        /// <param name="e">相等比较器。</param>
        protected AStarSolverFor8Puzzles(IEqualityComparer<SearchNode> e) : base(e) { }

        /// <summary>
        /// 尝试获得当前状态下一步的所有状态（上下左右）。
        /// </summary>
        /// <param name="current">当前状态。</param>
        /// <returns></returns>
        protected override SearchNode[] GetNeighbors(SearchNode current)
        {
            var neighbors = new List<SearchNode>();

            var temp = MoveDown(current);
            if (temp != null)
                neighbors.Add(temp);
            temp = MoveUp(current);
            if (temp != null)
                neighbors.Add(temp);
            temp = MoveLeft(current);
            if (temp != null)
                neighbors.Add(temp);
            temp = MoveRight(current);
            if (temp != null)
                neighbors.Add(temp);

            return neighbors.ToArray();
        }

        /// <summary>
        /// 计算两个状态之间的实际距离，即 g(n)。
        /// </summary>
        /// <param name="start">初始状态。</param>
        /// <param name="goal">目标状态。</param>
        /// <returns></returns>
        protected override int ActualDistance(SearchNode start, SearchNode goal)
        {
            return goal.Steps - start.Steps;
        }

        /// <summary>
        /// 获得空格位置。
        /// </summary>
        /// <param name="current">当前状态。</param>
        /// <returns></returns>
        protected int GetSpaceIndex(SearchNode current)
        {
            var spaceIndex = 0;
            for (var i = 0; i < current.Status.Length; i++)
                if (current.Status[i] == 0)
                    spaceIndex = i;
            return spaceIndex;
        }

        /// <summary>
        /// 尝试将空格右移。
        /// </summary>
        /// <param name="current">当前状态。</param>
        /// <returns></returns>
        protected SearchNode MoveRight(SearchNode current)
        {
            var spaceIndex = GetSpaceIndex(current);
            if ((spaceIndex + 1) % 3 == 0)
                return null;

            var right = new SearchNode
            {
                Steps = current.Steps + 1,
                Status = new int[current.Status.Length]
            };
            Array.Copy(current.Status, right.Status, current.Status.Length);
            var temp = right.Status[spaceIndex];
            right.Status[spaceIndex] = right.Status[spaceIndex + 1];
            right.Status[spaceIndex + 1] = temp;
            return right;
        }

        /// <summary>
        /// 尝试将空格左移。
        /// </summary>
        /// <param name="current">当前状态。</param>
        /// <returns></returns>
        protected SearchNode MoveLeft(SearchNode current)
        {
            var spaceIndex = GetSpaceIndex(current);
            if (spaceIndex % 3 == 0)
                return null;

            var left = new SearchNode
            {
                Status = new int[current.Status.Length],
                Steps = current.Steps + 1
            };
            Array.Copy(current.Status, left.Status, current.Status.Length);
            var temp = left.Status[spaceIndex];
            left.Status[spaceIndex] = left.Status[spaceIndex - 1];
            left.Status[spaceIndex - 1] = temp;
            return left;
        }

        /// <summary>
        /// 尝试将空格上移。
        /// </summary>
        /// <param name="current">当前状态。</param>
        /// <returns></returns>
        protected SearchNode MoveUp(SearchNode current)
        {
            var spaceIndex = GetSpaceIndex(current);
            if (spaceIndex - 3 < 0)
                return null;

            var up = new SearchNode
            {
                Status = new int[current.Status.Length],
                Steps = current.Steps + 1
            };
            Array.Copy(current.Status, up.Status, current.Status.Length);
            var temp = up.Status[spaceIndex];
            up.Status[spaceIndex] = up.Status[spaceIndex - 3];
            up.Status[spaceIndex - 3] = temp;
            return up;
        }

        /// <summary>
        /// 尝试把空格移到下方。
        /// </summary>
        /// <param name="current">当前状态。</param>
        /// <returns></returns>
        protected SearchNode MoveDown(SearchNode current)
        {
            var spaceIndex = GetSpaceIndex(current);
            if (spaceIndex + 3 >= current.Status.Length)
                return null;

            var down = new SearchNode
            {
                Status = new int[current.Status.Length],
                Steps = current.Steps + 1
            };
            Array.Copy(current.Status, down.Status, current.Status.Length);
            var temp = down.Status[spaceIndex];
            down.Status[spaceIndex] = down.Status[spaceIndex + 3];
            down.Status[spaceIndex + 3] = temp;
            return down;
        }
    }
}
