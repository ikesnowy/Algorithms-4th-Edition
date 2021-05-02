using Generics;
// ReSharper disable InconsistentNaming

namespace _1._3._49
{
    /// <summary>
    /// 用六个栈模拟的队列。
    /// </summary>
    /// <typeparam name="TItem">队列中保存的元素。</typeparam>
    internal class StackQueue<TItem>
    {
        Stack<TItem> H;
        Stack<TItem> T;
        Stack<TItem> h;
        Stack<TItem> HH;
        Stack<TItem> TT;
        Stack<TItem> Hr;

        private bool _isRecopying;
        private int _nowCopying;

        public StackQueue()
        {
            _isRecopying = false;
            _nowCopying = 0;

            H = new Stack<TItem>();
            T = new Stack<TItem>();
            h = new Stack<TItem>();
            HH = new Stack<TItem>();
            TT = new Stack<TItem>();
            Hr = new Stack<TItem>();
        }

        public TItem Peek()
        {
            if (_isRecopying)
            {
                return h.Peek();
            }
            else
            {
                return H.Peek();
            }
        }

        public void Enqueue(TItem item)
        {
            if (!_isRecopying && Lendiff() > 0)
            {
                _nowCopying = 0;
                T.Push(item);
            }
            else if (!_isRecopying && Lendiff() == 0)
            {
                T.Push(item);
                _isRecopying = true;
                h = H.Copy();
                OneStep(OneStep(this));
            }
            else if (_isRecopying)
            {
                TT.Push(item);
                OneStep(OneStep(this));
            }
        }

        public int Lendiff()
        {
            return H.Size() - T.Size();
        }

        public TItem Dequeue()
        {
            if (!_isRecopying && Lendiff() > 0)
            {
                return H.Pop();
            }
            else if (!_isRecopying && Lendiff() == 0)
            {
                var temp = H.Pop();
                h = H.Copy();
                _isRecopying = true;
                OneStep(OneStep(this));
                return temp;
            }
            else
            {
                var temp = h.Pop();
                _nowCopying--;
                OneStep(OneStep(this));
                return temp;
            }
        }

        private static StackQueue<TItem> OneStep(StackQueue<TItem> q)
        {
            if (q._isRecopying && !q.H.IsEmpty() && !q.T.IsEmpty())
            {
                q._nowCopying++;
                q.HH.Push(q.T.Pop());
                q.Hr.Push(q.H.Pop());
            }
            else if (q._isRecopying && q.H.IsEmpty() && !q.T.IsEmpty())
            {
                q._isRecopying = true;
                q.HH.Push(q.T.Pop());
            }
            else if (q._isRecopying && q.H.IsEmpty() && q.T.IsEmpty() && q._nowCopying > 1)
            {
                q._isRecopying = true;
                q._nowCopying--;
                q.HH.Push(q.Hr.Pop());
            }
            else if (q._isRecopying && q.H.IsEmpty() && q.T.IsEmpty() && q._nowCopying == 1)
            {
                q._isRecopying = false;
                q._nowCopying--;
                q.HH.Push(q.Hr.Pop());
                q.H = q.HH;
                q.T = q.TT;
                q.HH = new Stack<TItem>();
                q.TT = new Stack<TItem>();
                q.Hr = new Stack<TItem>();
                q.h = new Stack<TItem>();
            }
            else if (q._isRecopying && q.H.IsEmpty() && q.T.IsEmpty() && q._nowCopying == 0)
            {
                q._isRecopying = false;
                q.H = q.HH;
                q.T = q.TT;
                q.HH = new Stack<TItem>();
                q.TT = new Stack<TItem>();
                q.Hr = new Stack<TItem>();
                q.h = new Stack<TItem>();
            }
            return q;
        }
    }
}
