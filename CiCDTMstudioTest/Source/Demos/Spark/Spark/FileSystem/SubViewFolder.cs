namespace Spark.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SubViewFolder : IViewFolder
    {
        private readonly string _subFolder;
        private readonly IViewFolder _viewFolder;

        public SubViewFolder(IViewFolder viewFolder, string subFolder)
        {
            this._viewFolder = viewFolder;
            this._subFolder = subFolder.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        }

        private string Adjust(string path)
        {
            if (!path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).StartsWith(this._subFolder, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }
            if (path.Length == this._subFolder.Length)
            {
                return string.Empty;
            }
            if ((path[this._subFolder.Length] != Path.AltDirectorySeparatorChar) && (path[this._subFolder.Length] != Path.DirectorySeparatorChar))
            {
                return null;
            }
            return path.Substring(this._subFolder.Length + 1);
        }

        public IViewFile GetViewSource(string path)
        {
            string str = this.Adjust(path);
            if (str == null)
            {
                throw new FileNotFoundException("File not found", path);
            }
            return this._viewFolder.GetViewSource(str);
        }

        public bool HasView(string path)
        {
            string str = this.Adjust(path);
            if (str == null)
            {
                return false;
            }
            return this._viewFolder.HasView(str);
        }

        public IList<string> ListViews(string path)
        {
            string str = this.Adjust(path);
            if (str == null)
            {
                return new string[0];
            }
            return (from file in this._viewFolder.ListViews(str) select Path.Combine(this._subFolder, Path.GetFileName(file))).ToArray<string>();
        }
    }
}

