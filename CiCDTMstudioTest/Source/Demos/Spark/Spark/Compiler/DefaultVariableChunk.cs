namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class DefaultVariableChunk : Chunk
    {
        public DefaultVariableChunk()
        {
            this.Type = "var";
        }

        public string Name { get; set; }

        public Snippets Type { get; set; }

        public Snippets Value { get; set; }
    }
}

