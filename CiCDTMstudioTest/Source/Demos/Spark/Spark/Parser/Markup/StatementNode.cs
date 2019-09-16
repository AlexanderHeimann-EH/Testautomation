namespace Spark.Parser.Markup
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class StatementNode : Node
    {
        public StatementNode(Snippets code)
        {
            this.Code = code;
        }

        public StatementNode(string code) : this(new Snippets(code))
        {
        }

        public StatementNode(IEnumerable<Snippet> snippets) : this(new Snippets(snippets))
        {
        }

        public Snippets Code { get; set; }
    }
}

