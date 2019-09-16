namespace Spark.Compiler.ChunkVisitors
{
    using Spark;
    using Spark.Compiler;
    using System;
    using System.Collections.Generic;

    public class ChunkVisitor : AbstractChunkVisitor
    {
        protected override void Visit(AssignVariableChunk chunk)
        {
        }

        protected override void Visit(CacheChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(CodeStatementChunk chunk)
        {
        }

        protected override void Visit(ConditionalChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(ContentChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(ContentSetChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(DefaultVariableChunk chunk)
        {
        }

        protected override void Visit(ExtensionChunk chunk)
        {
            chunk.Extension.VisitChunk(this, OutputLocation.NotWriting, chunk.Body, null);
        }

        protected override void Visit(ForEachChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
        }

        protected override void Visit(LocalVariableChunk chunk)
        {
        }

        protected override void Visit(MacroChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(MarkdownChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(PageBaseTypeChunk chunk)
        {
        }

        protected override void Visit(RenderPartialChunk chunk)
        {
            base.Accept(chunk.Body);
            foreach (IList<Chunk> list in chunk.Sections.Values)
            {
                base.Accept(list);
            }
        }

        protected override void Visit(RenderSectionChunk chunk)
        {
        }

        protected override void Visit(ScopeChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(SendExpressionChunk chunk)
        {
        }

        protected override void Visit(SendLiteralChunk chunk)
        {
        }

        protected override void Visit(UseAssemblyChunk chunk)
        {
        }

        protected override void Visit(UseContentChunk chunk)
        {
            base.Accept(chunk.Default);
        }

        protected override void Visit(UseImportChunk chunk)
        {
        }

        protected override void Visit(UseMasterChunk chunk)
        {
        }

        protected override void Visit(UseNamespaceChunk chunk)
        {
        }

        protected override void Visit(ViewDataChunk chunk)
        {
        }

        protected override void Visit(ViewDataModelChunk chunk)
        {
        }
    }
}

