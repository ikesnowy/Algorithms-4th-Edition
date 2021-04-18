namespace UnionFind
{
    /// <summary>
    /// 用 QuickFind 算法实现的并查集。
    /// </summary>
    public class QuickFindUf : Uf
    {
        /// <summary>
        /// 记录数组访问次数的计数器。
        /// </summary>
        /// <value>记录数组访问的计数器。</value>
        public int ArrayVisitCount { get; private set; }

        /// <summary>
        /// 新建一个使用 quick-find 实现的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public QuickFindUf(int n) : base(n) { }

        /// <summary>
        /// 重置数组访问计数。
        /// </summary>
        public void ResetArrayCount()
        {
            ArrayVisitCount = 0;
        }
        
        /// <summary>
        /// 寻找 p 所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns><paramref name="p"/> 所在的连通分量。</returns>
        public override int Find(int p)
        {
            Validate(p);
            ArrayVisitCount++;
            return parent[p];
        }

        /// <summary>
        /// 判断两个结点是否属于同一个连通分量。
        /// </summary>
        /// <param name="p">需要判断的结点。</param>
        /// <param name="q">需要判断的另一个结点。</param>
        /// <returns>如果属于同一个连通分量则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public override bool IsConnected(int p, int q)
        {
            Validate(p);
            Validate(q);
            ArrayVisitCount += 2;
            return parent[p] == parent[q];
        }

        /// <summary>
        /// 将两个结点所在的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public override void Union(int p, int q)
        {
            Validate(p);
            Validate(q);
            var pId = parent[p];
            var qId = parent[q];
            ArrayVisitCount += 2;

            // 如果两个结点同属于一个连通分量，那么什么也不做。
            if (pId == qId)
            {
                return;
            }

            for (var i = 0; i < parent.Length; i++)
            {
                if (parent[i] == pId)
                {
                    parent[i] = qId;
                    ArrayVisitCount++;
                }
            }

            ArrayVisitCount += parent.Length;
            count--;
            return;
        }

        /// <summary>
        /// 获得 parent 数组。
        /// </summary>
        /// <returns>parent 数组。</returns>
        public int[] GetParent()
        {
            return parent;
        }
    }
}
