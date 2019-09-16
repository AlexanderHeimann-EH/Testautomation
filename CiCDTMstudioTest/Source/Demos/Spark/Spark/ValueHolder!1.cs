namespace Spark
{
    using System;

    public class ValueHolder<TValue>
    {
        private Func<TValue> _acquire;
        private TValue _value;

        public ValueHolder(Func<TValue> acquire)
        {
            this._acquire = acquire;
        }

        public TValue Value
        {
            get
            {
                if (this._acquire != null)
                {
                    lock (((ValueHolder<TValue>) this))
                    {
                        if (this._acquire != null)
                        {
                            this._value = this._acquire();
                            this._acquire = null;
                        }
                    }
                }
                return this._value;
            }
        }
    }
}

