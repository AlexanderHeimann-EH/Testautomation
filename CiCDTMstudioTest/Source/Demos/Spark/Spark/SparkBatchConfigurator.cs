namespace Spark
{
    using System;
    using System.Reflection;

    public sealed class SparkBatchConfigurator
    {
        private readonly SparkBatchDescriptor descriptor;
        private readonly SparkBatchEntry entry;

        internal SparkBatchConfigurator(SparkBatchDescriptor descriptor, SparkBatchEntry entry)
        {
            this.descriptor = descriptor;
            this.entry = entry;
        }

        public SparkBatchConfigurator Exclude(string pattern)
        {
            this.entry.ExcludeViews.Add(pattern);
            return this;
        }

        public SparkBatchConfigurator For<TController>(params string[] layoutNames)
        {
            return this.descriptor.For<TController>();
        }

        public SparkBatchConfigurator For(Type controllerType, params string[] layoutNames)
        {
            return this.descriptor.For(controllerType);
        }

        public SparkBatchDescriptor FromAssembly(Assembly assembly)
        {
            return this.descriptor.FromAssembly(assembly);
        }

        public SparkBatchDescriptor FromAssemblyNamed(string assemblyString)
        {
            return this.descriptor.FromAssemblyNamed(assemblyString);
        }

        public SparkBatchDescriptor FromAttributes<TController>()
        {
            return this.descriptor.FromAttributes<TController>();
        }

        public SparkBatchDescriptor FromAttributes(Type controllerType)
        {
            return this.descriptor.FromAttributes(controllerType);
        }

        public SparkBatchConfigurator Include(string pattern)
        {
            this.entry.IncludeViews.Add(pattern);
            return this;
        }

        public SparkBatchConfigurator Layout(params string[] layouts)
        {
            this.entry.LayoutNames.Add(layouts);
            return this;
        }
    }
}

