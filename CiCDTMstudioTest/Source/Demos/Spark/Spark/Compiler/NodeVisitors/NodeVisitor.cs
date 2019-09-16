namespace Spark.Compiler.NodeVisitors
{
    using System;

    public class NodeVisitor : NodeVisitor<object>
    {
        public NodeVisitor(VisitorContext context) : base(context)
        {
        }
    }
}

