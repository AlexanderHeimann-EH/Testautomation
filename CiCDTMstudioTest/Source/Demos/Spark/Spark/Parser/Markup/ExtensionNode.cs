namespace Spark.Parser.Markup
{
    using Spark;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ExtensionNode : Node
    {
        public IList<Node> Body = new List<Node>();
        public ElementNode Element;

        public ExtensionNode(ElementNode element, ISparkExtension extension)
        {
            this.Element = element;
            this.Extension = extension;
            base.OriginalNode = element;
        }

        public ISparkExtension Extension { get; set; }
    }
}

