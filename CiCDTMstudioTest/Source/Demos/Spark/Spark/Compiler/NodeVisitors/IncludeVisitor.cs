namespace Spark.Compiler.NodeVisitors
{
    using Spark.Compiler;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class IncludeVisitor : NodeVisitor<IncludeVisitor.Frame>
    {
        public IncludeVisitor(VisitorContext context) : base(context)
        {
        }

        private void BeginFallback()
        {
            if (base.FrameData.Mode == Mode.SuccessfulInclude)
            {
                Frame frameData = new Frame {
                    Mode = Mode.IgnoringFallback
                };
                base.PushFrame(this.Nodes, frameData);
            }
            else
            {
                if (base.FrameData.Mode != Mode.FailedInclude)
                {
                    throw new CompilerException("<fallback> only valid inside <include>");
                }
                base.FrameData.FallbackUsed = true;
                Frame frame2 = new Frame {
                    Mode = Mode.NormalContent
                };
                base.PushFrame(base.FrameData.NodesForFallback, frame2);
            }
        }

        private void BeginInclude(string href, string parse)
        {
            try
            {
                foreach (Node node in base.Context.SyntaxProvider.IncludeFile(base.Context, href, parse))
                {
                    this.Nodes.Add(node);
                }
                Frame frameData = new Frame {
                    Mode = Mode.SuccessfulInclude
                };
                base.PushFrame(new List<Node>(), frameData);
            }
            catch (FileNotFoundException exception)
            {
                Frame frame2 = new Frame {
                    Mode = Mode.FailedInclude,
                    IncludeException = exception,
                    NodesForFallback = this.Nodes
                };
                base.PushFrame(new List<Node>(), frame2);
            }
        }

        private void EndFallback()
        {
            base.PopFrame();
        }

        private void EndInclude()
        {
            Frame frameData = base.FrameData;
            base.PopFrame();
            if ((frameData.Mode == Mode.FailedInclude) && !frameData.FallbackUsed)
            {
                throw new CompilerException(frameData.IncludeException.Message);
            }
        }

        protected override void Visit(ElementNode node)
        {
            if (NameUtility.IsMatch("include", "http://www.w3.org/2001/XInclude", node.Name, node.Namespace, base.Context.Namespaces))
            {
                if ((base.FrameData.Mode == Mode.SuccessfulInclude) || (base.FrameData.Mode == Mode.FailedInclude))
                {
                    if (!node.IsEmptyElement)
                    {
                        Frame frameData = base.FrameData;
                        frameData.RedundantDepth++;
                    }
                }
                else
                {
                    AttributeNode node2 = node.Attributes.FirstOrDefault<AttributeNode>(a => a.Name == "href");
                    AttributeNode node3 = node.Attributes.FirstOrDefault<AttributeNode>(a => a.Name == "parse");
                    this.BeginInclude(node2.Value, (node3 == null) ? "xml" : node3.Value);
                    if (node.IsEmptyElement)
                    {
                        this.EndInclude();
                    }
                }
            }
            else if (NameUtility.IsMatch("fallback", "http://www.w3.org/2001/XInclude", node.Name, node.Namespace, base.Context.Namespaces))
            {
                if (base.FrameData.Mode == Mode.IgnoringFallback)
                {
                    if (!node.IsEmptyElement)
                    {
                        Frame local2 = base.FrameData;
                        local2.RedundantDepth++;
                    }
                }
                else
                {
                    this.BeginFallback();
                    if (node.IsEmptyElement)
                    {
                        this.EndFallback();
                    }
                }
            }
            else
            {
                base.Visit(node);
            }
        }

        protected override void Visit(EndElementNode node)
        {
            if (NameUtility.IsMatch("include", "http://www.w3.org/2001/XInclude", node.Name, node.Namespace, base.Context.Namespaces))
            {
                int num;
                if ((base.FrameData.Mode != Mode.FailedInclude) && (base.FrameData.Mode != Mode.SuccessfulInclude))
                {
                    throw new CompilerException("Unexpected </include> element");
                }
                Frame frameData = base.FrameData;
                frameData.RedundantDepth = (num = frameData.RedundantDepth) - 1;
                if (num == 0)
                {
                    this.EndInclude();
                }
            }
            else if (NameUtility.IsMatch("fallback", "http://www.w3.org/2001/XInclude", node.Name, node.Namespace, base.Context.Namespaces))
            {
                int num2;
                if ((base.FrameData.Mode != Mode.NormalContent) && (base.FrameData.Mode != Mode.IgnoringFallback))
                {
                    throw new CompilerException("Unexpected </fallback> element");
                }
                Frame local2 = base.FrameData;
                local2.RedundantDepth = (num2 = local2.RedundantDepth) - 1;
                if (num2 == 0)
                {
                    this.EndFallback();
                }
            }
            else
            {
                base.Visit(node);
            }
        }

        public class Frame
        {
            public bool FallbackUsed;

            public Exception IncludeException { get; set; }

            public Spark.Compiler.NodeVisitors.IncludeVisitor.Mode Mode { get; set; }

            public IList<Node> NodesForFallback { get; set; }

            public int RedundantDepth { get; set; }
        }

        public enum Mode
        {
            NormalContent,
            SuccessfulInclude,
            FailedInclude,
            IgnoringFallback
        }
    }
}

