namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;

    public abstract class NodeVisitor<TFrameData> : AbstractNodeVisitor where TFrameData: class, new()
    {
        private Frame<TFrameData> _frame;

        protected NodeVisitor(VisitorContext context) : base(context)
        {
            this.PushFrame(new List<Node>(), Activator.CreateInstance<TFrameData>());
        }

        public void PopFrame()
        {
            this._frame = this._frame.PriorFrame;
        }

        public void PushFrame(IList<Node> nodes, TFrameData frameData)
        {
            Frame<TFrameData> frame = new Frame<TFrameData> {
                Data = frameData,
                Nodes = nodes,
                PriorFrame = this._frame
            };
            this._frame = frame;
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
            this.Nodes.Add(node);
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
            this.Nodes.Add(node);
            this.PushFrame(new List<Node>(), Activator.CreateInstance<TFrameData>());
            base.Accept(node.Body);
            node.Body = this.Nodes;
            this.PopFrame();
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
            this.Nodes.Add(node);
            this.PushFrame(new List<Node>(), Activator.CreateInstance<TFrameData>());
            base.Accept(node.Body);
            node.Body = this.Nodes;
            this.PopFrame();
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

        public TFrameData FrameData
        {
            get
            {
                return this._frame.Data;
            }
        }

        public override IList<Node> Nodes
        {
            get
            {
                return this._frame.Nodes;
            }
        }
    }
}

