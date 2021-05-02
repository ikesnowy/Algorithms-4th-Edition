using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace BinarySearchTree
{
    /// <summary>
    /// 计算文本文档中出现次数最高的字符串，
    /// 用于测试符号表的 Get 和 Put 方法。
    /// </summary>
    public static class FrequencyCounter
    {
        /// <summary>
        /// 计算数组中不重复元素的数量。
        /// </summary>
        /// <typeparam name="TKey">数组元素的类型。</typeparam>
        /// <param name="keys">包含重复元素的数组。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns><paramref name="keys"/> 中的不重复元素数量。</returns>
        public static int CountDistinct<TKey>(TKey[] keys, ISt<TKey, int> st)
        {
            var distinct = 0;
            for (var i = 0; i < keys.Length; i++)
            {
                if (!st.Contains(keys[i]))
                    st.Put(keys[i], ++distinct);
            }
            return distinct;
        }

        /// <summary>
        /// 获得指定键中出现频率最高的键。
        /// </summary>
        /// <typeparam name="TKey">键类型。</typeparam>
        /// <param name="st">用于计算的符号表。</param>
        /// <param name="keys">所有的键。</param>
        /// <returns><paramref name="keys"/> 中出现频率最高的键。</returns>
        public static TKey MostFrequentlyKey<TKey>(ISt<TKey, int> st, TKey[] keys)
        {
            foreach (var s in keys)
            {
                if (st.Contains(s))
                    st.Put(s, st.Get(s) + 1);
                else
                    st.Put(s, 1);
            }

            var max = keys[0];
            foreach (var s in st.Keys())
                if (st.Get(s) > st.Get(max))
                    max = s;

            return max;
        }

        /// <summary>
        /// 获得指定文本文档中出现频率最高的字符串。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns>文本文档出现频率最高的字符串。</returns>
        public static string MostFrequentlyWord(string filename, int minLength, ISt<string, int> st)
        {
            var sr = new StreamReader(File.OpenRead(filename));

            var inputs = 
                sr
                .ReadToEnd()
                .Split(new[] { ' ', '\r', '\n' }, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in inputs)
            {
                if (s.Length < minLength)
                    continue;
                if (st.Contains(s))
                {
                    st.Put(s, st.Get(s) + 1);
                }
                else
                {
                    st.Put(s, 1);
                }
            }

            var max = "";
            st.Put(max, 0);
            foreach (var s in st.Keys())
                if (st.Get(s) > st.Get(max))
                    max = s;

            return max;
        }

        /// <summary>
        /// 获得指定文本文档中出现频率最高的字符串。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="counts">从文件读入的单词数目。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns>文本文档出现频率最高的字符串。</returns>
        public static string MostFrequentlyWord(string filename, int counts, int minLength, ISt<string, int> st)
        {
            var sr = new StreamReader(File.OpenRead(filename));

            var inputs =
                sr
                .ReadToEnd()
                .Split(new[] { ' ', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < counts && i < inputs.Length; i++)
            {
                if (inputs[i].Length < minLength)
                {
                    counts++;
                    continue;
                }

                if (st.Contains(inputs[i]))
                {
                    st.Put(inputs[i], st.Get(inputs[i]) + 1);
                }
                else
                {
                    st.Put(inputs[i], 1);
                }
            }

            var max = "";
            st.Put(max, 0);
            foreach (var s in st.Keys())
                if (st.Get(s) > st.Get(max))
                    max = s;

            return max;
        }

        /// <summary>
        /// 计算指定文本文档中出现频率最高的字符串，
        /// 保存 <see cref="ISt{TKey,TValue}.Get(TKey)"/> 
        /// 和 <see cref="ISt{TKey,TValue}.Put(TKey, TValue)"/>
        /// 的调用次数以及对应的耗时。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <param name="callIndex">调用次数。</param>
        /// <param name="timeRecord">对应耗时。</param>
        public static void MostFrequentlyWordAnalysis(string filename, int minLength, ISt<string, int> st, out int[] callIndex, out long[] timeRecord)
        {
            var call = new List<int>();
            var time = new List<long>();
            var sw = Stopwatch.StartNew();

            var callTime = 0;
            var sr = new StreamReader(File.OpenRead(filename));

            var inputs =
                sr
                .ReadToEnd()
                .Split(new[] { ' ', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < inputs.Length; i++)
            {
                if (inputs[i].Length < minLength)
                    continue;
                if (st.Contains(inputs[i]))
                {
                    st.Put(inputs[i], st.Get(inputs[i]) + 1);
                    callTime += 2;
                    time.Add(sw.ElapsedMilliseconds);
                    call.Add(callTime);
                }
                else
                {
                    st.Put(inputs[i], 1);
                    callTime++;
                    time.Add(sw.ElapsedMilliseconds);
                    call.Add(callTime);
                }
            }

            var max = "";
            st.Put(max, 0);
            callTime++;
            time.Add(sw.ElapsedMilliseconds);
            call.Add(callTime);
            foreach (var s in st.Keys())
            {
                if (st.Get(s) > st.Get(max))
                    max = s;
                callTime += 2;
                time.Add(sw.ElapsedMilliseconds);
                call.Add(callTime);
            }

            callIndex = call.ToArray();
            timeRecord = time.ToArray();
        }

        /// <summary>
        /// 获得指定文本文档中出现频率最高的所有字符串。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns>文本文档出现频率最高的字符串数组。</returns>
        public static string[] MostFrequentlyWords(string filename, int minLength, ISt<string, int> st)
        {
            var sr = new StreamReader(File.OpenRead(filename));

            var inputs =
                sr
                .ReadToEnd()
                .Split(new[] { ' ', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in inputs)
            {
                if (s.Length < minLength)
                    continue;
                if (st.Contains(s))
                {
                    st.Put(s, st.Get(s) + 1);
                }
                else
                {
                    st.Put(s, 1);
                }
            }

            var max = "";
            var queue = new Queue<string>();
            st.Put(max, 0);
            foreach (var s in st.Keys())
            {
                if (st.Get(s) > st.Get(max))
                {
                    max = s;
                    queue.Clear();
                    queue.Enqueue(s);
                }
                else if (st.Get(s) == st.Get(max))
                {
                    queue.Enqueue(s);
                }
            }

            return queue.ToArray();
        }
    }
}
