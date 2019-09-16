namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ConditionalChunk : Chunk
    {
        public ConditionalChunk()
        {
            this.Body = new List<Chunk>();
        }

        public IList<Chunk> Body { get; set; }

        public Snippets Condition { get; set; }

        public ConditionalType Type { get; set; }
    }
}

