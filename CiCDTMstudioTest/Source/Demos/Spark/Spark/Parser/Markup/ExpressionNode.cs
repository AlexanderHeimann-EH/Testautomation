namespace Spark.Parser.Markup
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ExpressionNode : Node
    {
        public ExpressionNode(Snippets code)
        {
            this.Code = code;
        }

        public ExpressionNode(string code) : this(new Snippets(code))
        {
        }

        public ExpressionNode(IEnumerable<Snippet> code) : this(new Snippets(code))
        {
        }

        public bool AutomaticEncoding { get; set; }

        public Snippets Code { get; set; }

        public bool SilentNulls { get; set; }
    }
}

