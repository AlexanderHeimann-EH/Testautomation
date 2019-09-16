namespace Spark.Parser.Markup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TextNode : Node
    {
        public string Text;

        public TextNode(string text)
        {
            this.Text = text;
        }

        public TextNode(ICollection<char> text)
        {
            this.Text = new string(text.ToArray<char>());
        }
    }
}

