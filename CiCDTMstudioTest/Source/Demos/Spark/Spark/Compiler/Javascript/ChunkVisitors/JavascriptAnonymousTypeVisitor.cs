namespace Spark.Compiler.Javascript.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Parser;
    using Spark.Parser.Code;
    using System;

    public class JavascriptAnonymousTypeVisitor : CodeProcessingChunkVisitor
    {
        private static readonly JavascriptAnonymousTypeGrammar _grammar = new JavascriptAnonymousTypeGrammar();

        public override Snippets Process(Chunk chunk, Snippets code)
        {
            if (code == null)
            {
                return null;
            }
            ParseResult<string> result = _grammar.ReformatCode(new Position(new SourceContext(code.ToString())));
            if (result == null)
            {
                return code;
            }
            if (result.Rest.PotentialLength() == 0)
            {
                return result.Value;
            }
            return (result.Value + result.Rest.Peek(result.Rest.PotentialLength()));
        }
    }
}

