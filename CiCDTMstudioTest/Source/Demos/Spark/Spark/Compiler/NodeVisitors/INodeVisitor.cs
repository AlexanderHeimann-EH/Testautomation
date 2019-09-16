namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;

    public interface INodeVisitor
    {
        void Accept(Node node);
        void Accept(IList<Node> nodes);

        VisitorContext Context { get; set; }

        IList<Node> Nodes { get; }
    }
}

