namespace Spark.Compiler.NodeVisitors
{
    using Spark.Compiler;
    using Spark.Parser;
    using Spark.Parser.Code;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WhitespaceCleanerVisitor : NodeVisitor<WhitespaceCleanerVisitor.Frame>
    {
        private readonly IDictionary<Node, Paint<Node>> nodePaint;
        private readonly IList<Node> nodes;
        private readonly IDictionary<string, Action<SpecialNode, SpecialNodeInspector>> specialNodeMap;

        public WhitespaceCleanerVisitor(VisitorContext context) : base(context)
        {
            this.nodes = new List<Node>();
            this.nodePaint = base.Context.Paint.OfType<Paint<Node>>().ToDictionary<Paint<Node>, Node>(paint => paint.Value);
            Dictionary<string, Action<SpecialNode, SpecialNodeInspector>> dictionary = new Dictionary<string, Action<SpecialNode, SpecialNodeInspector>>();
            dictionary.Add("for", new Action<SpecialNode, SpecialNodeInspector>(this.VisitFor));
            dictionary.Add("test", new Action<SpecialNode, SpecialNodeInspector>(this.VisitIf));
            dictionary.Add("if", new Action<SpecialNode, SpecialNodeInspector>(this.VisitIf));
            dictionary.Add("else", new Action<SpecialNode, SpecialNodeInspector>(this.VisitIf));
            dictionary.Add("elseif", new Action<SpecialNode, SpecialNodeInspector>(this.VisitIf));
            dictionary.Add("unless", new Action<SpecialNode, SpecialNodeInspector>(this.VisitIf));
            this.specialNodeMap = dictionary;
        }

        private Snippets AsCode(AttributeNode attr)
        {
            Position begin = this.Locate(attr.Nodes.FirstOrDefault<Node>());
            Position end = this.LocateEnd(attr.Nodes.LastOrDefault<Node>());
            if ((begin == null) || (end == null))
            {
                begin = new Position(new SourceContext(attr.Value));
                end = begin.Advance(begin.PotentialLength());
            }
            return base.Context.SyntaxProvider.ParseFragment(begin, end);
        }

        private bool FirstChildBeginsWithNewline(SpecialNode node)
        {
            if (((node == null) || (node.Body == null)) || (node.Body.Count == 0))
            {
                return false;
            }
            Node node2 = node.Body[0];
            if (node2 == null)
            {
                return false;
            }
            TextNode node3 = node2 as TextNode;
            if (node3 != null)
            {
                if (node3.Text.IndexOf("\r\n") != 0)
                {
                    return (node3.Text.IndexOf("\n") == 0);
                }
                return true;
            }
            ElementNode element = node2 as ElementNode;
            if (element == null)
            {
                SpecialNode node5 = node2 as SpecialNode;
                if (node5 != null)
                {
                    element = node5.Element;
                }
            }
            if (element == null)
            {
                return false;
            }
            if (element.PreceedingWhitespace.IndexOf("\r\n") != 0)
            {
                return (element.PreceedingWhitespace.IndexOf("\n") == 0);
            }
            return true;
        }

        private Position Locate(Node expressionNode)
        {
            for (Node node = expressionNode; node != null; node = node.OriginalNode)
            {
                Paint<Node> paint;
                if (this.nodePaint.TryGetValue(node, out paint))
                {
                    return paint.Begin;
                }
            }
            return null;
        }

        private Position LocateEnd(Node expressionNode)
        {
            for (Node node = expressionNode; node != null; node = node.OriginalNode)
            {
                Paint<Node> paint;
                if (this.nodePaint.TryGetValue(node, out paint))
                {
                    return paint.End;
                }
            }
            return null;
        }

        protected override void Visit(SpecialNode specialNode)
        {
            string name = NameUtility.GetName(specialNode.Element.Name);
            if (!string.IsNullOrEmpty(specialNode.Element.PreceedingWhitespace) && this.specialNodeMap.ContainsKey(name))
            {
                Action<SpecialNode, SpecialNodeInspector> action = this.specialNodeMap[name];
                action(specialNode, new SpecialNodeInspector(specialNode));
            }
            base.Visit(specialNode);
        }

        protected void VisitFor(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            if (!this.FirstChildBeginsWithNewline(specialNode))
            {
                AttributeNode attr = inspector.TakeAttribute("each");
                ForEachInspector inspector2 = new ForEachInspector(this.AsCode(attr));
                string str = inspector2.Recognized ? (inspector2.VariableName + "IsFirst") : ("Once(\"" + Guid.NewGuid() + "\")");
                SpecialNode node2 = new SpecialNode(new ElementNode("if", new AttributeNode[] { new AttributeNode("condition", str) }, false)) {
                    Body = new TextNode[] { new TextNode(specialNode.Element.PreceedingWhitespace) }
                };
                List<Node> list = new List<Node> {
                    node2
                };
                if (specialNode.Body != null)
                {
                    list.AddRange(specialNode.Body);
                }
                specialNode.Body = list;
            }
            specialNode.Element.PreceedingWhitespace = string.Empty;
        }

        protected void VisitIf(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            if (!this.FirstChildBeginsWithNewline(specialNode))
            {
                List<Node> list = new List<Node> {
                    new TextNode(specialNode.Element.PreceedingWhitespace)
                };
                if (specialNode.Body != null)
                {
                    list.AddRange(specialNode.Body);
                }
                specialNode.Body = list;
            }
            specialNode.Element.PreceedingWhitespace = string.Empty;
        }

        public class Frame
        {
        }
    }
}

