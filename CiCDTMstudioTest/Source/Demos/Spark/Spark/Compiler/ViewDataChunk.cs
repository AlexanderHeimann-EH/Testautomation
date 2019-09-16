namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class ViewDataChunk : Chunk
    {
        public ViewDataChunk()
        {
            this.Type = "object";
        }

        public Snippets Default { get; set; }

        public string Key { get; set; }

        public Snippets Name { get; set; }

        public Snippets Type { get; set; }
    }
}

