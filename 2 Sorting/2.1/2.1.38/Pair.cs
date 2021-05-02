using System;
// ReSharper disable NotAccessedField.Local

namespace _2._1._38
{
    class Pair<TKey, TValue> : IComparable<Pair<TKey, TValue>> where TKey : IComparable<TKey>
    {
        private TKey _key;
        private TValue _value;

        public Pair(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }

        public int CompareTo(Pair<TKey, TValue> other)
        {
            return _key.CompareTo(other._key);
        }
    }
}
