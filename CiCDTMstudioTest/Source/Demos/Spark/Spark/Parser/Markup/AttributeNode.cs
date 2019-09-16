namespace Spark.Parser.Markup
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class AttributeNode : Node
    {
        public string Name;
        public IList<Node> Nodes;
        public char QuotChar;

        public AttributeNode(string name, string value)
        {
            this.Name = name;
            this.QuotChar = '"';
            this.Namespace = "";
            this.Nodes = new List<Node>(new TextNode[] { new TextNode(value) });
        }

        public AttributeNode(string name, char quotChar, IList<Node> nodes)
        {
            this.Name = name;
            this.QuotChar = quotChar;
            this.Namespace = "";
            this.Nodes = nodes;
        }

        public string Namespace { get; set; }

        public string Value
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Node node in this.Nodes)
                {
                    if (node is TextNode)
                    {
                        builder.Append(((TextNode) node).Text);
                    }
                    else if (node is EntityNode)
                    {
                        builder.Append('&').Append(((EntityNode) node).Name).Append(';');
                    }
                    else if (node is ExpressionNode)
                    {
                        builder.Append("${").Append((string) ((ExpressionNode) node).Code).Append('}');
                    }
                    else if (node is ConditionNode)
                    {
                        builder.Append("?{").Append((string) ((ConditionNode) node).Code).Append('}');
                    }
                }
                return builder.ToString();
            }
        }
    }
}

