using Spark.Compiler;

namespace Spark
{
    using System;
    using System.Collections.Generic;

    public interface ISparkViewEntry
    {
        ISparkView CreateInstance();
        bool IsCurrent();
        void ReleaseInstance(ISparkView view);

        SparkViewDescriptor Descriptor { get; }

        string SourceCode { get; }

        IList<SourceMapping> SourceMappings { get; }

        Guid ViewId { get; }
    }
}

