namespace Spark.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ScopeChunk : Chunk
    {
        public ScopeChunk()
        {
            this.Body = new List<Chunk>();
        }

        public IList<Chunk> Body { get; set; }
    }
}

