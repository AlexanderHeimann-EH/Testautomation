namespace Spark.Compiler.NodeVisitors
{
    using Spark;
    using Spark.Compiler;
    using Spark.Parser;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class SpecialNodeVisitor : AbstractNodeVisitor
    {
        private int _acceptNodesLevel;
        private readonly IList<string> _containingNames;
        private readonly Stack<ExtensionNode> _extensionNodes;
        private IList<Node> _nodes;
        private readonly IList<string> _nonContainingNames;
        private readonly Stack<IList<Node>> _stack;

        public SpecialNodeVisitor(VisitorContext context) : base(context)
        {
            this._extensionNodes = new Stack<ExtensionNode>();
            this._nodes = new List<Node>();
            this._stack = new Stack<IList<Node>>();
            this._containingNames = new List<string>(new string[] { 
                "var", "def", "default", "for", "use", "content", "test", "if", "else", "elseif", "unless", "macro", "render", "segment", "cache", "markdown", 
                "ignore"
             });
            this._nonContainingNames = new List<string>(new string[] { "global", "set", "viewdata" });
            if (context.ParseSectionTagAsSegment)
            {
                this._containingNames.Add("section");
            }
        }

        private void Add(Node node)
        {
            this.Nodes.Add(node);
        }

        protected override void AfterAcceptNodes()
        {
            this._acceptNodesLevel--;
            if ((this._acceptNodesLevel == 0) && (this._stack.Count != 0))
            {
                SpecialNode specialNode = (SpecialNode) this._stack.Peek().Last<Node>();
                Paint<Node> paint = base.Context.Paint.OfType<Paint<Node>>().FirstOrDefault<Paint<Node>>(p => p.Value == specialNode.OriginalNode);
                Position position = (paint == null) ? null : paint.Begin;
                throw new CompilerException(string.Format("Element {0} was never closed", specialNode.Element.Name), position);
            }
        }

        protected override void BeforeAcceptNodes()
        {
            this._acceptNodesLevel++;
        }

        private bool IsContainingElement(string name, string ns)
        {
            if (base.Context.Namespaces == NamespacesType.Unqualified)
            {
                return this._containingNames.Contains(name);
            }
            if (ns != "http://sparkviewengine.com/")
            {
                return false;
            }
            return this._containingNames.Contains(NameUtility.GetName(name));
        }

        private bool IsNonContainingElement(string name, string ns)
        {
            if (base.Context.Namespaces == NamespacesType.Unqualified)
            {
                return this._nonContainingNames.Contains(name);
            }
            if (ns != "http://sparkviewengine.com/")
            {
                return false;
            }
            return this._nonContainingNames.Contains(NameUtility.GetName(name));
        }

        private bool IsPartialFileElement(string name, string ns)
        {
            if (base.Context.Namespaces == NamespacesType.Unqualified)
            {
                return base.Context.PartialFileNames.Contains(name);
            }
            if (ns != "http://sparkviewengine.com/")
            {
                return false;
            }
            return base.Context.PartialFileNames.Contains(NameUtility.GetName(name));
        }

        private void PopSpecial(string name)
        {
            if (this._stack.Count == 0)
            {
                throw new CompilerException(string.Format("Unexpected end element {0}", name));
            }
            this._nodes = this._stack.Pop();
            SpecialNode node = this.Nodes.Last<Node>() as SpecialNode;
            if (node == null)
            {
                throw new CompilerException(string.Format("Unexpected end element {0}", name));
            }
            if (node.Element.Name != name)
            {
                throw new CompilerException(string.Format("End element {0} did not match {1}", name, node.Element.Name));
            }
        }

        private void PushSpecial(ElementNode element)
        {
            SpecialNode item = new SpecialNode(element) {
                OriginalNode = element
            };
            this.Nodes.Add(item);
            this._stack.Push(this.Nodes);
            this._nodes = item.Body;
        }

        private bool TryCreateExtension(ElementNode node, out ISparkExtension extension)
        {
            if (base.Context.ExtensionFactory == null)
            {
                extension = null;
                return false;
            }
            extension = base.Context.ExtensionFactory.CreateExtension(base.Context, node);
            return (extension != null);
        }

        protected override void Visit(AttributeNode attributeNode)
        {
            this.Add(attributeNode);
        }

        protected override void Visit(CommentNode commentNode)
        {
            this.Add(commentNode);
        }

        protected override void Visit(ConditionNode node)
        {
            throw new NotImplementedException();
        }

        protected override void Visit(DoctypeNode docTypeNode)
        {
            this.Add(docTypeNode);
        }

        protected override void Visit(ElementNode node)
        {
            if (this.IsContainingElement(node.Name, node.Namespace))
            {
                this.PushSpecial(node);
                if (node.IsEmptyElement)
                {
                    this.PopSpecial(node.Name);
                }
            }
            else if (this.IsNonContainingElement(node.Name, node.Namespace))
            {
                this.PushSpecial(node);
                this.PopSpecial(node.Name);
            }
            else
            {
                ISparkExtension extension;
                if (this.TryCreateExtension(node, out extension))
                {
                    ExtensionNode item = new ExtensionNode(node, extension);
                    this.Nodes.Add(item);
                    if (!node.IsEmptyElement)
                    {
                        this._extensionNodes.Push(item);
                        this._stack.Push(this.Nodes);
                        this._nodes = item.Body;
                    }
                }
                else if (this.IsPartialFileElement(node.Name, node.Namespace))
                {
                    List<AttributeNode> attributeNodes = new List<AttributeNode>(node.Attributes) {
                        new AttributeNode("file", "_" + NameUtility.GetName(node.Name))
                    };
                    ElementNode element = new ElementNode("use", attributeNodes, node.IsEmptyElement) {
                        OriginalNode = node
                    };
                    this.PushSpecial(element);
                    if (node.IsEmptyElement)
                    {
                        this.PopSpecial("use");
                    }
                }
                else
                {
                    this.Add(node);
                }
            }
        }

        protected override void Visit(EndElementNode node)
        {
            if ((this._extensionNodes.Count > 0) && string.Equals(node.Name, this._extensionNodes.Peek().Element.Name))
            {
                this._nodes = this._stack.Pop();
                this._extensionNodes.Pop();
            }
            else if (this.IsContainingElement(node.Name, node.Namespace))
            {
                this.PopSpecial(node.Name);
            }
            else if (!this.IsNonContainingElement(node.Name, node.Namespace))
            {
                if (this.IsPartialFileElement(node.Name, node.Namespace))
                {
                    this.PopSpecial("use");
                }
                else
                {
                    this.Add(node);
                }
            }
        }

        protected override void Visit(EntityNode entityNode)
        {
            this.Add(entityNode);
        }

        protected override void Visit(ExpressionNode node)
        {
            this.Add(node);
        }

        protected override void Visit(ExtensionNode node)
        {
            throw new NotImplementedException();
        }

        protected override void Visit(IndentationNode node)
        {
            this.Add(node);
        }

        protected override void Visit(ProcessingInstructionNode node)
        {
            this.Nodes.Add(node);
        }

        protected override void Visit(SpecialNode specialNode)
        {
            this.Add(specialNode);
        }

        protected override void Visit(StatementNode node)
        {
            this.Add(node);
        }

        protected override void Visit(TextNode textNode)
        {
            this.Add(textNode);
        }

        protected override void Visit(XMLDeclNode node)
        {
            this.Nodes.Add(node);
        }

        public override IList<Node> Nodes
        {
            get
            {
                return this._nodes;
            }
        }
    }
}

