namespace Quick
{
    /// <summary>
    /// 用于将只有两种元素的数组排序。
    /// </summary>
    public class Sort2Distinct : BaseSort
    {
        /// <summary>
        /// 对数组 a 进行排序。
        /// </summary>
        /// <typeparam name="T">数组 a 的元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            int lt = 0, gt = a.Length - 1;
            var i = 0;
            while (i <= gt)
            {
                var cmp = a[i].CompareTo(a[lt]);
                if (cmp < 0)
                    Exch(a, lt++, i++);
                else if (cmp > 0)
                    Exch(a, i, gt--);
                else
                    i++;
            }
        }
    }
}
