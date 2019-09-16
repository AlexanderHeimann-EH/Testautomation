namespace Spark.Caching
{
    using Spark;
    using System;
    using System.Web.Caching;

    public class DefaultCacheService : ICacheService
    {
        private readonly Cache _cache;

        public DefaultCacheService(Cache cache)
        {
            this._cache = cache;
        }

        public object Get(string identifier)
        {
            return this._cache.Get(identifier);
        }

        public void Store(string identifier, Spark.CacheExpires expires, ICacheSignal signal, object item)
        {
            this._cache.Insert(identifier, item, SignalDependency.For(signal), (expires ?? Spark.CacheExpires.Empty).Absolute, (expires ?? Spark.CacheExpires.Empty).Sliding);
        }

        private class SignalDependency : CacheDependency
        {
            private readonly ICacheSignal _signal;

            private SignalDependency(ICacheSignal signal)
            {
                this._signal = signal;
                this._signal.Changed += new EventHandler(this.SignalChanged);
            }

            protected override void DependencyDispose()
            {
                this._signal.Changed -= new EventHandler(this.SignalChanged);
            }

            ~SignalDependency()
            {
                this._signal.Changed -= new EventHandler(this.SignalChanged);
            }

            public static CacheDependency For(ICacheSignal signal)
            {
                if (signal != null)
                {
                    return new DefaultCacheService.SignalDependency(signal);
                }
                return null;
            }

            private void SignalChanged(object sender, EventArgs e)
            {
                base.NotifyDependencyChanged(this, e);
            }
        }
    }
}

