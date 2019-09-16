namespace Spark
{
    using System;

    public class ValueHolder<TKey, TValue> : ValueHolder<TValue>
    {
        private readonly TKey _key;

        public ValueHolder(TKey key, Func<TValue> acquire) : base(acquire)
        {
            this._key = key;
        }

        public ValueHolder(TKey key, Func<TKey, TValue> acquire) : base(func)
        {
            Func<TValue> func = null;
            if (func == null)
            {
                func = () => acquire(key);
            }
            this._key = key;
        }

        public TKey Key
        {
            get
            {
                return this._key;
            }
        }
    }
}

