namespace Spark
{
    using Spark.Compiler;
    using System;

    public interface ISparkLanguageFactory
    {
        ViewCompiler CreateViewCompiler(ISparkViewEngine engine, SparkViewDescriptor descriptor);
        void InstanceCreated(ViewCompiler compiler, ISparkView view);
        void InstanceReleased(ViewCompiler compiler, ISparkView view);
    }
}

