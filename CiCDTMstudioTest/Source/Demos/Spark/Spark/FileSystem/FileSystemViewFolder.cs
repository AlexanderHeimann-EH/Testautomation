namespace Spark.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileSystemViewFolder : IViewFolder
    {
        private readonly string _basePath;

        public FileSystemViewFolder(string basePath)
        {
            this._basePath = basePath;
        }

        public IViewFile GetViewSource(string path)
        {
            string str = Path.Combine(this._basePath, path);
            if (!File.Exists(str))
            {
                throw new FileNotFoundException("View source file not found.", str);
            }
            return new FileSystemViewFile(str);
        }

        public bool HasView(string path)
        {
            return File.Exists(Path.Combine(this._basePath, path));
        }

        public IList<string> ListViews(string path)
        {
            if (!Directory.Exists(Path.Combine(this._basePath, path)))
            {
                return new string[0];
            }
            return Directory.GetFiles(Path.Combine(this._basePath, path)).ToList<string>().ConvertAll<string>(viewPath => Path.GetFileName(viewPath));
        }

        public string BasePath
        {
            get
            {
                return this._basePath;
            }
        }
    }
}

