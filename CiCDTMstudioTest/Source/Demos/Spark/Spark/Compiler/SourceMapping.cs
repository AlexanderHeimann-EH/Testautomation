namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class SourceMapping
    {
        public int OutputBegin { get; set; }

        public int OutputEnd { get; set; }

        public Snippet Source { get; set; }
    }
}

