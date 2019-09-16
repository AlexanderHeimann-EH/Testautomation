namespace Spark.Parser.Code
{
    using Spark.Compiler;
    using Spark.Parser;
    using Spark.Parser.Markup;
    using System;
    using System.Runtime.CompilerServices;

    public static class AttributeNodeExtensions
    {
        private static readonly CodeGrammar _grammar = new CodeGrammar();

        public static Snippets AsCode(this AttributeNode attr)
        {
            Position position = new Position(new SourceContext(attr.Value));
            ParseResult<Snippets> result = _grammar.Expression(position);
            int count = result.Rest.PotentialLength();
            if (count == 0)
            {
                return result.Value;
            }
            Snippets snippets = new Snippets(result.Value);
            Snippet item = new Snippet {
                Value = result.Rest.Peek(count),
                Begin = result.Rest,
                End = result.Rest.Advance(count)
            };
            snippets.Add(item);
            return snippets;
        }

        public static Snippets AsCodeInverted(this AttributeNode attr)
        {
            ExpressionBuilder builder = new ExpressionBuilder();
            foreach (Node node in attr.Nodes)
            {
                if (node is TextNode)
                {
                    builder.AppendLiteral(((TextNode) node).Text);
                }
                else if (node is ExpressionNode)
                {
                    builder.AppendExpression(((ExpressionNode) node).Code);
                }
                else if (node is EntityNode)
                {
                    builder.AppendLiteral("&" + ((EntityNode) node).Name + ";");
                }
            }
            return new Snippets(builder.ToCode());
        }
    }
}

