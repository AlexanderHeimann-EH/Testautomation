namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class CodeStatementChunk : Chunk
    {
        public Snippets Code { get; set; }
    }
}

