namespace Spark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompiledViewHolder : ICompiledViewHolder
    {
        private readonly Dictionary<SparkViewDescriptor, ISparkViewEntry> _cache = new Dictionary<SparkViewDescriptor, ISparkViewEntry>();

        public ISparkViewEntry Lookup(SparkViewDescriptor descriptor)
        {
            ISparkViewEntry entry;
            lock (this._cache)
            {
                if (!this._cache.TryGetValue(descriptor, out entry))
                {
                    return null;
                }
            }
            if (!entry.IsCurrent())
            {
                return null;
            }
            return entry;
        }

        public ISparkViewEntry Lookup(Guid viewId)
        {
            Func<ISparkViewEntry, bool> predicate = null;
            lock (this._cache)
            {
                if (predicate == null)
                {
                    predicate = e => e.ViewId == viewId;
                }
                return this._cache.Values.FirstOrDefault<ISparkViewEntry>(predicate);
            }
        }

        public void Store(ISparkViewEntry entry)
        {
            lock (this._cache)
            {
                this._cache[entry.Descriptor] = entry;
            }
        }
    }
}

