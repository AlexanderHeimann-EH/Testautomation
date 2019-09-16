namespace Spark.Parser.Markup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IndentationNode : Node
    {
        public string Whitespace;

        public IndentationNode(string whitespace)
        {
            this.Whitespace = whitespace;
        }

        public IndentationNode(ICollection<char> text)
        {
            this.Whitespace = new string(text.ToArray<char>());
        }
    }
}

