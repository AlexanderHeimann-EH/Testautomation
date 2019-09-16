namespace Spark.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class MacroChunk : Chunk
    {
        public MacroChunk()
        {
            this.Body = new List<Chunk>();
            this.Parameters = new List<MacroParameter>();
        }

        public IList<Chunk> Body { get; set; }

        public string Name { get; set; }

        public IList<MacroParameter> Parameters { get; set; }
    }
}

