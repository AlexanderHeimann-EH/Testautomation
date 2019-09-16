namespace Spark.Compiler.ChunkVisitors
{
    using Spark.Compiler;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class AbstractChunkVisitor : IChunkVisitor
    {
        private readonly Stack<RenderPartialChunk> _renderPartialStack = new Stack<RenderPartialChunk>();

        protected AbstractChunkVisitor()
        {
        }

        public void Accept(Chunk chunk)
        {
            if (chunk == null)
            {
                throw new ArgumentNullException("chunk");
            }
            if (chunk is SendLiteralChunk)
            {
                this.Visit((SendLiteralChunk) chunk);
            }
            else if (chunk is LocalVariableChunk)
            {
                this.Visit((LocalVariableChunk) chunk);
            }
            else if (chunk is SendExpressionChunk)
            {
                this.Visit((SendExpressionChunk) chunk);
            }
            else if (chunk is ForEachChunk)
            {
                this.Visit((ForEachChunk) chunk);
            }
            else if (chunk is ScopeChunk)
            {
                this.Visit((ScopeChunk) chunk);
            }
            else if (chunk is GlobalVariableChunk)
            {
                this.Visit((GlobalVariableChunk) chunk);
            }
            else if (chunk is AssignVariableChunk)
            {
                this.Visit((AssignVariableChunk) chunk);
            }
            else if (chunk is ContentChunk)
            {
                this.Visit((ContentChunk) chunk);
            }
            else if (chunk is ContentSetChunk)
            {
                this.Visit((ContentSetChunk) chunk);
            }
            else if (chunk is UseContentChunk)
            {
                this.Visit((UseContentChunk) chunk);
            }
            else if (chunk is RenderPartialChunk)
            {
                this.Visit((RenderPartialChunk) chunk);
            }
            else if (chunk is RenderSectionChunk)
            {
                this.Visit((RenderSectionChunk) chunk);
            }
            else if (chunk is ViewDataChunk)
            {
                this.Visit((ViewDataChunk) chunk);
            }
            else if (chunk is ViewDataModelChunk)
            {
                this.Visit((ViewDataModelChunk) chunk);
            }
            else if (chunk is UseNamespaceChunk)
            {
                this.Visit((UseNamespaceChunk) chunk);
            }
            else if (chunk is ConditionalChunk)
            {
                this.Visit((ConditionalChunk) chunk);
            }
            else if (chunk is ExtensionChunk)
            {
                this.Visit((ExtensionChunk) chunk);
            }
            else if (chunk is CodeStatementChunk)
            {
                this.Visit((CodeStatementChunk) chunk);
            }
            else if (chunk is MacroChunk)
            {
                this.Visit((MacroChunk) chunk);
            }
            else if (chunk is UseAssemblyChunk)
            {
                this.Visit((UseAssemblyChunk) chunk);
            }
            else if (chunk is UseImportChunk)
            {
                this.Visit((UseImportChunk) chunk);
            }
            else if (chunk is DefaultVariableChunk)
            {
                this.Visit((DefaultVariableChunk) chunk);
            }
            else if (chunk is UseMasterChunk)
            {
                this.Visit((UseMasterChunk) chunk);
            }
            else if (chunk is PageBaseTypeChunk)
            {
                this.Visit((PageBaseTypeChunk) chunk);
            }
            else if (chunk is CacheChunk)
            {
                this.Visit((CacheChunk) chunk);
            }
            else
            {
                if (!(chunk is MarkdownChunk))
                {
                    throw new CompilerException(string.Format("Unknown chunk type {0}", chunk.GetType().Name));
                }
                this.Visit((MarkdownChunk) chunk);
            }
        }

        public void Accept(IList<Chunk> chunks)
        {
            if (chunks == null)
            {
                throw new ArgumentNullException("chunks");
            }
            foreach (Chunk chunk in chunks)
            {
                this.Accept(chunk);
            }
        }

        protected void EnterRenderPartial(RenderPartialChunk chunk)
        {
            if (this._renderPartialStack.Any<RenderPartialChunk>(recursed => recursed.FileContext == chunk.FileContext))
            {
                StringBuilder builder = new StringBuilder();
                foreach (RenderPartialChunk chunk2 in this._renderPartialStack.Concat<RenderPartialChunk>(new RenderPartialChunk[] { chunk }))
                {
                    builder.Append(chunk2.Position.SourceContext.FileName).Append("(").Append(chunk2.Position.Line).Append(",").Append(chunk2.Position.Line).Append("): rendering partial '").Append(chunk2.Name).AppendLine("'");
                }
                throw new CompilerException(string.Format("Recursive rendering of partial files not possible.\r\n{0}", builder));
            }
            this._renderPartialStack.Push(chunk);
        }

        protected RenderPartialChunk ExitRenderPartial()
        {
            if (!this._renderPartialStack.Any<RenderPartialChunk>())
            {
                throw new CompilerException("Internal compiler error. Partial stack unexpectedly empty.");
            }
            return this._renderPartialStack.Pop();
        }

        protected void ExitRenderPartial(RenderPartialChunk expectedTopChunk)
        {
            RenderPartialChunk chunk = this.ExitRenderPartial();
            if (expectedTopChunk != chunk)
            {
                throw new CompilerException(string.Format("Internal compiler error. Expected to be leaving partial {0} but was {1}", expectedTopChunk.FileContext.ViewSourcePath, chunk.FileContext.ViewSourcePath));
            }
        }

        protected abstract void Visit(AssignVariableChunk chunk);
        protected abstract void Visit(CacheChunk chunk);
        protected abstract void Visit(CodeStatementChunk chunk);
        protected abstract void Visit(ConditionalChunk chunk);
        protected abstract void Visit(ContentChunk chunk);
        protected abstract void Visit(ContentSetChunk chunk);
        protected abstract void Visit(DefaultVariableChunk chunk);
        protected abstract void Visit(ExtensionChunk chunk);
        protected abstract void Visit(ForEachChunk chunk);
        protected abstract void Visit(GlobalVariableChunk chunk);
        protected abstract void Visit(LocalVariableChunk chunk);
        protected abstract void Visit(MacroChunk chunk);
        protected abstract void Visit(MarkdownChunk chunk);
        protected abstract void Visit(PageBaseTypeChunk chunk);
        protected abstract void Visit(RenderPartialChunk chunk);
        protected abstract void Visit(RenderSectionChunk chunk);
        protected abstract void Visit(ScopeChunk chunk);
        protected abstract void Visit(SendExpressionChunk chunk);
        protected abstract void Visit(SendLiteralChunk chunk);
        protected abstract void Visit(UseAssemblyChunk chunk);
        protected abstract void Visit(UseContentChunk chunk);
        protected abstract void Visit(UseImportChunk chunk);
        protected abstract void Visit(UseMasterChunk chunk);
        protected abstract void Visit(UseNamespaceChunk chunk);
        protected abstract void Visit(ViewDataChunk chunk);
        protected abstract void Visit(ViewDataModelChunk chunk);

        public RenderPartialChunk OuterPartial
        {
            get
            {
                if (!this._renderPartialStack.Any<RenderPartialChunk>())
                {
                    return null;
                }
                return this._renderPartialStack.Peek();
            }
        }
    }
}

