namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class SendExpressionChunk : Chunk
    {
        public bool AutomaticallyEncode { get; set; }

        public Snippets Code { get; set; }

        public bool SilentNulls { get; set; }
    }
}

