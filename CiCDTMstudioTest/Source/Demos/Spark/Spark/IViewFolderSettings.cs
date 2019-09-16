namespace Spark
{
    using Spark.FileSystem;
    using System;
    using System.Collections.Generic;

    public interface IViewFolderSettings
    {
        ViewFolderType FolderType { get; set; }

        string Name { get; set; }

        IDictionary<string, string> Parameters { get; set; }

        string Subfolder { get; set; }

        string Type { get; set; }
    }
}

