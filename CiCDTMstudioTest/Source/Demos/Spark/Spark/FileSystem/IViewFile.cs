namespace Spark.FileSystem
{
    using System;
    using System.IO;

    public interface IViewFile
    {
        Stream OpenViewStream();

        long LastModified { get; }
    }
}

