namespace Spark.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class MarkdownChunk : Chunk
    {
        public MarkdownChunk()
        {
            this.Body = new List<Chunk>();
        }

        public IList<Chunk> Body { get; set; }
    }
}

