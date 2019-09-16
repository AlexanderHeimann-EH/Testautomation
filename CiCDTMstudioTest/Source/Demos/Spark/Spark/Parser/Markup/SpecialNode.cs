namespace Spark.Parser.Markup
{
    using System;
    using System.Collections.Generic;

    public class SpecialNode : Node
    {
        public IList<Node> Body = new List<Node>();
        public ElementNode Element;

        public SpecialNode(ElementNode element)
        {
            this.Element = element;
        }
    }
}

