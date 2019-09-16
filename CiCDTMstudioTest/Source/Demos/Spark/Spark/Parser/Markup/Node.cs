namespace Spark.Parser.Markup
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class Node
    {
        protected Node()
        {
        }

        public Node OriginalNode { get; set; }
    }
}

