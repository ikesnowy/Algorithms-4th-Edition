using System;
using System.IO;
using SymbolTable;

namespace _3._1._9
{
    /// <summary>
    /// 计算文本文档中出现次数最高的字符串，
    /// 用于测试符号表的 Get 和 Put 方法。
    /// </summary>
    public class FrequencyCounter
    {
        /// <summary>
        /// 这个类不能被初始化。
        /// </summary>
        private FrequencyCounter() { }

        /// <summary>
        /// 获得指定文本文档中出现频率最高的字符串。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns>文本文档出现频率最高的字符串。</returns>
        public static string MostFrequentlyWord(string filename, int minLength, IST<string, int> st)
        {
            int distinct = 0, words = 0;
            var sr = new StreamReader(File.OpenRead(filename));

            var inputs = 
                sr
                .ReadToEnd()
                .Split(new[] { ' ', '\r', '\n' }, 
                StringSplitOptions.RemoveEmptyEntries);

            var lastPut = "";
            foreach (var s in inputs)
            {
                if (s.Length < minLength)
                    continue;
                words++;
                if (st.Contains(s))
                {
                    lastPut = s;
                    st.Put(s, st.Get(s) + 1);
                }
                else
                {
                    lastPut = s;
                    st.Put(s, 1);
                    distinct++;
                }
            }

            Console.WriteLine("Last Put: " + lastPut + "\t words count: " + words);

            var max = "";
            st.Put(max, 0);
            foreach (var s in st.Keys())
                if (st.Get(s) > st.Get(max))
                    max = s;

            return max;
        }

        /// <summary>
        /// 计算数组中不重复元素的数量。
        /// </summary>
        /// <typeparam name="TKey">数组元素的类型。</typeparam>
        /// <param name="keys">包含重复元素的数组。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns><paramref name="keys"/> 中的不重复元素数量。</returns>
        public static int CountDistinct<TKey>(TKey[] keys, IST<TKey, int> st)
        {
            var distinct = 0;
            for (var i = 0; i < keys.Length; i++)
            {
                if (!st.Contains(keys[i]))
                    st.Put(keys[i], distinct++);
            }
            return distinct;
        }
    }
}
