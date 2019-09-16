namespace Spark.Parser
{
    using System;

    public class Paint<T> : Paint
    {
        public T Value
        {
            get
            {
                return (T) base.Value;
            }
            set
            {
                base.Value = value;
            }
        }
    }
}

