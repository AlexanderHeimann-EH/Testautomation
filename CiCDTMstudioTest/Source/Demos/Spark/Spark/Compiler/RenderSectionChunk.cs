namespace Spark.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class RenderSectionChunk : Chunk
    {
        public RenderSectionChunk()
        {
            this.Default = new List<Chunk>();
        }

        public IList<Chunk> Default { get; set; }

        public string Name { get; set; }
    }
}

