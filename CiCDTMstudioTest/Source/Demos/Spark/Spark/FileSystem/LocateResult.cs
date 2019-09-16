namespace Spark.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class LocateResult
    {
        public string Path { get; set; }

        public IList<string> SearchedLocations { get; set; }

        public IViewFile ViewFile { get; set; }
    }
}

