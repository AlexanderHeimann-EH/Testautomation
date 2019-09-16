namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;

    public class OnceAttributeVisitor : SpecialAttributeVisitorBase
    {
        public OnceAttributeVisitor(VisitorContext context) : base(context)
        {
        }

        protected override SpecialNode CreateWrappingNode(AttributeNode attr, ElementNode node)
        {
            AttributeNode node2 = new AttributeNode("once", '"', attr.Nodes);
            ElementNode element = new ElementNode("test", new AttributeNode[] { node2 }, false) {
                OriginalNode = attr
            };
            return new SpecialNode(element);
        }

        protected override bool IsSpecialAttribute(ElementNode element, AttributeNode attr)
        {
            switch (NameUtility.GetName(element.Name))
            {
                case "test":
                case "if":
                case "elseif":
                case "else":
                    return false;
            }
            if (base.Context.Namespaces == NamespacesType.Unqualified)
            {
                return (attr.Name == "once");
            }
            if (attr.Namespace != "http://sparkviewengine.com/")
            {
                return false;
            }
            return (NameUtility.GetName(attr.Name) == "once");
        }
    }
}

