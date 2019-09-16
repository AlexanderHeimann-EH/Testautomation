using Spark.Compiler;

namespace Spark.Parser.Syntax
{
    using Spark;
    using Spark.Compiler.NodeVisitors;
    using Spark.Parser;
    using Spark.Parser.Code;
    using Spark.Parser.Markup;
    using Spark.Parser.Offset;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DefaultSyntaxProvider : AbstractSyntaxProvider
    {
        private readonly OffsetGrammar _grammar;

        public DefaultSyntaxProvider(IParserSettings settings)
        {
            this._grammar = new OffsetGrammar(settings);
        }

        private IList<INodeVisitor> BuildNodeVisitors(VisitorContext context)
        {
            return new INodeVisitor[] { new IndentationVisitor(context), new NamespaceVisitor(context), new IncludeVisitor(context), new PrefixExpandingVisitor(context), new SpecialNodeVisitor(context), new CacheAttributeVisitor(context), new WhitespaceCleanerVisitor(context), new ForEachAttributeVisitor(context), new ConditionalAttributeVisitor(context), new TestElseElementVisitor(context), new OnceAttributeVisitor(context), new UrlAttributeVisitor(context), new BindingExpansionVisitor(context) };
        }

        public override IList<Chunk> GetChunks(VisitorContext context, string path)
        {
            context.SyntaxProvider = this;
            context.ViewPath = path;
            Position position = new Position(AbstractSyntaxProvider.CreateSourceContext(context.ViewPath, context.ViewFolder));
            ParseAction<IList<Node>> action = string.Equals(Path.GetExtension(path), Constants.DotShade, StringComparison.OrdinalIgnoreCase) ? this._grammar.OffsetNodes : this._grammar.Nodes;
            ParseResult<IList<Node>> result = action(position);
            if (result.Rest.PotentialLength() != 0)
            {
                base.ThrowParseException(context.ViewPath, position, result.Rest);
            }
            context.Paint = result.Rest.GetPaint();
            IList<Node> nodes = result.Value;
            foreach (INodeVisitor visitor in this.BuildNodeVisitors(context))
            {
                visitor.Accept(nodes);
                nodes = visitor.Nodes;
            }
            ChunkBuilderVisitor visitor2 = new ChunkBuilderVisitor(context);
            visitor2.Accept(nodes);
            return visitor2.Chunks;
        }

        public override IList<Node> IncludeFile(VisitorContext context, string path, string parse)
        {
            string viewPath = context.ViewPath;
            string directoryName = Path.GetDirectoryName(context.ViewPath);
            string str3 = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            while (str3.StartsWith(string.Format("..{0}", Path.DirectorySeparatorChar)))
            {
                directoryName = Path.GetDirectoryName(directoryName);
                str3 = str3.Substring(3);
            }
            context.ViewPath = Path.Combine(directoryName, str3);
            SourceContext sourceContext = AbstractSyntaxProvider.CreateSourceContext(context.ViewPath, context.ViewFolder);
            switch (parse)
            {
                case "text":
                {
                    string text = sourceContext.Content.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                    return new TextNode[] { new TextNode(text) };
                }
                case "html":
                    return new TextNode[] { new TextNode(sourceContext.Content) };
            }
            Position position = new Position(sourceContext);
            ParseResult<IList<Node>> result = this._grammar.Nodes(position);
            if (result.Rest.PotentialLength() != 0)
            {
                base.ThrowParseException(context.ViewPath, position, result.Rest);
            }
            context.Paint = context.Paint.Union<Paint>(result.Rest.GetPaint());
            NamespaceVisitor visitor = new NamespaceVisitor(context);
            visitor.Accept(result.Value);
            IncludeVisitor visitor2 = new IncludeVisitor(context);
            visitor2.Accept(visitor.Nodes);
            context.ViewPath = viewPath;
            return visitor2.Nodes;
        }

        public override Snippets ParseFragment(Position begin, Position end)
        {
            ParseResult<Snippets> result = this._grammar.Expression(begin.Constrain(end));
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
    }
}

