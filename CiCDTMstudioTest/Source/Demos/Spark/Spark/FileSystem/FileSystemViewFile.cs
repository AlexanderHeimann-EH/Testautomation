namespace Spark.FileSystem
{
    using System;
    using System.IO;

    public class FileSystemViewFile : IViewFile
    {
        private readonly string _fullPath;

        public FileSystemViewFile(string fullPath)
        {
            this._fullPath = fullPath;
        }

        public Stream OpenViewStream()
        {
            return new FileStream(this._fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public long LastModified
        {
            get
            {
                return File.GetLastWriteTimeUtc(this._fullPath).Ticks;
            }
        }
    }
}

