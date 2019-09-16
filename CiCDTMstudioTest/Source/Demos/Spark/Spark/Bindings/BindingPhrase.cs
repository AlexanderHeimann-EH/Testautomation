namespace Spark.Bindings
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class BindingPhrase
    {
        public IList<BindingNode> Nodes { get; set; }

        public PhraseType Type { get; set; }

        public enum PhraseType
        {
            Expression,
            Statement
        }
    }
}

