using System;
using System.Collections;
using System.Collections.Generic;

namespace PriorityQueue
{
    /// <summary>
    /// 索引优先队列。
    /// </summary>
    /// <typeparam name="TKey">优先队列中包含的元素。</typeparam>
    public class IndexMaxPq<TKey> : IEnumerable<int> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 优先队列中的元素。
        /// </summary>
        private int _n;
        /// <summary>
        /// 索引最大堆。
        /// </summary>
        private readonly int[] _pq;
        /// <summary>
        /// pq 的逆索引，pq[qp[i]]=qp[pq[i]]=i
        /// </summary>
        private readonly int[] _qp;
        /// <summary>
        /// 实际元素。
        /// </summary>
        private readonly TKey[] _keys;

        /// <summary>
        /// 建立指定大小的面向索引的最大堆。
        /// </summary>
        /// <param name="capacity">最大堆的容量。</param>
        public IndexMaxPq(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            _n = 0;
            _keys = new TKey[capacity + 1];
            _pq = new int[capacity + 1];
            _qp = new int[capacity + 1];
            for (var i = 0; i <= capacity; i++)
                _qp[i] = -1;
        }

        /// <summary>
        /// 将与索引 <paramref name="i"/> 相关联的元素换成 <paramref name="k"/>。
        /// </summary>
        /// <param name="i">要修改关联元素的索引。</param>
        /// <param name="k">用于替换的新元素。</param>
        public void ChangeKey(int i, TKey k)
        {
            if (!Contains(i))
                throw new ArgumentNullException(nameof(i), "队列中没有该索引");
            _keys[i] = k;
            Swim(_qp[i]);
            Sink(_qp[i]);
        }

        /// <summary>
        /// 确认堆包含某个索引 <paramref name="i"/>。
        /// </summary>
        /// <param name="i">要查询的索引。</param>
        /// <returns>包含则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(int i) => _qp[i] != -1;

        /// <summary>
        /// 删除索引 <paramref name="i"/> 对应的键值。
        /// </summary>
        /// <param name="i">要清空的索引。</param>
        public void Delete(int i)
        {
            if (!Contains(i))
                throw new ArgumentOutOfRangeException(nameof(i), "index is not in the priority queue");
            var index = _qp[i];
            Exch(index, _n--);
            Swim(index);
            Sink(index);
            _keys[i] = default(TKey);
            _qp[i] = -1;
        }

        /// <summary>
        /// 删除并获得最大元素所在的索引。
        /// </summary>
        /// <returns>最大元素所在的索引。</returns>
        public int DelMax()
        {
            if (_n == 0)
                throw new InvalidOperationException("Priority Queue Underflow");
            var max = _pq[1];
            Exch(1, _n--);
            Sink(1);

            _qp[max] = -1;
            _keys[max] = default(TKey);
            _pq[_n + 1] = -1;
            return max;
        }

        /// <summary>
        /// 将索引 <paramref name="i"/> 对应的键值减少为 <paramref name="key"/>。
        /// </summary>
        /// <param name="i">要修改的索引。</param>
        /// <param name="key">减少后的键值。</param>
        public void DecreaseKey(int i, TKey key)
        {
            if (!Contains(i))
                throw new ArgumentOutOfRangeException(nameof(i), "index is not in the priority queue");
            if (_keys[i].CompareTo(key) <= 0)
                throw new ArgumentException("Calling IncreaseKey() with given argument would not strictly increase the Key");

            _keys[i] = key;
            Sink(_qp[i]);
        }

        /// <summary>
        /// 将索引 <paramref name="i"/> 对应的键值增加为 <paramref name="key"/>。
        /// </summary>
        /// <param name="i">要修改的索引。</param>
        /// <param name="key">增加后的键值。</param>
        public void IncreaseKey(int i, TKey key)
        {
            if (!Contains(i))
                throw new ArgumentOutOfRangeException(nameof(i), "index is not in the priority queue");
            if (_keys[i].CompareTo(key) >= 0)
                throw new ArgumentException("Calling IncreaseKey() with given argument would not strictly increase the Key");

            _keys[i] = key;
            Swim(_qp[i]);
        }

