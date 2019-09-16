namespace Spark.Parser.Markup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class CommentNode : Node
    {
        public CommentNode(string text)
        {
            this.Text = text;
        }

        public CommentNode(IList<char> text)
        {
            this.Text = new string(text.ToArray<char>());
        }

        public string Text { get; set; }
    }
}

