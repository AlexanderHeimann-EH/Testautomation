namespace Spark.Caching
{
    using Spark.Spool;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class CacheMemento
    {
        public CacheMemento()
        {
            this.Content = new Dictionary<string, TextWriterMemento>();
            this.OnceTable = new Dictionary<string, string>();
        }

        public Dictionary<string, TextWriterMemento> Content { get; set; }

        public Dictionary<string, string> OnceTable { get; set; }

        public SpoolWriter SpoolOutput { get; set; }
    }
}

