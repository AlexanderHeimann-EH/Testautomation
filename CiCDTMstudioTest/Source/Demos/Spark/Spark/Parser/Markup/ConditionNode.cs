namespace Spark.Parser.Markup
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ConditionNode : Node
    {
        public ConditionNode()
        {
            this.Nodes = new List<Node>();
        }

        public ConditionNode(Snippets snippets) : this()
        {
            this.Code = snippets;
        }

        public ConditionNode(string code) : this()
        {
            Snippet[] collection = new Snippet[1];
            Snippet snippet = new Snippet {
                Value = code
            };
            collection[0] = snippet;
            this.Code = new Snippets(collection);
        }

        public ConditionNode(IEnumerable<Snippet> snippets) : this()
        {
            this.Code = new Snippets(snippets);
        }

        public Snippets Code { get; set; }

        public IList<Node> Nodes { get; set; }
    }
}

