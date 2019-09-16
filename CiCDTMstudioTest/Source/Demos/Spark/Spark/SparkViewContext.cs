namespace Spark
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class SparkViewContext
    {
        public SparkViewContext()
        {
            this.Content = new Dictionary<string, TextWriter>();
            this.Globals = new Dictionary<string, object>();
            this.OnceTable = new Dictionary<string, string>();
        }

        public Dictionary<string, TextWriter> Content { get; set; }

        public Dictionary<string, object> Globals { get; set; }

        public Dictionary<string, string> OnceTable { get; set; }

        public TextWriter Output { get; set; }
    }
}

