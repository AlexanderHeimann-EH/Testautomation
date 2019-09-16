namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class NamespaceVisitor : NodeVisitor<NamespaceVisitor.Frame>
    {
        public NamespaceVisitor(VisitorContext context) : base(context)
        {
            base.FrameData.Nametable = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(context.Prefix))
            {
                base.Context.Namespaces = NamespacesType.Qualified;
                base.FrameData.Nametable[context.Prefix] = "http://sparkviewengine.com/";
                base.FrameData.Nametable["content"] = "http://sparkviewengine.com/content/";
                base.FrameData.Nametable["use"] = "http://sparkviewengine.com/use/";
                base.FrameData.Nametable["macro"] = "http://sparkviewengine.com/macro/";
                base.FrameData.Nametable["segment"] = "http://sparkviewengine.com/segment/";
                base.FrameData.Nametable["render"] = "http://sparkviewengine.com/render/";
                if (context.ParseSectionTagAsSegment)
                {
                    base.FrameData.Nametable["section"] = "http://sparkviewengine.com/section/";
                }
            }
        }

        private void ApplyNamespaces(ElementNode node)
        {
            int index = node.Name.IndexOf(':');
            if (index > 0)
            {
                string str2;
                string key = node.Name.Substring(0, index);
                if (base.FrameData.Nametable.TryGetValue(key, out str2))
                {
                    node.Namespace = str2;
                }
            }
            foreach (AttributeNode node2 in node.Attributes)
            {
                index = node2.Name.IndexOf(':');
                if (index > 0)
                {
                    string str4;
                    string str3 = node2.Name.Substring(0, index);
                    if (base.FrameData.Nametable.TryGetValue(str3, out str4))
                    {
                        node2.Namespace = str4;
                    }
                }
            }
        }

        private void ApplyNamespaces(EndElementNode node)
        {
            int index = node.Name.IndexOf(':');
            if (index > 0)
            {
                string str2;
                string key = node.Name.Substring(0, index);
                if (base.FrameData.Nametable.TryGetValue(key, out str2))
                {
                    node.Namespace = str2;
                }
            }
        }

        private static bool IsKnownUri(AttributeNode attr)
        {
            if (!attr.Value.StartsWith("http://sparkviewengine.com/"))
            {
                return (attr.Value == "http://www.w3.org/2001/XInclude");
            }
            return true;
        }

        private static bool IsXmlnsAttribute(AttributeNode attr)
        {
            if (!attr.Name.StartsWith("xmlns:"))
            {
                return (attr.Name == "xmlns");
            }
            return true;
        }

        protected override void Visit(ElementNode node)
        {
            IDictionary<string, string> dictionary = null;
            foreach (AttributeNode node2 in node.Attributes.Where<AttributeNode>(new Func<AttributeNode, bool>(NamespaceVisitor.IsXmlnsAttribute)).Where<AttributeNode>(new Func<AttributeNode, bool>(NamespaceVisitor.IsKnownUri)))
            {
                dictionary = dictionary ?? new Dictionary<string, string>(base.FrameData.Nametable);
                if (node2.Name == "xmlns")
                {
                    dictionary[""] = node2.Value;
                }
                else
                {
                    dictionary[node2.Name.Substring("xmlns:".Length)] = node2.Value;
                }
            }
            if (dictionary != null)
            {
                base.Context.Namespaces = NamespacesType.Qualified;
                Frame frameData = new Frame {
                    Nametable = dictionary,
                    ElementName = node.Name
                };
                base.PushFrame(this.Nodes, frameData);
            }
            else if ((base.FrameData.ElementName == node.Name) && !node.IsEmptyElement)
            {
                Frame local1 = base.FrameData;
                local1.ElementNameDepth++;
            }
            this.ApplyNamespaces(node);
            if ((dictionary != null) && node.IsEmptyElement)
            {
                base.PopFrame();
            }
            base.Visit(node);
        }

        protected override void Visit(EndElementNode node)
        {
            this.ApplyNamespaces(node);
            if (node.Name == base.FrameData.ElementName)
            {
                int num;
                Frame frameData = base.FrameData;
                frameData.ElementNameDepth = (num = frameData.ElementNameDepth) - 1;
                if (num == 0)
                {
                    base.PopFrame();
                }
            }
            base.Visit(node);
        }

        public class Frame
        {
            public string ElementName { get; set; }

            public int ElementNameDepth { get; set; }

            public IDictionary<string, string> Nametable { get; set; }
        }
    }
}

