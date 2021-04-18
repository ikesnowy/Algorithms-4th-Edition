namespace UnionFind
{
    /// <summary>
    /// 按照高度加权的 Quick-Union 并查集。
    /// </summary>
    public class WeightedQuickUnionByHeightUF : QuickUnionUF
    {
        private readonly int[] height;

        /// <summary>
        /// 新建一个以高度作为判断依据的加权 quick-union 并查集。
        /// </summary>
        /// <param name="n">新建并查集的大小。</param>
        public WeightedQuickUnionByHeightUF(int n) : base(n)
        {
            height = new int[n];
            for (var i = 0; i < n; i++)
            {
                height[i] = 0;
            }
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public override void Union(int p, int q)
        {
            var rootP = Find(p);
            var rootQ = Find(q);

            if (rootP == rootQ)
            {
                return;
            }

            if (height[rootP] < height[rootQ])
            {
                parent[rootP] = rootQ;
            }
            else if (height[rootP] > height[rootQ])
            {
                parent[rootQ] = rootP;
            }
            else
            {
                parent[rootQ] = rootP;
                height[rootP]++;
            }
            count--;
        }
    }
}
