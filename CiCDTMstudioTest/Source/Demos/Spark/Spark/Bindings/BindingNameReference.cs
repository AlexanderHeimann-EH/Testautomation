namespace Spark.Bindings
{
    using System;
    using System.Runtime.CompilerServices;

    public class BindingNameReference : BindingNode
    {
        public BindingNameReference(string name)
        {
            this.Name = name;
        }

        public bool AssumeStringValue { get; set; }

        public string Name { get; set; }
    }
}

