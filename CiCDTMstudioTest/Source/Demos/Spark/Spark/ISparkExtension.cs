using Spark.Compiler;
using Spark.Parser.Markup;

namespace Spark
{
    using Spark.Compiler.ChunkVisitors;
    using Spark.Compiler.NodeVisitors;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISparkExtension
    {
        void VisitChunk(IChunkVisitor visitor, OutputLocation location, IList<Chunk> body, StringBuilder output);
        void VisitNode(INodeVisitor visitor, IList<Node> body, IList<Chunk> chunks);
    }
}

