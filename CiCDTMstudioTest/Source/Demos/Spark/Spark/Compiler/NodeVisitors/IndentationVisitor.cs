namespace Spark.Compiler.NodeVisitors
{
    using Spark.Compiler;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class IndentationVisitor : NodeVisitor<IndentationVisitor.Frame>
    {
        public IndentationVisitor(VisitorContext context) : base(context)
        {
        }

        protected override void AfterAcceptNodes()
        {
            this.EndIndentationLength(0);
            if (!base.FrameData.BoundaryFrame)
            {
                throw new CompilerException("Boundary frame missing");
            }
            base.PopFrame();
            base.AfterAcceptNodes();
        }

        protected override void BeforeAcceptNodes()
        {
            Frame frameData = new Frame {
                BoundaryFrame = true
            };
            base.PushFrame(this.Nodes, frameData);
            base.BeforeAcceptNodes();
        }

        private void EndIndentationLength(int length)
        {
            while ((base.FrameData.Indentation != null) && (length <= base.FrameData.Indentation.Whitespace.Length))
            {
                foreach (ElementNode node in base.FrameData.ElementsStarted.Reverse<ElementNode>())
                {
                    if (this.Nodes.LastOrDefault<Node>() == node)
                    {
                        node.IsEmptyElement = true;
                    }
                    else
                    {
                        this.Nodes.Add(new EndElementNode(node.Name));
                    }
                }
                base.PopFrame();
            }
        }

        protected override void Visit(ElementNode node)
        {
            if (base.FrameData.Indentation != null)
            {
                base.FrameData.ElementsStarted.Add(node);
            }
            base.Visit(node);
        }

        protected override void Visit(IndentationNode node)
        {
            this.EndIndentationLength(node.Whitespace.Length);
            Frame frameData = new Frame {
                Indentation = node,
                ElementsStarted = new List<ElementNode>()
            };
            base.PushFrame(this.Nodes, frameData);
            base.Visit(node);
        }

        public class Frame
        {
            public bool BoundaryFrame { get; set; }

            public IList<ElementNode> ElementsStarted { get; set; }

            public IndentationNode Indentation { get; set; }
        }
    }
}

