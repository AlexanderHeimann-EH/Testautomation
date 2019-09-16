namespace Spark
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Web.Caching;

    public class CacheExpires
    {
        private static Spark.CacheExpires _empty = new Spark.CacheExpires();

        public CacheExpires()
        {
            this.Absolute = NoAbsoluteExpiration;
            this.Sliding = NoSlidingExpiration;
        }

        public CacheExpires(DateTime absolute)
        {
            this.Absolute = absolute;
            this.Sliding = NoSlidingExpiration;
        }

        public CacheExpires(double sliding) : this(TimeSpan.FromSeconds(sliding))
        {
        }

        public CacheExpires(TimeSpan sliding)
        {
            this.Absolute = NoAbsoluteExpiration;
            this.Sliding = sliding;
        }

        public DateTime Absolute { get; set; }

        public static Spark.CacheExpires Empty
        {
            get
            {
                return _empty;
            }
        }

        public static DateTime NoAbsoluteExpiration
        {
            get
            {
                return Cache.NoAbsoluteExpiration;
            }
        }

        public static TimeSpan NoSlidingExpiration
        {
            get
            {
                return Cache.NoSlidingExpiration;
            }
        }

        public TimeSpan Sliding { get; set; }
    }
}

