namespace Spark.Compiler.CSharp.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using System;
    using System.Collections.Generic;

    public class FileReferenceVisitor : ChunkVisitor
    {
        private readonly IList<RenderPartialChunk> _references = new List<RenderPartialChunk>();

        protected override void Visit(RenderPartialChunk chunk)
        {
            this.References.Add(chunk);
            base.Accept(chunk.Body);
            foreach (IList<Chunk> list in chunk.Sections.Values)
            {
                base.Accept(list);
            }
        }

        protected override void Visit(UseImportChunk chunk)
        {
            RenderPartialChunk item = new RenderPartialChunk {
                Name = chunk.Name
            };
            this.References.Add(item);
        }

        public IList<RenderPartialChunk> References
        {
            get
            {
                return this._references;
            }
        }
    }
}

