namespace _2._1._26
{
    /// <summary>
    /// 插入排序类。
    /// </summary>
    public class InsertionSort
    {
        /// <summary>
        /// 利用插入排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public void Sort(int[] a)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                for (var j = i; j > 0 && a[j] < a[j - 1]; --j)
                {
                    var t = a[j];
                    a[j] = a[j - 1];
                    a[j - 1] = t;
                }
            }
        }
    }
}
