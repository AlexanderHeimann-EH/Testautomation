namespace Spark
{
    using Spark.FileSystem;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class ViewFolderSettings : IViewFolderSettings
    {
        public ViewFolderType FolderType { get; set; }

        public string Name { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        public string Subfolder { get; set; }

        public string Type { get; set; }
    }
}

