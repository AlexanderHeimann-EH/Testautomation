namespace Spark.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class UseContentChunk : Chunk
    {
        public UseContentChunk()
        {
            this.Default = new List<Chunk>();
        }

        public IList<Chunk> Default { get; set; }

        public string Name { get; set; }
    }
}

