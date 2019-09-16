namespace Spark.Bindings
{
    using System;
    using System.Runtime.CompilerServices;

    public class BindingPrefixReference : BindingNode
    {
        public BindingPrefixReference(string prefix)
        {
            this.Prefix = prefix;
        }

        public bool AssumeDictionarySyntax { get; set; }

        public bool AssumeStringValue { get; set; }

        public string Prefix { get; set; }
    }
}