        /// <summary>
        /// 将元素 <paramref name="v"/> 与索引 <paramref name="i"/> 关联。
        /// </summary>
        /// <param name="v">待插入元素。</param>
        /// <param name="i">需要关联的索引。</param>
        public void Insert(TKey v, int i)
        {
            if (Contains(i))
                throw new ArgumentException("索引已存在");
            _n++;
            _qp[i] = _n;
            _pq[_n] = i;
            _keys[i] = v;
            Swim(_n);
        }

        /// <summary>
        /// 堆是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => _n == 0;

        /// <summary>
        /// 获得与索引 <paramref name="i"/> 关联的元素。
        /// </summary>
        /// <param name="i">索引。</param>
        /// <returns>与索引 <paramref name="i"/> 关联的元素。</returns>
        /// <exception cref="ArgumentNullException">当队列中没有 <paramref name="i"/> 时抛出该异常。</exception>
        public TKey KeyOf(int i)
        {
            if (!Contains(i))
                throw new ArgumentNullException(nameof(i), "队列中没有该索引");
            return _keys[i];
        }

        /// <summary>
        /// 返回最大元素对应的索引。
        /// </summary>
        /// <returns>最大元素对应的索引。</returns>
        /// <exception cref="ArgumentOutOfRangeException">当优先队列为空时抛出该异常。</exception>
        public int MaxIndex()
        {
            if (_n == 0)
                throw new InvalidOperationException("Priority Queue Underflow");
            return _pq[1];
        }

        /// <summary>
        /// 获得最大元素。
        /// </summary>
        /// <returns>最大的元素。</returns>
        /// <exception cref="ArgumentOutOfRangeException">当优先队列为空时抛出该异常。</exception>
        public TKey MaxKey()
        {
            if (_n == 0)
                throw new InvalidOperationException("Priority Queue Underflow");
            return _keys[_pq[1]];
        }

        /// <summary>
        /// 返回堆的元素数量。
        /// </summary>
        /// <returns>堆的元素数量。</returns>
        public int Size() => _n;

        /// <summary>
        /// 比较第一个元素是否小于第二个元素。
        /// </summary>
        /// <param name="i">第一个元素。</param>
        /// <param name="j">第二个元素。</param>
        /// <returns>如果堆中索引为 <paramref name="i"/> 的元素较小则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Less(int i, int j) 
            => _keys[_pq[i]].CompareTo(_keys[_pq[j]]) < 0;

        /// <summary>
        /// 交换两个元素。
        /// </summary>
        /// <param name="i">要交换的元素下标。</param>
        /// <param name="j">要交换的元素下标。</param>
        private void Exch(int i, int j)
        {
            var swap = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = swap;
            _qp[_pq[i]] = i;
            _qp[_pq[j]] = j;
        }

        /// <summary>
        /// 使下标为 <paramref name="k"/> 的元素上浮。
        /// </summary>
        /// <param name="k">上浮元素下标。</param>
        private void Swim(int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Exch(k / 2, k);
                k /= 2;
            }
        }

        /// <summary>
        /// 使下标为 <paramref name="k"/> 元素下沉。
        /// </summary>
        /// <param name="k">需要下沉的元素。</param>
        private void Sink(int k)
        {
            while (k * 2 <= _n)
            {
                var j = 2 * k;
                if (j < _n && Less(j, j + 1))
                    j++;
                if (!Less(k, j))
                    break;
                Exch(k, j);
                k = j;
            }
        }

        /// <summary>
        /// 获取迭代器。
        /// </summary>
        /// <returns>最大堆的迭代器。</returns>
        public IEnumerator<int> GetEnumerator()
        {
            var copy = new IndexMaxPq<TKey>(_n);
            for (var i = 0; i < _n; i++)
                copy.Insert(_keys[_pq[i]], _pq[i]);

            while (!copy.IsEmpty())
                yield return copy.DelMax();
        }

        /// <summary>
        /// 获取迭代器。
        /// </summary>
        /// <returns>迭代器。</returns>
        /// <remarks>该方法实际调用的是 <see cref="GetEnumerator"/>。</remarks>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
