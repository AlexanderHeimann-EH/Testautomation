namespace Spark.Parser.Markup
{
    using System;
    using System.Runtime.CompilerServices;

    public class ProcessingInstructionNode : Node
    {
        public string Body { get; set; }

        public string Name { get; set; }
    }
}

