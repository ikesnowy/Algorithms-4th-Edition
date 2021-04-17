using System;
using SortApplication;

namespace _2._5._18
{
    class Program
    {
        class Wrapper<T> : IComparable<Wrapper<T>> where T : IComparable<T>
        {
            public int Index;
            public T Key;

            public Wrapper(int index, T elements)
            {
                Index = index;
                Key = elements;
            }

            public int CompareTo(Wrapper<T> other)
            {
                return Key.CompareTo(other.Key);
            }
        }

        static void Main(string[] args)
        {
            var data = new int[] { 5, 7, 3, 4, 7, 3, 6, 3, 3 };
            var quick = new QuickSort();
            var shell = new ShellSort();
            Console.WriteLine(@"Quick Sort");
            Stabilize(data, quick);
            Console.WriteLine();
            Console.WriteLine(@"Shell Sort");
            Stabilize(data, shell);
        }

        static void Stabilize<T>(T[] data, BaseSort sort) where T : IComparable<T>
        {
            var items = new Wrapper<T>[data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                items[i] = new Wrapper<T>(i, data[i]);
            }

            sort.Sort(items);

            Console.Write("Index:\t");
            for (var i = 0; i < items.Length; i++)
            {
                Console.Write(items[i].Index + " ");
            }
            Console.WriteLine();
            Console.Write("Elem:\t");
            for (var i = 0; i < items.Length; i++)
            {
                Console.Write(items[i].Key + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            var index = 0;
            while (index < items.Length - 1)
            {
                while (index < items.Length - 1 &&
                    items[index].Key.Equals(items[index + 1].Key))
                {
                    // 插入排序
                    for (var j = index + 1; j > 0 && items[j].Index < items[j - 1].Index; j--)
                    {
                        if (!items[j].Key.Equals(items[j - 1].Key))
                            break;
                        var temp = items[j];
                        items[j] = items[j - 1];
                        items[j - 1] = temp;
                    }
                    index++;
                }
                index++;
            }

            Console.Write("Index:\t");
            for (var i = 0; i < items.Length; i++)
            {
                Console.Write(items[i].Index + " ");
            }
            Console.WriteLine();
            Console.Write("Elem:\t");
            for (var i = 0; i < items.Length; i++)
            {
                Console.Write(items[i].Key + " ");
            }
            Console.WriteLine();
        }
    }
}
