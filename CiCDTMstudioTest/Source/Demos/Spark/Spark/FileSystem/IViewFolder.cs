namespace Spark.FileSystem
{
    using System;
    using System.Collections.Generic;

    public interface IViewFolder
    {
        IViewFile GetViewSource(string path);
        bool HasView(string path);
        IList<string> ListViews(string path);
    }
}

