namespace Spark
{
    using Spark.Compiler;
    using Spark.Parser;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class CompositeViewEntry : ISparkViewEntry
    {
        public CompositeViewEntry()
        {
            this.ViewId = Guid.NewGuid();
        }

        public ISparkView CreateInstance()
        {
            throw new NotImplementedException();
        }

        public bool IsCurrent()
        {
            throw new NotImplementedException();
        }

        public void ReleaseInstance(ISparkView view)
        {
            throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        public IList<SourceMapping> SourceMappings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid ViewId { get; set; }
    }
}

