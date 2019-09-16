namespace Spark.Bindings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class BindingLiteral : BindingNode
    {
        public BindingLiteral(IEnumerable<char> text)
        {
            this.Text = new string(text.ToArray<char>());
        }

        public string Text { get; set; }
    }
}

