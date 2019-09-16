namespace Spark.Parser.Markup
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ElementNode : Node
    {
        public readonly IList<AttributeNode> Attributes;

        public ElementNode(string name, IList<AttributeNode> attributeNodes, bool isEmptyElement) : this(name, attributeNodes, isEmptyElement, string.Empty)
        {
        }

        public ElementNode(string name, IList<AttributeNode> attributeNodes, bool isEmptyElement, string preceedingWhitespace)
        {
            this.Name = name;
            this.Namespace = "";
            this.IsEmptyElement = isEmptyElement;
            this.Attributes = attributeNodes;
            this.PreceedingWhitespace = preceedingWhitespace;
        }

        public bool IsEmptyElement { get; set; }

        public string Name { get; set; }

        public string Namespace { get; set; }

        public string PreceedingWhitespace { get; set; }
    }
}

