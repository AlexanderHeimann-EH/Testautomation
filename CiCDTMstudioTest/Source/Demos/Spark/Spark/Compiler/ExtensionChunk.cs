namespace Spark.Compiler
{
    using Spark;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ExtensionChunk : Chunk
    {
        public ExtensionChunk()
        {
            this.Body = new List<Chunk>();
        }

        public IList<Chunk> Body { get; set; }

        public ISparkExtension Extension { get; set; }
    }
}

