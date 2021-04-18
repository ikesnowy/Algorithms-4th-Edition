using Generics;

namespace _1._3._44
{
    /// <summary>
    /// 文本缓冲区。
    /// </summary>
    class Buffer
    {
        private readonly Stack<char> _leftside;
        private readonly Stack<char> _rightside;

        /// <summary>
        /// 建立一个文本缓冲区。
        /// </summary>
        public Buffer()
        {
            _leftside = new Stack<char>();
            _rightside = new Stack<char>();
        }

        /// <summary>
        /// 在光标位置插入字符 c。
        /// </summary>
        /// <param name="c">要插入的字符。</param>
        public void Insert(char c)
        {
            _leftside.Push(c);
        }

        /// <summary>
        /// 删除并返回光标位置的字符。
        /// </summary>
        /// <returns></returns>
        public char Delete()
        {
            return _leftside.Pop();
        }

        /// <summary>
        /// 将光标向左移动 k 个位置。
        /// </summary>
        /// <param name="k">光标移动的距离。</param>
        public void Left(int k)
        {
            for (var i = 0; i < k; i++)
            {
                _rightside.Push(_leftside.Pop());
            }
        }

        /// <summary>
        /// 将光标向右移动 k 个位置。
        /// </summary>
        /// <param name="k">光标移动的距离。</param>
        public void Right(int k)
        {
            for (var i = 0; i < k; i++)
            {
                _leftside.Push(_rightside.Pop());
            }
        }

        /// <summary>
        /// 返回缓冲区中的字符数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _leftside.Size() + _rightside.Size();
        }

        /// <summary>
        /// 将缓冲区的内容输出，这将使光标重置到最左端。
        /// </summary>
        /// <returns></returns>
        public string Getstring()
        {
            while (!_leftside.IsEmpty())
            {
                _rightside.Push(_leftside.Pop());
            }

            return _rightside.ToString();
        }
    }
}
