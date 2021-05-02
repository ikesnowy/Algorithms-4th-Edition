using System;

namespace SortData
{
    public static class DataManager
    {
        public static int[] GetUnsortedData()
        {
            var split = new[] { '\n', '\r' };
            var unsortedString = Properties.Resources._32Kints.Split(split, StringSplitOptions.RemoveEmptyEntries);
            var unsorted = new int[unsortedString.Length];
            for (var i = 0; i < unsortedString.Length; i++)
            {
                unsorted[i] = int.Parse(unsortedString[i]);
            }
            return unsorted;
        }

        public static int[] GetSortedData()
        {
            var split = new[] { '\n', '\r' };
            var sortedString = Properties.Resources._32kints_sorted.Split(split, StringSplitOptions.RemoveEmptyEntries);
            var sorted = new int[sortedString.Length];
            for (var i = 0; i < sortedString.Length; i++)
            {
                sorted[i] = int.Parse(sortedString[i]);
            }
            return sorted;
        }
    }
}
