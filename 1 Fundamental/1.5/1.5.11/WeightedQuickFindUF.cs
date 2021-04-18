using System;

namespace _1._5._11
{
    /// <summary>
    /// 用加权 QuickFind 算法实现的并查集。
    /// </summary>
    public class WeightedQuickFindUf
    {
        private readonly int[] _size; // 记录每个连通分量的大小。
        private readonly int[] _id; // 记录每个结点的连通分量。
        private int _count;// 连通分量总数。

        public int ArrayVisitCount { get; private set; } //记录数组访问的次数。

        /// <summary>
        /// 新建一个使用加权 quick-find 实现的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public WeightedQuickFindUf(int n)
        {
            _count = n;
            _id = new int[n];
            _size = new int[n];
            for (var i = 0; i < n; i++)
            {
                _id[i] = i;
                _size[i] = 1;
            }
        }

        /// <summary>
        /// 重置数组访问计数。
        /// </summary>
        public void ResetArrayCount()
        {
            ArrayVisitCount = 0;
        }

        /// <summary>
        /// 表示并查集中连通分量的数量。
        /// </summary>
        /// <returns>返回并查集中连通分量的数量。</returns>
        public int Count()
        {
            return _count;
        }
        
        /// <summary>
        /// 寻找 p 所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>返回 p 所在的连通分量。</returns>
        public int Find(int p)
        {
            Validate(p);
            ArrayVisitCount++;
            return _id[p];
        }

        /// <summary>
        /// 判断两个结点是否属于同一个连通分量。
        /// </summary>
        /// <param name="p">需要判断的结点。</param>
        /// <param name="q">需要判断的另一个结点。</param>
        /// <returns>如果属于同一个连通分量则返回 true，否则返回 false。</returns>
        public bool IsConnected(int p, int q)
        {
            Validate(p);
            Validate(q);
            ArrayVisitCount += 2;
            return _id[p] == _id[q];
        }

        /// <summary>
        /// 将两个结点所在的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public void Union(int p, int q)
        {
            Validate(p);
            Validate(q);
            var pId = _id[p];
            var qId = _id[q];
            ArrayVisitCount += 2;

            // 如果两个结点同属于一个连通分量，那么什么也不做。
            if (pId == qId)
            {
                return;
            }

            // 判断较大的连通分量和较小的连通分量。
            var larger = 0;
            var smaller = 0;
            if (_size[pId] > _size[qId])
            {
                larger = pId;
                smaller = qId;
                _size[pId] += _size[qId];
            }
            else
            {
                larger = qId;
                smaller = pId;
                _size[qId] += _size[pId];
            }

            // 将较小的连通分量连接到较大的连通分量上，
            // 这会减少赋值语句的执行次数，略微减少数组访问。
            for (var i = 0; i < _id.Length; i++)
            {
                if (_id[i] == smaller)
                {
                    _id[i] = larger;
                    ArrayVisitCount++;
                }
            }

            ArrayVisitCount += _id.Length;
            _count--;
            return;
        }

        /// <summary>
        /// 获得 id 数组。
        /// </summary>
        /// <returns>id 数组。</returns>
        public int[] GetId()
        {
            return _id;
        }

        /// <summary>
        /// 验证输入的结点是否有效。
        /// </summary>
        /// <param name="p">需要验证的结点。</param>
        /// <exception cref="ArgumentException">输入的 p 值无效。</exception>
        private void Validate(int p)
        {
            var n = _id.Length;
            if (p < 0 || p > n)
            {
                throw new ArgumentException("index " + p + " is not between 0 and " + (n - 1));
            }
        }
    }
}
