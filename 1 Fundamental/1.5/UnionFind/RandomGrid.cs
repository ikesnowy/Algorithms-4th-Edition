using System;
using System.Collections.Generic;
// ReSharper disable CognitiveComplexity

namespace UnionFind
{
    /// <summary>
    /// 随机网格类。
    /// </summary>
    public class RandomGrid
    {
        /// <summary>
        /// 随机生成 n × n 网格中的所有连接。
        /// </summary>
        /// <param name="n">网格边长。</param>
        /// <returns>随机排序的连接。</returns>
        public static RandomBag<Connection> Generate(int n)
        {
            var result = new RandomBag<Connection>();
            var random = new Random();

            // 建立横向连接
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n - 1; j++)
                {
                    if (random.Next(10) > 4)
                    {
                        result.Add(new Connection(i * n + j, (i * n) + j + 1));
                    }
                    else
                    {
                        result.Add(new Connection((i * n) + j + 1, i * n + j));
                    }
                }
            }

            // 建立纵向连接
            for (var j = 0; j < n; j++)
            {
                for (var i = 0; i < n - 1; i++)
                {
                    if (random.Next(10) > 4)
                    {
                        result.Add(new Connection(i * n + j, ((i + 1) * n) + j));
                    }
                    else
                    {
                        result.Add(new Connection(((i + 1) * n) + j, i * n + j));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 随机生成 n × n 网格中的所有连接，返回一个连接数组。
        /// </summary>
        /// <param name="n">网格边长。</param>
        /// <returns>连接数组。</returns>
        public static Connection[] GetConnections(int n)
        {
            var bag = Generate(n);
            var connections = new List<Connection>();

            foreach (var c in bag)
            {
                connections.Add(c);
            }

            return connections.ToArray();
        }
    }
}
