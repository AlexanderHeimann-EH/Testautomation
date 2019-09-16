namespace Spark.Bindings
{
    using Spark.FileSystem;
    using System;
    using System.Runtime.CompilerServices;

    public class BindingRequest
    {
        public BindingRequest(IViewFolder viewFolder)
        {
            this.ViewFolder = viewFolder;
            this.ViewPath = string.Empty;
        }

        public IViewFolder ViewFolder { get; private set; }

        public string ViewPath { get; set; }
    }
}

