namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;

    public class ForEachAttributeVisitor : SpecialAttributeVisitorBase
    {
        public ForEachAttributeVisitor(VisitorContext context) : base(context)
        {
        }

        protected override SpecialNode CreateWrappingNode(AttributeNode attr, ElementNode node)
        {
            AttributeNode node2 = new AttributeNode("each", '"', attr.Nodes) {
                OriginalNode = attr
            };
            ElementNode element = new ElementNode("for", new AttributeNode[] { node2 }, false) {
                OriginalNode = attr
            };
            return new SpecialNode(element);
        }

        protected override bool IsSpecialAttribute(ElementNode element, AttributeNode attribute)
        {
            if (NameUtility.GetName(element.Name) == "for")
            {
                return false;
            }
            if (base.Context.Namespaces == NamespacesType.Unqualified)
            {
                return (attribute.Name == "each");
            }
            if (attribute.Namespace != "http://sparkviewengine.com/")
            {
                return false;
            }
            return (NameUtility.GetName(attribute.Name) == "each");
        }
    }
}

