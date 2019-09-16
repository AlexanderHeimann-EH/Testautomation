namespace Spark.Parser.Markup
{
    using System;
    using System.Runtime.CompilerServices;

    public class EndElementNode : Node
    {
        public EndElementNode(string name) : this(name, string.Empty)
        {
        }

        public EndElementNode(string name, string preceedingWhitespace)
        {
            this.Name = name;
            this.PreceedingWhitespace = preceedingWhitespace;
        }

        public string Name { get; set; }

        public string Namespace { get; set; }

        public string PreceedingWhitespace { get; set; }
    }
}

