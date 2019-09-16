namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;

    public class ConditionalAttributeVisitor : SpecialAttributeVisitorBase
    {
        public ConditionalAttributeVisitor(VisitorContext context) : base(context)
        {
        }

        protected override SpecialNode CreateWrappingNode(AttributeNode attr, ElementNode node)
        {
            AttributeNode node2 = new AttributeNode("condition", '"', attr.Nodes);
            ElementNode element = new ElementNode(NameUtility.GetName(attr.Name), new AttributeNode[] { node2 }, false) {
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
                if (!(attr.Name == "if") && !(attr.Name == "elseif"))
                {
                    return (attr.Name == "unless");
                }
                return true;
            }
            if (attr.Namespace != "http://sparkviewengine.com/")
            {
                return false;
            }
            string name = NameUtility.GetName(attr.Name);
            if (!(name == "if") && !(name == "elseif"))
            {
                return (name == "unless");
            }
            return true;
        }
    }
}

