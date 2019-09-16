namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class CacheChunk : Chunk
    {
        public CacheChunk()
        {
            this.Body = new List<Chunk>();
        }

        public IList<Chunk> Body { get; set; }

        public Snippets Expires { get; set; }

        public Snippets Key { get; set; }

        public Snippets Signal { get; set; }
    }
}

