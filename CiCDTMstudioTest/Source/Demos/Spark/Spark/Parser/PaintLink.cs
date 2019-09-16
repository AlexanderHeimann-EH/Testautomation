namespace Spark.Parser
{
    using System;
    using System.Runtime.CompilerServices;

    public class PaintLink
    {
        public PaintLink Next { get; set; }

        public Spark.Parser.Paint Paint { get; set; }
    }
}

