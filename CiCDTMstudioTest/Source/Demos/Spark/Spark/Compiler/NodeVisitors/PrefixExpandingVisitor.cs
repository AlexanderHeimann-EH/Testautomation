namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class PrefixExpandingVisitor : NodeVisitor<PrefixExpandingVisitor.Frame>
    {
        private readonly IList<PrefixSpecs> _prefixes;

        public PrefixExpandingVisitor(VisitorContext context) : base(context)
        {
            this._prefixes = new List<PrefixSpecs>();
            this._prefixes = new List<PrefixSpecs> { new PrefixSpecs("segment", "http://sparkviewengine.com/segment/", "segment", "name"), new PrefixSpecs("macro", "http://sparkviewengine.com/macro/", "macro", "name"), new PrefixSpecs("content", "http://sparkviewengine.com/content/", "content", "name"), new PrefixSpecs("use", "http://sparkviewengine.com/use/", "use", "content"), new PrefixSpecs("render", "http://sparkviewengine.com/render/", "render", "segment") };
            if (context.ParseSectionTagAsSegment)
            {
                this._prefixes.Add(new PrefixSpecs("render", "http://sparkviewengine.com/render/", "render", "section"));
                this._prefixes.Add(new PrefixSpecs("section", "http://sparkviewengine.com/section/", "section", "name"));
            }
        }

        private bool IsMatchingSpec(PrefixSpecs specs, ElementNode node)
        {
            if (base.Context.Namespaces == NamespacesType.Unqualified)
            {
                return (specs.Prefix == NameUtility.GetPrefix(node.Name));
            }
            return (specs.Namespace == node.Namespace);
        }

        private void PushReconstructedNode(ElementNode original, PrefixSpecs specs)
        {
            List<AttributeNode> attributeNodes = new List<AttributeNode> {
                new AttributeNode(specs.AttributeName, NameUtility.GetName(original.Name))
            };
            attributeNodes.AddRange(original.Attributes);
            ElementNode item = new ElementNode(specs.ElementName, attributeNodes, original.IsEmptyElement) {
                OriginalNode = original,
                Namespace = "http://sparkviewengine.com/"
            };
            this.Nodes.Add(item);
            if (!original.IsEmptyElement)
            {
                Frame frameData = new Frame {
                    OriginalElementName = original.Name,
                    Specs = specs
                };
                base.PushFrame(this.Nodes, frameData);
            }
        }

        protected override void Visit(ElementNode node)
        {
            Func<PrefixSpecs, bool> predicate = null;
            if (!string.IsNullOrEmpty(NameUtility.GetPrefix(node.Name)))
            {
                if (predicate == null)
                {
                    predicate = spec => this.IsMatchingSpec(spec, node);
                }
                PrefixSpecs specs = this._prefixes.FirstOrDefault<PrefixSpecs>(predicate);
                if (specs != null)
                {
                    this.PushReconstructedNode(node, specs);
                    return;
                }
            }
            base.Visit(node);
        }

        protected override void Visit(EndElementNode node)
        {
            if (string.Equals(node.Name, base.FrameData.OriginalElementName))
            {
                EndElementNode item = new EndElementNode(base.FrameData.Specs.ElementName) {
                    Namespace = "http://sparkviewengine.com/"
                };
                this.Nodes.Add(item);
                base.PopFrame();
            }
            else
            {
                base.Visit(node);
            }
        }

        public class Frame
        {
            public string OriginalElementName { get; set; }

            public PrefixExpandingVisitor.PrefixSpecs Specs { get; set; }
        }

        public class PrefixSpecs
        {
            public PrefixSpecs(string prefix, string ns, string elementName, string attributeName)
            {
                this.Prefix = prefix;
                this.Namespace = ns;
                this.ElementName = elementName;
                this.AttributeName = attributeName;
            }

            public string AttributeName { get; set; }

            public string ElementName { get; set; }

            public string Namespace { get; set; }

            public string Prefix { get; set; }
        }
    }
}

