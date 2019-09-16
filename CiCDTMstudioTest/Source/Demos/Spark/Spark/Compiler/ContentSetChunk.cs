namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ContentSetChunk : Chunk
    {
        public ContentSetChunk()
        {
            this.Body = new List<Chunk>();
            this.AddType = ContentAddType.Replace;
        }

        public ContentAddType AddType { get; set; }

        public IList<Chunk> Body { get; set; }

        public Snippets Variable { get; set; }
    }
}

