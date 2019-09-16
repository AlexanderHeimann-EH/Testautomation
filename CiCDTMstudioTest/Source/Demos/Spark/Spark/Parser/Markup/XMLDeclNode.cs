namespace Spark.Parser.Markup
{
    using System;
    using System.Runtime.CompilerServices;

    public class XMLDeclNode : Node
    {
        public string Encoding { get; set; }

        public string Standalone { get; set; }
    }
}

