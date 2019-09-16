namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public abstract class SpecialAttributeVisitorBase : NodeVisitor<SpecialAttributeVisitorBase.Frame>
    {
        protected SpecialAttributeVisitorBase(VisitorContext context) : base(context)
        {
        }

        protected abstract SpecialNode CreateWrappingNode(AttributeNode attr, ElementNode node);
        protected abstract bool IsSpecialAttribute(ElementNode element, AttributeNode attribute);
        protected override void Visit(ElementNode node)
        {
            AttributeNode node2 = node.Attributes.FirstOrDefault<AttributeNode>(attr => this.IsSpecialAttribute(node, attr));
            if (node2 != null)
            {
                SpecialNode item = this.CreateWrappingNode(node2, node);
                node.Attributes.Remove(node2);
                item.Body.Add(node);
                this.Nodes.Add(item);
                if (!node.IsEmptyElement)
                {
                    Frame frameData = new Frame {
                        ClosingName = node.Name,
                        ClosingNameOutstanding = 1
                    };
                    base.PushFrame(item.Body, frameData);
                }
            }
            else if (string.Equals(node.Name, base.FrameData.ClosingName) && !node.IsEmptyElement)
            {
                Frame local1 = base.FrameData;
                local1.ClosingNameOutstanding++;
                this.Nodes.Add(node);
            }
            else
            {
                this.Nodes.Add(node);
            }
        }

        protected override void Visit(EndElementNode node)
        {
            this.Nodes.Add(node);
            if (string.Equals(node.Name, base.FrameData.ClosingName))
            {
                Frame frameData = base.FrameData;
                frameData.ClosingNameOutstanding--;
                if (base.FrameData.ClosingNameOutstanding == 0)
                {
                    base.PopFrame();
                }
            }
        }

        protected override void Visit(ExtensionNode node)
        {
            ExtensionNode item = new ExtensionNode(node.Element, node.Extension);
            AttributeNode node3 = item.Element.Attributes.FirstOrDefault<AttributeNode>(attr => this.IsSpecialAttribute(node.Element, attr));
            if (node3 != null)
            {
                SpecialNode node4 = this.CreateWrappingNode(node3, item.Element);
                item.Element.Attributes.Remove(node3);
                this.Nodes.Add(node4);
                base.PushFrame(node4.Body, new Frame());
            }
            this.Nodes.Add(item);
            base.PushFrame(item.Body, new Frame());
            base.Accept(node.Body);
            base.PopFrame();
            if (node3 != null)
            {
                base.PopFrame();
            }
        }

        protected override void Visit(SpecialNode node)
        {
            SpecialNode item = new SpecialNode(node.Element);
            string name = NameUtility.GetName(node.Element.Name);
            AttributeNode node3 = null;
            if (name != "for")
            {
                node3 = item.Element.Attributes.FirstOrDefault<AttributeNode>(attr => this.IsSpecialAttribute(node.Element, attr));
            }
            if (node3 != null)
            {
                SpecialNode node4 = this.CreateWrappingNode(node3, item.Element);
                item.Element.Attributes.Remove(node3);
                this.Nodes.Add(node4);
                base.PushFrame(node4.Body, new Frame());
            }
            this.Nodes.Add(item);
            base.PushFrame(item.Body, new Frame());
            base.Accept(node.Body);
            base.PopFrame();
            if (node3 != null)
            {
                base.PopFrame();
            }
        }

        public class Frame
        {
            public string ClosingName { get; set; }

            public int ClosingNameOutstanding { get; set; }
        }
    }
}

