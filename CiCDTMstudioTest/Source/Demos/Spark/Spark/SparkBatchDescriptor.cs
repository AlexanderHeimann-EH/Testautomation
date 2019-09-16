namespace Spark
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class SparkBatchDescriptor
    {
        public SparkBatchDescriptor() : this(null)
        {
        }

        public SparkBatchDescriptor(string assemblyName)
        {
            this.OutputAssembly = assemblyName;
            this.Entries = new List<SparkBatchEntry>();
        }

        public SparkBatchConfigurator For<TController>()
        {
            return this.For(typeof(TController));
        }

        public SparkBatchConfigurator For(Type controllerType)
        {
            SparkBatchEntry item = new SparkBatchEntry {
                ControllerType = controllerType
            };
            this.Entries.Add(item);
            return new SparkBatchConfigurator(this, item);
        }

        public SparkBatchDescriptor FromAssembly(Assembly assembly)
        {
            foreach (Type type in assembly.GetExportedTypes())
            {
                this.FromAttributes(type);
            }
            return this;
        }

        public SparkBatchDescriptor FromAssemblyNamed(string assemblyString)
        {
            return this.FromAssembly(Assembly.Load(assemblyString));
        }

        public SparkBatchDescriptor FromAttributes<TController>()
        {
            return this.FromAttributes(typeof(TController));
        }

        public SparkBatchDescriptor FromAttributes(Type controllerType)
        {
            foreach (PrecompileAttribute attribute in controllerType.GetCustomAttributes(typeof(PrecompileAttribute), true) ?? new object[0])
            {
                SparkBatchConfigurator configurator = this.For(controllerType);
                foreach (string str in SplitParts(attribute.Include))
                {
                    configurator.Include(str);
                }
                foreach (string str2 in SplitParts(attribute.Exclude))
                {
                    configurator.Exclude(str2);
                }
                foreach (string str3 in SplitParts(attribute.Layout))
                {
                    configurator.Layout(str3.Split(new char[] { '+' }));
                }
            }
            return this;
        }

        private static string[] SplitParts(string value)
        {
            return (value ?? "").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public IList<SparkBatchEntry> Entries { get; set; }

        public string OutputAssembly { get; set; }
    }
}

