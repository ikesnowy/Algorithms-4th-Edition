namespace UnionFind
{
    /// <summary>
    /// 按照高度加权的 Quick-Union 并查集。
    /// </summary>
    public class WeightedQuickUnionByHeightUf : QuickUnionUf
    {
        private readonly int[] _height;

        /// <summary>
        /// 新建一个以高度作为判断依据的加权 quick-union 并查集。
        /// </summary>
        /// <param name="n">新建并查集的大小。</param>
        public WeightedQuickUnionByHeightUf(int n) : base(n)
        {
            _height = new int[n];
            for (var i = 0; i < n; i++)
            {
                _height[i] = 0;
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

            if (_height[rootP] < _height[rootQ])
            {
                Parent[rootP] = rootQ;
            }
            else if (_height[rootP] > _height[rootQ])
            {
                Parent[rootQ] = rootP;
            }
            else
            {
                Parent[rootQ] = rootP;
                _height[rootP]++;
            }
            TotalCount--;
        }
    }
}
