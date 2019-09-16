namespace Spark.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class RenderPartialChunk : Chunk
    {
        public RenderPartialChunk()
        {
            this.Body = new List<Chunk>();
            this.Sections = new Dictionary<string, IList<Chunk>>();
        }

        public IList<Chunk> Body { get; set; }

        public Spark.Compiler.FileContext FileContext { get; set; }

        public string Name { get; set; }

        public IDictionary<string, IList<Chunk>> Sections { get; set; }
    }
}

