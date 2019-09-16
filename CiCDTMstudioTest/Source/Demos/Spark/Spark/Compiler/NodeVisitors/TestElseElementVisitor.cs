namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class TestElseElementVisitor : AbstractNodeVisitor
    {
        private Frame _frame;
        private readonly Stack<Frame> _stack;

        public TestElseElementVisitor(VisitorContext context) : base(context)
        {
            Frame frame = new Frame {
                Nodes = new List<Node>()
            };
            this._frame = frame;
            this._stack = new Stack<Frame>();
        }

        private void PopFrame()
        {
            this._frame = this._stack.Pop();
        }

        private void PushFrame()
        {
            this._stack.Push(this._frame);
            this._frame = new Frame();
        }

        protected override void Visit(AttributeNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(CommentNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(ConditionNode node)
        {
            throw new NotImplementedException();
        }

        protected override void Visit(DoctypeNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(ElementNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(EndElementNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(EntityNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(ExpressionNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(ExtensionNode node)
        {
            ExtensionNode item = new ExtensionNode(node.Element, node.Extension);
            this.PushFrame();
            this._frame.Nodes = item.Body;
            base.Accept(node.Body);
            this.PopFrame();
            this.Nodes.Add(item);
        }

        protected override void Visit(IndentationNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(ProcessingInstructionNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(SpecialNode node)
        {
            bool flag = false;
            if ((NameUtility.IsMatch("else", base.Context.Namespaces, node.Element.Name, node.Element.Namespace) && node.Element.IsEmptyElement) && (this._frame.TestParentNodes != null))
            {
                flag = true;
            }
            if (flag)
            {
                SpecialNode item = new SpecialNode(node.Element);
                this._frame.TestParentNodes.Add(item);
                this._frame.Nodes = item.Body;
            }
            else
            {
                SpecialNode node3 = new SpecialNode(node.Element);
                this.Nodes.Add(node3);
                IList<Node> nodes = this._frame.Nodes;
                this.PushFrame();
                this._frame.Nodes = node3.Body;
                if (NameUtility.IsMatch("if", base.Context.Namespaces, node.Element.Name, node.Element.Namespace) || NameUtility.IsMatch("test", base.Context.Namespaces, node.Element.Name, node.Element.Namespace))
                {
                    this._frame.TestParentNodes = nodes;
                }
                base.Accept(node.Body);
                this.PopFrame();
            }
        }

        protected override void Visit(StatementNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(TextNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(XMLDeclNode node)
        {
            this.Nodes.Add(node);
        }

        public override IList<Node> Nodes
        {
            get
            {
                return this._frame.Nodes;
            }
        }

        private class Frame
        {
            public IList<Node> Nodes { get; set; }

            public IList<Node> TestParentNodes { get; set; }
        }
    }
}

