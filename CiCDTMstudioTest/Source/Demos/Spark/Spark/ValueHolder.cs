namespace Spark
{
    using System;

    public static class ValueHolder
    {
        public static ValueHolder<TValue> For<TValue>(Func<TValue> acquire)
        {
            return new ValueHolder<TValue>(acquire);
        }

        public static ValueHolder<TKey, TValue> For<TKey, TValue>(TKey key, Func<TValue> acquire)
        {
            return new ValueHolder<TKey, TValue>(key, acquire);
        }

        public static ValueHolder<TKey, TValue> For<TKey, TValue>(TKey key, Func<TKey, TValue> acquire)
        {
            return new ValueHolder<TKey, TValue>(key, acquire);
        }
    }
}

