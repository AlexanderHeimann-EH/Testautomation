namespace Spark.Compiler.ChunkVisitors
{
    using Spark.Compiler;
    using System;
    using System.Collections.Generic;

    public interface IChunkVisitor
    {
        void Accept(Chunk chunk);
        void Accept(IList<Chunk> chunks);
    }
}

