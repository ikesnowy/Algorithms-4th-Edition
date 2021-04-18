using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    /// <summary>
    /// 背包类。
    /// </summary>
    /// <typeparam name="Item">背包中存放的元素类型。</typeparam>
    public class Bag<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private int count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Bag()
        {
            first = null;
            count = 0;
        }

        /// <summary>
        /// 背包是否为空。
        /// </summary>
        /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty()
        {
            return first == null;
        }

        /// <summary>
        /// 获得背包中元素的数量。
        /// </summary>
        /// <returns>背包中元素的数量。</returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 向背包中添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void Add(Item item)
        {
            var oldFirst = first;
            first = new Node<Item>();
            first.item = item;
            first.next = oldFirst;
            count++;
        }

        /// <summary>
        /// 获得枚举器。
        /// </summary>
        /// <returns>返回枚举器对象。</returns>
        public IEnumerator<Item> GetEnumerator()
        {
            return new BagEnumerator(first);
        }

        /// <summary>
        /// 获得枚举器。
        /// </summary>
        /// <returns>背包枚举器对象。</returns>
        /// <remarks>这个方法实际上调用的是 <see cref="GetEnumerator"/>。</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 背包枚举器类。
        /// </summary>
        private class BagEnumerator : IEnumerator<Item>
        {
            private Node<Item> current;
            private Node<Item> first;

            Item IEnumerator<Item>.Current => current.item;

            object IEnumerator.Current => current.item;

            /// <summary>
            /// 构造一个背包枚举器。
            /// </summary>
            /// <param name="first">背包的第一个结点。</param>
            public BagEnumerator(Node<Item> first)
            {
                current = new Node<Item>();
                current.next = first;
                this.first = current;
            }

            void IDisposable.Dispose()
            {
                current = null;
                first = null;
                return;
            }

            bool IEnumerator.MoveNext()
            {
                if (current.next == null)
                    return false;

                current = current.next;
                return true;
            }

            void IEnumerator.Reset()
            {
                current = first;
            }
        }
    }


}
