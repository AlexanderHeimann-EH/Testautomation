namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CacheAttributeVisitor : SpecialAttributeVisitorBase
    {
        public CacheAttributeVisitor(VisitorContext context) : base(context)
        {
        }

        private string AttrName(AttributeNode attr)
        {
            if (base.Context.Namespaces != NamespacesType.Qualified)
            {
                return attr.Name;
            }
            return NameUtility.GetName(attr.Name);
        }

        protected override SpecialNode CreateWrappingNode(AttributeNode attr, ElementNode node)
        {
            AttributeNode node2 = this.ExtractFakeAttribute(node, "cache", "key") ?? this.ExtractFakeAttribute(node, "cache.key", "key");
            AttributeNode node3 = this.ExtractFakeAttribute(node, "cache.expires", "expires");
            AttributeNode node4 = this.ExtractFakeAttribute(node, "cache.signal", "signal");
            List<AttributeNode> attributeNodes = (from x in new AttributeNode[] { node2, node3, node4 }
                where x != null
                select x).ToList<AttributeNode>();
            ElementNode element = new ElementNode("cache", attributeNodes, false) {
                OriginalNode = attr
            };
            return new SpecialNode(element);
        }

        private AttributeNode ExtractFakeAttribute(ElementNode node, string name, string fakeName)
        {
            AttributeNode item = node.Attributes.SingleOrDefault<AttributeNode>(x => this.AttrName(x) == name);
            if (item == null)
            {
                return null;
            }
            node.Attributes.Remove(item);
            return new AttributeNode(fakeName, '"', item.Nodes);
        }

        protected override bool IsSpecialAttribute(ElementNode element, AttributeNode attr)
        {
            string str = this.AttrName(attr);
            if ((!(str == "cache") && !(str == "cache.key")) && !(str == "cache.expires"))
            {
                return (str == "cache.signal");
            }
            return true;
        }
    }
}

