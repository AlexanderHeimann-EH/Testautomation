namespace Spark.Bindings
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Binding
    {
        public string ElementName { get; set; }

        public bool HasChildReference { get; set; }

        public IEnumerable<BindingPhrase> Phrases { get; set; }
    }
}

