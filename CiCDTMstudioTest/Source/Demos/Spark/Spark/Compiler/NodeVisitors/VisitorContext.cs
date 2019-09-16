using Spark.Bindings;

namespace Spark.Compiler.NodeVisitors
{
    using Spark;
    using Spark.FileSystem;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class VisitorContext
    {
        public VisitorContext()
        {
            this.Namespaces = NamespacesType.Unqualified;
            this.Paint = new Spark.Parser.Paint[0];
            this.PartialFileNames = new string[0];
        }

        public Spark.AttributeBehaviour AttributeBehaviour { get; set; }

        public IEnumerable<Binding> Bindings { get; set; }

        public ISparkExtensionFactory ExtensionFactory { get; set; }

        public NamespacesType Namespaces { get; set; }

        public IEnumerable<Spark.Parser.Paint> Paint { get; set; }

        public bool ParseSectionTagAsSegment { get; set; }

        public IList<string> PartialFileNames { get; set; }

        public string Prefix { get; set; }

        public ISparkSyntaxProvider SyntaxProvider { get; set; }

        public IViewFolder ViewFolder { get; set; }

        public string ViewPath { get; set; }
    }
}

