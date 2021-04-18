using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._1
{
    /// <summary>
    /// 固定大小的整型数据栈。
    /// </summary>
    class FixedCapacityStackOfStrings : IEnumerable<string>
    {
        private readonly string[] a;
        private int N;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        /// <param name="capacity">栈的大小。</param>
        public FixedCapacityStackOfStrings(int capacity)
        {
            a = new string[capacity];
            N = 0;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return N == 0;
        }

        /// <summary>
        /// 检查栈是否已满。
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return N == a.Length;
        }

        /// <summary>
        /// 将一个元素压入栈中。
        /// </summary>
        /// <param name="item">要压入栈中的元素。</param>
        public void Push(string item)
        {
            a[N] = item;
            N++;
        }

        /// <summary>
        /// 从栈中弹出一个元素，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public string Pop()
        {
            N--;
            return a[N];
        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public string Peek()
        {
            return a[N - 1];
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new ReverseEnmerator(a);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ReverseEnmerator : IEnumerator<string>
        {
            private int current;
            private string[] a;

            public ReverseEnmerator(string[] a)
            {
                current = a.Length;
                this.a = a;
            }

            string IEnumerator<string>.Current => a[current];

            object IEnumerator.Current => a[current];

            void IDisposable.Dispose()
            {
                current = -1;
                a = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (current == 0)
                    return false;
                current--;
                return true;
            }

            void IEnumerator.Reset()
            {
                current = a.Length;
            }
        }
    }
}
