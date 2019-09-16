namespace Spark
{
    using System;

    public interface ICompiledViewHolder
    {
        ISparkViewEntry Lookup(SparkViewDescriptor descriptor);
        ISparkViewEntry Lookup(Guid viewId);
        void Store(ISparkViewEntry entry);
    }
}

