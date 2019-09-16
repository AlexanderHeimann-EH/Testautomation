namespace Spark
{
    using Spark.FileSystem;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public interface ISparkViewEngine
    {
        Assembly BatchCompilation(IList<SparkViewDescriptor> descriptors);
        Assembly BatchCompilation(string outputAssembly, IList<SparkViewDescriptor> descriptors);
        ISparkViewEntry CreateEntry(SparkViewDescriptor descriptor);
        ISparkView CreateInstance(SparkViewDescriptor descriptor);
        ISparkViewEntry GetEntry(SparkViewDescriptor descriptor);
        IList<SparkViewDescriptor> LoadBatchCompilation(Assembly assembly);
        void ReleaseInstance(ISparkView view);

        string DefaultPageBaseType { get; set; }

        ISparkExtensionFactory ExtensionFactory { get; set; }

        IResourcePathManager ResourcePathManager { get; set; }

        ISparkSettings Settings { get; }

        ISparkSyntaxProvider SyntaxProvider { get; set; }

        IViewActivatorFactory ViewActivatorFactory { get; set; }

        IViewFolder ViewFolder { get; set; }
    }
}

