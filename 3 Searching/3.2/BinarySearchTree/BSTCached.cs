using System;

namespace BinarySearchTree
{
    /// <summary>
    /// 带有缓存的 BST。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public class BstCached<TKey, TValue> : Bst<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 上一次 <see cref="Get"/> 或 <see cref="Put"/> 方法操作的结点。
        /// </summary>
        private Node _cache;

        /// <inheritdoc />
        public override TValue Get(TKey key)
        {
            if (_cache != null && _cache.Key.CompareTo(key) == 0)
            {
                return _cache.Value;
            }

            return Get(root, key).Value;
        }

        /// <inheritdoc />
        protected override Node Get(Node x, TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("calls get() with a null key");
            }

            if (x == null)
            {
                return null;
            }
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
            {
                return Get(x.Left, key);
            }
            else if (cmp > 0)
            {
                return Get(x.Right, key);
            }
            else
            {
                _cache = x;
                return x;
            }
        }

        /// <inheritdoc />
        public override void Put(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("calls Put() with a null key");
            }

            if (value == null)
            {
                Delete(key);
                return;
            }

            if (_cache != null && _cache.Key.CompareTo(key) == 0)
            {
                _cache.Value = value;
                return;
            }
            root = Put(root, key, value);
        }

        /// <inheritdoc />
        protected override Node Put(Node x, TKey key, TValue value)
        {
            if (x == null)
            {
                _cache = new Node(key, value, 1);
                return _cache;
            }
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Put(x.Left, key, value);
            else if (cmp > 0)
                x.Right = Put(x.Right, key, value);
            else
                x.Value = value;
            x.Size = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }
    }
}