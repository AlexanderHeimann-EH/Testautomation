using System.Linq;

namespace Spark.FileSystem
{
    using System;
    using System.IO;
    using System.Reflection;

    public class EmbeddedViewFolder : InMemoryViewFolder
    {
        private readonly System.Reflection.Assembly _assembly;
        private readonly string _resourcePath;

        public EmbeddedViewFolder(System.Reflection.Assembly assembly, string resourcePath)
        {
            this._assembly = assembly;
            this._resourcePath = resourcePath;
            this.LoadAllResources(assembly, resourcePath);
        }

        private void LoadAllResources(System.Reflection.Assembly assembly, string path)
        {
            foreach (string str in from name in assembly.GetManifestResourceNames()
                where name.StartsWith(path + ".", StringComparison.InvariantCultureIgnoreCase)
                select name)
            {
                using (Stream stream = assembly.GetManifestResourceStream(str))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    string key = str.Substring(path.Length + 1).Replace('.', Path.DirectorySeparatorChar);
                    int length = key.LastIndexOf(Path.DirectorySeparatorChar);
                    if (length >= 0)
                    {
                        key = key.Substring(0, length) + "." + key.Substring(length + 1);
                    }
                    base.Add(key, buffer);
                }
            }
        }

        public System.Reflection.Assembly Assembly
        {
            get
            {
                return this._assembly;
            }
        }
    }
}

