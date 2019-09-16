namespace Spark.Parser
{
    using Spark;
    using Spark.Bindings;
    using Spark.Compiler;
    using Spark.Compiler.CSharp.ChunkVisitors;
    using Spark.Compiler.NodeVisitors;
    using Spark.FileSystem;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class ViewLoader
    {
        private readonly Dictionary<string, Entry> entries = new Dictionary<string, Entry>();
        private readonly List<string> pending = new List<string>();

        private Entry BindEntry(string referencePath)
        {
            if (this.entries.ContainsKey(referencePath))
            {
                return this.entries[referencePath];
            }
            IViewFile viewSource = this.ViewFolder.GetViewSource(referencePath);
            Entry entry = new Entry {
                ViewPath = referencePath,
                ViewFile = viewSource,
                LastModified = viewSource.LastModified
            };
            this.entries.Add(referencePath, entry);
            this.pending.Add(referencePath);
            return entry;
        }

        private static string EnsureShadeExtension(string viewName)
        {
            if (string.Equals(Path.GetExtension(viewName), Constants.DotShade, StringComparison.OrdinalIgnoreCase))
            {
                return viewName;
            }
            return (viewName + Constants.DotShade);
        }

        private static string EnsureSparkExtension(string viewName)
        {
            if (string.Equals(Path.GetExtension(viewName), Constants.DotSpark, StringComparison.OrdinalIgnoreCase))
            {
                return viewName;
            }
            return (viewName + Constants.DotSpark);
        }

        public void EvictEntry(string referencePath)
        {
            if (this.entries.ContainsKey(referencePath))
            {
                this.entries.Remove(referencePath);
            }
        }

        private IEnumerable<string> FindAllPartialFiles(IEnumerable<string> folderPaths)
        {
            foreach (string iteratorVariable0 in folderPaths.Distinct<string>())
            {
                foreach (string iteratorVariable1 in this.ViewFolder.ListViews(iteratorVariable0))
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(iteratorVariable1);
                    if (fileNameWithoutExtension.StartsWith("_"))
                    {
                        yield return fileNameWithoutExtension.Substring(1);
                    }
                }
            }
        }

        private IEnumerable<Binding> FindBindings(string viewPath)
        {
            if (this.BindingProvider == null)
            {
                return new Binding[0];
            }
            BindingRequest bindingRequest = new BindingRequest(this.ViewFolder) {
                ViewPath = viewPath
            };
            return this.BindingProvider.GetBindings(bindingRequest);
        }

        public IList<string> FindPartialFiles(string viewPath)
        {
            IEnumerable<string> folderPaths = PartialViewFolderPaths(viewPath);
            return this.FindAllPartialFiles(folderPaths).Distinct<string>().ToList<string>().AsReadOnly();
        }

        public IEnumerable<IList<Chunk>> GetEverythingLoaded()
        {
            return (from e in this.entries.Values select e.Chunks);
        }

        public virtual bool IsCurrent()
        {
            return this.entries.All<KeyValuePair<string, Entry>>(entry => (entry.Value.ViewFile.LastModified == entry.Value.LastModified));
        }

        public IList<Chunk> Load(string viewPath)
        {
            if (string.IsNullOrEmpty(viewPath))
            {
                return null;
            }
            Entry entry = this.BindEntry(viewPath);
            if (entry == null)
            {
                return null;
            }
            string path = Path.Combine(Path.GetDirectoryName(viewPath), Constants.GlobalSpark);
            if (this.ViewFolder.HasView(path))
            {
                this.BindEntry(path);
            }
            string str2 = Path.Combine(Constants.Shared, Constants.GlobalSpark);
            if (this.ViewFolder.HasView(str2))
            {
                this.BindEntry(str2);
            }
            while (this.pending.Count != 0)
            {
                string item = this.pending.First<string>();
                this.pending.Remove(item);
                this.LoadInternal(item);
            }
            return entry.Chunks;
        }

        private void LoadInternal(string viewPath)
        {
            if (!string.IsNullOrEmpty(viewPath))
            {
                Entry entry = this.BindEntry(viewPath);
                VisitorContext context = new VisitorContext {
                    ViewFolder = this.ViewFolder,
                    Prefix = this.Prefix,
                    ExtensionFactory = this.ExtensionFactory,
                    PartialFileNames = this.FindPartialFiles(viewPath),
                    Bindings = this.FindBindings(viewPath),
                    ParseSectionTagAsSegment = this.ParseSectionTagAsSegment,
                    AttributeBehaviour = this.AttributeBehaviour
                };
                entry.Chunks = this.SyntaxProvider.GetChunks(context, viewPath);
                FileReferenceVisitor visitor = new FileReferenceVisitor();
                visitor.Accept(entry.Chunks);
                foreach (RenderPartialChunk chunk in visitor.References)
                {
                    string str = this.ResolveReference(viewPath, chunk.Name);
                    if (!string.IsNullOrEmpty(str))
                    {
                        chunk.FileContext = this.BindEntry(str).FileContext;
                    }
                }
            }
        }

        private static IEnumerable<string> PartialViewFolderPaths(string viewPath)
        {
            do
            {
                viewPath = Path.GetDirectoryName(viewPath);
                yield return viewPath;
                yield return Path.Combine(viewPath, Constants.Shared);
            }
            while (!string.IsNullOrEmpty(viewPath));
        }

        private string ResolveReference(string existingViewPath, string viewName)
        {
            string viewNameWithSparkExtension = EnsureSparkExtension(viewName);
            string viewNameWithShadeExtension = EnsureShadeExtension(viewName);
            IEnumerable<string> source = from x in PartialViewFolderPaths(existingViewPath) select new string[] { Path.Combine(x, viewNameWithSparkExtension), Path.Combine(x, viewNameWithShadeExtension) };
            string str = source.FirstOrDefault<string>(x => this.ViewFolder.HasView(x));
            if (str == null)
            {
                throw new FileNotFoundException(string.Format("Unable to locate {0} in {1}", viewName, string.Join(", ", source.ToArray<string>())), viewName);
            }
            return str;
        }

        public Spark.AttributeBehaviour AttributeBehaviour { get; set; }

        public IBindingProvider BindingProvider { get; set; }

        public ISparkExtensionFactory ExtensionFactory { get; set; }

        public bool ParseSectionTagAsSegment { get; set; }

        public string Prefix { get; set; }

        public ISparkSyntaxProvider SyntaxProvider { get; set; }

        public IViewFolder ViewFolder { get; set; }



        private class Entry
        {
            private readonly Spark.Compiler.FileContext fileContext = new Spark.Compiler.FileContext();

            public IList<Chunk> Chunks
            {
                get
                {
                    return this.fileContext.Contents;
                }
                set
                {
                    this.fileContext.Contents = value;
                }
            }

            public Spark.Compiler.FileContext FileContext
            {
                get
                {
                    return this.fileContext;
                }
            }

            public long LastModified { get; set; }

            public IViewFile ViewFile { get; set; }

            public string ViewPath
            {
                get
                {
                    return this.fileContext.ViewSourcePath;
                }
                set
                {
                    this.fileContext.ViewSourcePath = value;
                }
            }
        }
    }
}

