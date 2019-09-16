namespace Spark.Compiler.Javascript.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using Spark.Parser.Code;
    using System;

    public abstract class CodeProcessingChunkVisitor : ChunkVisitor
    {
        protected CodeProcessingChunkVisitor()
        {
        }

        public abstract Snippets Process(Chunk chunk, Snippets code);
        protected override void Visit(AssignVariableChunk chunk)
        {
            chunk.Value = this.Process(chunk, chunk.Value);
            base.Visit(chunk);
        }

        protected override void Visit(CodeStatementChunk chunk)
        {
            chunk.Code = this.Process(chunk, chunk.Code);
            base.Visit(chunk);
        }

        protected override void Visit(ConditionalChunk chunk)
        {
            chunk.Condition = this.Process(chunk, chunk.Condition);
            base.Visit(chunk);
        }

        protected override void Visit(DefaultVariableChunk chunk)
        {
            chunk.Value = this.Process(chunk, chunk.Value);
            base.Visit(chunk);
        }

        protected override void Visit(ForEachChunk chunk)
        {
            chunk.Code = this.Process(chunk, chunk.Code);
            base.Visit(chunk);
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
            chunk.Value = this.Process(chunk, chunk.Value);
            base.Visit(chunk);
        }

        protected override void Visit(LocalVariableChunk chunk)
        {
            chunk.Value = this.Process(chunk, chunk.Value);
            base.Visit(chunk);
        }

        protected override void Visit(SendExpressionChunk chunk)
        {
            chunk.Code = this.Process(chunk, chunk.Code);
            base.Visit(chunk);
        }
    }
}

