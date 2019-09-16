namespace Spark
{
    using System;

    public interface ICacheService
    {
        object Get(string identifier);
        void Store(string identifier, CacheExpires expires, ICacheSignal signal, object item);
    }
}

