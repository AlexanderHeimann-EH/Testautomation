namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UrlAttributeVisitor : NodeVisitor
    {
        private readonly IList<ElementSpecs> _specs;

        public UrlAttributeVisitor(VisitorContext context) : base(context)
        {
            this._specs = new ElementSpecs[] { 
                new ElementSpecs("a", new string[] { "href" }), new ElementSpecs("applet", new string[] { "codebase" }), new ElementSpecs("area", new string[] { "href" }), new ElementSpecs("base", new string[] { "href" }), new ElementSpecs("blockquote", new string[] { "cite" }), new ElementSpecs("body", new string[] { "background" }), new ElementSpecs("del", new string[] { "cite" }), new ElementSpecs("form", new string[] { "action" }), new ElementSpecs("frame", new string[] { "longdesc", "src" }), new ElementSpecs("head", new string[] { "profile" }), new ElementSpecs("iframe", new string[] { "longdesc", "src" }), new ElementSpecs("img", new string[] { "longdesc", "src", "usemap" }), new ElementSpecs("input", new string[] { "src", "usemap" }), new ElementSpecs("ins", new string[] { "cite" }), new ElementSpecs("link", new string[] { "href" }), new ElementSpecs("object", new string[] { "classid", "codebase", "data", "usemap" }), 
                new ElementSpecs("script", new string[] { "src" }), new ElementSpecs("q", new string[] { "cite" })
             };
        }

        private void Process(AttributeNode attribute)
        {
            TextNode node = attribute.Nodes.FirstOrDefault<Node>() as TextNode;
            if ((node != null) && node.Text.StartsWith("~/"))
            {
                string code = "SiteResource(\"" + node.Text + "\")";
                ExpressionNode node2 = new ExpressionNode(code) {
                    OriginalNode = node
                };
                attribute.Nodes[0] = node2;
            }
        }

        private void Process(ElementNode element)
        {
            ElementSpecs specs = this._specs.FirstOrDefault<ElementSpecs>(m => string.Equals(m.Name, element.Name, StringComparison.InvariantCultureIgnoreCase));
            if (specs != null)
            {
                foreach (AttributeNode node in element.Attributes)
                {
                    string attrName = node.Name;
                    if (specs.Attributes.Any<string>(n => string.Equals(n, attrName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        this.Process(node);
                    }
                }
            }
        }

        protected override void Visit(ElementNode node)
        {
            this.Process(node);
            base.Visit(node);
        }

        private class ElementSpecs
        {
            private readonly IList<string> attributes;
            private readonly string name;

            public ElementSpecs(string name, params string[] attributes)
            {
                this.name = name;
                this.attributes = attributes;
            }

            public IList<string> Attributes
            {
                get
                {
                    return this.attributes;
                }
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
            }
        }
    }
}

