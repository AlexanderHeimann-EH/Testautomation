namespace Spark.Compiler.CSharp.ChunkVisitors
{
    using Spark;
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class UsingNamespaceVisitor : ChunkVisitor
    {
        private readonly Dictionary<string, Assembly> _assemblyAdded = new Dictionary<string, Assembly>();
        private readonly Dictionary<string, object> _namespaceAdded = new Dictionary<string, object>();
        private readonly Stack<string> _noncyclic = new Stack<string>();
        private readonly SourceWriter _source;

        public UsingNamespaceVisitor(SourceWriter output)
        {
            this._source = output;
        }

        public void UsingAssembly(string assemblyString)
        {
            if (!this._assemblyAdded.ContainsKey(assemblyString))
            {
                Assembly assembly = Assembly.Load(assemblyString);
                this._assemblyAdded.Add(assemblyString, assembly);
            }
        }

        public void UsingNamespace(Snippets ns)
        {
            if (!this._namespaceAdded.ContainsKey((string) ns))
            {
                this._namespaceAdded.Add((string) ns, null);
                this._source.Write("using ").WriteCode(ns).WriteLine(";");
            }
        }

        protected override void Visit(ExtensionChunk chunk)
        {
            chunk.Extension.VisitChunk(this, OutputLocation.UsingNamespace, chunk.Body, this._source.GetStringBuilder());
        }

        protected override void Visit(RenderPartialChunk chunk)
        {
            if (!this._noncyclic.Contains(chunk.FileContext.ViewSourcePath))
            {
                this._noncyclic.Push(chunk.FileContext.ViewSourcePath);
                base.Accept(chunk.FileContext.Contents);
                this._noncyclic.Pop();
            }
        }

        protected override void Visit(UseAssemblyChunk chunk)
        {
            this.UsingAssembly(chunk.Assembly);
        }

        protected override void Visit(UseNamespaceChunk chunk)
        {
            this.UsingNamespace(chunk.Namespace);
        }

        public ICollection<Assembly> Assemblies
        {
            get
            {
                return this._assemblyAdded.Values;
            }
        }
    }
}

