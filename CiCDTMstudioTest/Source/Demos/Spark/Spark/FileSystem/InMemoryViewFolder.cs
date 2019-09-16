namespace Spark.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class InMemoryViewFolder : Dictionary<string, byte[]>, IViewFolder
    {
        private static readonly IEqualityComparer<string> _pathComparer = new PathComparer(StringComparer.InvariantCultureIgnoreCase);

        public InMemoryViewFolder() : base(_pathComparer)
        {
        }

        public void Add(string key, string value)
        {
            base.Add(key, GetBytes(value));
        }

        private static byte[] GetBytes(string value)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(value);
                }
                return stream.ToArray();
            }
        }

        public virtual IViewFile GetViewSource(string path)
        {
            if (!this.HasView(path))
            {
                throw new FileNotFoundException(string.Format("Template {0} not found", path), path);
            }
            return new InMemoryViewFile(this, path);
        }

        public virtual bool HasView(string path)
        {
            return base.ContainsKey(path);
        }

        public virtual IList<string> ListViews(string path)
        {
            return (from key in base.Keys
                where this.Comparer.Equals(path, Path.GetDirectoryName(key))
                select key).ToList<string>();
        }

        public void Set(string key, string value)
        {
            base[key] = GetBytes(value);
        }

        private class InMemoryViewFile : IViewFile
        {
            private readonly InMemoryViewFolder parent;
            private readonly string path;

            public InMemoryViewFile(InMemoryViewFolder parent, string path)
            {
                this.parent = parent;
                this.path = path;
            }

            public Stream OpenViewStream()
            {
                return new MemoryStream(this.parent[this.path], false);
            }

            public long LastModified
            {
                get
                {
                    return (long) this.parent[this.path].GetHashCode();
                }
            }
        }

        private class PathComparer : IEqualityComparer<string>
        {
            private readonly StringComparer _baseComparer;

            public PathComparer(StringComparer baseComparer)
            {
                this._baseComparer = baseComparer;
            }

            private static string Adjust(string obj)
            {
                if (obj != null)
                {
                    return obj.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                }
                return null;
            }

            public bool Equals(string x, string y)
            {
                return this._baseComparer.Equals(Adjust(x), Adjust(y));
            }

            public int GetHashCode(string obj)
            {
                return this._baseComparer.GetHashCode(Adjust(obj));
            }
        }
    }
}

