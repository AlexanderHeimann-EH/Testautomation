namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class ViewDataModelChunk : Chunk
    {
        public Snippets TModel { get; set; }

        public Snippets TModelAlias { get; set; }
    }
}

