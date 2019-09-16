namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public abstract class AbstractNodeVisitor : INodeVisitor
    {
        protected AbstractNodeVisitor(VisitorContext context)
        {
            this.Context = context;
        }

        public void Accept(Node node)
        {
            if (node is TextNode)
            {
                this.Visit((TextNode) node);
            }
            else if (node is EntityNode)
            {
                this.Visit((EntityNode) node);
            }
            else if (node is ExpressionNode)
            {
                this.Visit((ExpressionNode) node);
            }
            else if (node is ElementNode)
            {
                this.Visit((ElementNode) node);
            }
            else if (node is AttributeNode)
            {
                this.Visit((AttributeNode) node);
            }
            else if (node is EndElementNode)
            {
                this.Visit((EndElementNode) node);
            }
            else if (node is DoctypeNode)
            {
                this.Visit((DoctypeNode) node);
            }
            else if (node is CommentNode)
            {
                this.Visit((CommentNode) node);
            }
            else if (node is SpecialNode)
            {
                this.Visit((SpecialNode) node);
            }
            else if (node is ExtensionNode)
            {
                this.Visit((ExtensionNode) node);
            }
            else if (node is StatementNode)
            {
                this.Visit((StatementNode) node);
            }
            else if (node is ConditionNode)
            {
                this.Visit((ConditionNode) node);
            }
            else if (node is XMLDeclNode)
            {
                this.Visit((XMLDeclNode) node);
            }
            else if (node is ProcessingInstructionNode)
            {
                this.Visit((ProcessingInstructionNode) node);
            }
            else
            {
                if (!(node is IndentationNode))
                {
                    throw new ArgumentException(string.Format("Unknown node type {0}", node.GetType()), "node");
                }
                this.Visit((IndentationNode) node);
            }
        }

        public void Accept(IList<Node> nodes)
        {
            this.BeforeAcceptNodes();
            foreach (Node node in nodes)
            {
                this.Accept(node);
            }
            this.AfterAcceptNodes();
        }

        protected virtual void AfterAcceptNodes()
        {
        }

        protected virtual void BeforeAcceptNodes()
        {
        }

        protected abstract void Visit(AttributeNode attributeNode);
        protected abstract void Visit(CommentNode commentNode);
        protected abstract void Visit(ConditionNode node);
        protected abstract void Visit(DoctypeNode docTypeNode);
        protected abstract void Visit(ElementNode node);
        protected abstract void Visit(EndElementNode node);
        protected abstract void Visit(EntityNode entityNode);
        protected abstract void Visit(ExpressionNode node);
        protected abstract void Visit(ExtensionNode node);
        protected abstract void Visit(IndentationNode node);
        protected abstract void Visit(ProcessingInstructionNode node);
        protected abstract void Visit(SpecialNode specialNode);
        protected abstract void Visit(StatementNode node);
        protected abstract void Visit(TextNode textNode);
        protected abstract void Visit(XMLDeclNode node);

        public VisitorContext Context { get; set; }

        public abstract IList<Node> Nodes { get; }
    }
}

