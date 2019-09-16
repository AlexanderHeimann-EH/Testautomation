using Spark.Parser.Markup;

namespace Spark.Compiler.NodeVisitors
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Frame<FrameData>
    {
        public FrameData Data { get; set; }

        public IList<Node> Nodes { get; set; }

        public Frame<FrameData> PriorFrame { get; set; }
    }
}

