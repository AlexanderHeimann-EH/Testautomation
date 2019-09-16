namespace Spark.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class FileContext
    {
        public IList<Chunk> Contents;

        public string ViewSourcePath { get; set; }
    }
}

