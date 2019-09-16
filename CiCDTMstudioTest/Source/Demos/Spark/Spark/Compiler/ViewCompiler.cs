namespace Spark.Compiler
{
    using Spark;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public abstract class ViewCompiler
    {
        protected ViewCompiler()
        {
            this.GeneratedViewId = Guid.NewGuid();
        }

        public abstract void CompileView(IEnumerable<IList<Chunk>> viewTemplates, IEnumerable<IList<Chunk>> allResources);
        public ISparkView CreateInstance()
        {
            return (ISparkView) Activator.CreateInstance(this.CompiledType);
        }

        public abstract void GenerateSourceCode(IEnumerable<IList<Chunk>> viewTemplates, IEnumerable<IList<Chunk>> allResources);

        public string BaseClass { get; set; }

        public Type CompiledType { get; set; }

        public bool Debug { get; set; }

        public SparkViewDescriptor Descriptor { get; set; }

        public Guid GeneratedViewId { get; set; }

        public Spark.NullBehaviour NullBehaviour { get; set; }

        public string SourceCode { get; set; }

        public IList<SourceMapping> SourceMappings { get; set; }

        public string TargetNamespace
        {
            get
            {
                if (this.Descriptor != null)
                {
                    return this.Descriptor.TargetNamespace;
                }
                return null;
            }
        }

        public IEnumerable<string> UseAssemblies { get; set; }

        public IEnumerable<string> UseNamespaces { get; set; }

        public string ViewClassFullName { get; set; }
    }
}

