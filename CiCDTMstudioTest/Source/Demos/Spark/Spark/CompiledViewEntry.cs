namespace Spark
{
    using Spark.Compiler;
    using Spark.Parser;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class CompiledViewEntry : ISparkViewEntry
    {
        public ISparkView CreateInstance()
        {
            ISparkView view = this.Activator.Activate(this.Compiler.CompiledType);
            if (this.LanguageFactory != null)
            {
                this.LanguageFactory.InstanceCreated(this.Compiler, view);
            }
            return view;
        }

        public bool IsCurrent()
        {
            return this.Loader.IsCurrent();
        }

        public void ReleaseInstance(ISparkView view)
        {
            if (this.LanguageFactory != null)
            {
                this.LanguageFactory.InstanceReleased(this.Compiler, view);
            }
            this.Activator.Release(this.Compiler.CompiledType, view);
        }

        public IViewActivator Activator { get; set; }

        public ViewCompiler Compiler { get; set; }

        public SparkViewDescriptor Descriptor { get; set; }

        public ISparkLanguageFactory LanguageFactory { get; set; }

        public ViewLoader Loader { get; set; }

        public string SourceCode
        {
            get
            {
                return this.Compiler.SourceCode;
            }
        }

        public IList<SourceMapping> SourceMappings
        {
            get
            {
                return this.Compiler.SourceMappings;
            }
        }

        public Guid ViewId
        {
            get
            {
                return this.Compiler.GeneratedViewId;
            }
        }
    }
}

