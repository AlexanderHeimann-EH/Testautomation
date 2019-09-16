using Spark.Compiler;
using Spark.Parser.Markup;

namespace Spark.Parser.Syntax
{
    using Spark.Compiler.NodeVisitors;
    using Spark.Parser;
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;

    public class CSharpSyntaxProvider : AbstractSyntaxProvider
    {
        private static readonly CSharpGrammar _grammar = new CSharpGrammar();

        public override IList<Chunk> GetChunks(VisitorContext context, string path)
        {
            context.ViewPath = path;
            Position position = new Position(AbstractSyntaxProvider.CreateSourceContext(context.ViewPath, context.ViewFolder));
            ParseResult<IList<Node>> result = _grammar.Nodes(position);
            if (result.Rest.PotentialLength() != 0)
            {
                base.ThrowParseException(context.ViewPath, position, result.Rest);
            }
            context.Paint = result.Rest.GetPaint();
            ChunkBuilderVisitor visitor = new ChunkBuilderVisitor(context);
            visitor.Accept(result.Value);
            return visitor.Chunks;
        }

        public override IList<Node> IncludeFile(VisitorContext context, string path, string parse)
        {
            throw new NotImplementedException();
        }

        public override Snippets ParseFragment(Position begin, Position end)
        {
            throw new NotImplementedException();
        }
    }
}

