using Spark.Compiler;
using Spark.Parser.Markup;

namespace Spark
{
    using Spark.Compiler.NodeVisitors;
    using Spark.Parser;
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;

    public interface ISparkSyntaxProvider
    {
        IList<Chunk> GetChunks(VisitorContext context, string path);
        IList<Node> IncludeFile(VisitorContext context, string path, string parse);
        Snippets ParseFragment(Position begin, Position end);
    }
}

