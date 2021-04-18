using System;
using SortApplication;

namespace _2._5._17
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
            var data = new[] { 7, 7, 4, 8, 8, 5, 1, 7, 7 };
            var merge = new MergeSort();
            var insertion = new InsertionSort();
            var shell = new ShellSort();
            var selection = new SelectionSort();
            var quick = new QuickSort();

            Console.WriteLine("Merge Sort: " + CheckStability(data, merge));
            Console.WriteLine("Insertion Sort: " + CheckStability(data, insertion));
            Console.WriteLine("Shell Sort: " + CheckStability(data, shell));
            Console.WriteLine("Selection Sort: " + CheckStability(data, selection));
            Console.WriteLine("Quick Sort: " + CheckStability(data, quick));
        }

        static bool CheckStability<T>(T[] data, BaseSort sort) where T : IComparable<T>
        {
            var items = new Wrapper<T>[data.Length];
            for (var i = 0; i < data.Length; i++)
                items[i] = new Wrapper<T>(i, data[i]);
            sort.Sort(items);
            var index = 0;
            while (index < data.Length - 1)
            {
                while (index < data.Length - 1 && items[index].Key.Equals(items[index + 1].Key))
                {
                    if (items[index].Index > items[index + 1].Index)
                        return false;
                    index++;
                }
                index++;
            }
            return true;
        }
    }
}
