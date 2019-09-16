namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class LocalVariableChunk : Chunk
    {
        public LocalVariableChunk()
        {
            this.Type = "var";
        }

        public Snippets Name { get; set; }

        public Snippets Type { get; set; }

        public Snippets Value { get; set; }
    }
}

