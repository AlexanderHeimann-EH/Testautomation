namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ForEachChunk : Chunk
    {
        public ForEachChunk()
        {
            this.Body = new List<Chunk>();
        }

        public IList<Chunk> Body { get; set; }

        public Snippets Code { get; set; }
    }
}

