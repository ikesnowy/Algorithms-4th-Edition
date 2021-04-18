using System;

namespace _2._1._38
{
    class Pair<TKey, TValue> : IComparable<Pair<TKey, TValue>> where TKey : IComparable<TKey>
    {
        TKey _key;
        TValue _value;

        public Pair(TKey key, TValue value)
        {
            this._key = key;
            this._value = value;
        }

        public int CompareTo(Pair<TKey, TValue> other)
        {
            return _key.CompareTo(other._key);
        }
    }
}
