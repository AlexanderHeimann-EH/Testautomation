namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class UseNamespaceChunk : Chunk
    {
        public Snippets Namespace { get; set; }
    }
}

