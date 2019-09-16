namespace Spark.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;

    public class VirtualPathProviderViewFolder : IViewFolder
    {
        private readonly string _virtualBaseDir;

        public VirtualPathProviderViewFolder(string virtualBaseDir)
        {
            this._virtualBaseDir = virtualBaseDir.TrimEnd(new char[] { Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar }) + "/";
        }

        private string Combine(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return this.VirtualBaseDir;
            }
            return HostingEnvironment.VirtualPathProvider.CombineVirtualPaths(this.VirtualBaseDir, path);
        }

        public IViewFile GetViewSource(string path)
        {
            return new VirtualPathFile(HostingEnvironment.VirtualPathProvider.GetFile(this.Combine(path)));
        }

        public bool HasView(string path)
        {
            return HostingEnvironment.VirtualPathProvider.FileExists(this.Combine(path));
        }

        public IList<string> ListViews(string path)
        {
            return (from f in HostingEnvironment.VirtualPathProvider.GetDirectory(this.Combine(path)).Files.OfType<VirtualFile>() select f.VirtualPath).ToArray<string>();
        }

        public string VirtualBaseDir
        {
            get
            {
                return this._virtualBaseDir;
            }
        }

        public class VirtualPathFile : IViewFile
        {
            private readonly VirtualFile _file;

            public VirtualPathFile(VirtualFile file)
            {
                this._file = file;
            }

            public Stream OpenViewStream()
            {
                return this._file.Open();
            }

            public long LastModified
            {
                get
                {
                    return (long) HostingEnvironment.VirtualPathProvider.GetFileHash(this._file.VirtualPath, new string[] { this._file.VirtualPath }).GetHashCode();
                }
            }
        }
    }
}

