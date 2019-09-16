namespace Spark.Compiler.ChunkVisitors
{
    using Spark.Compiler;
    using System;

    public class GeneratedCodeVisitorBase : ChunkVisitor
    {
        protected override void Visit(RenderPartialChunk chunk)
        {
            base.EnterRenderPartial(chunk);
            base.Accept(chunk.FileContext.Contents);
            base.ExitRenderPartial(chunk);
        }

        protected override void Visit(RenderSectionChunk chunk)
        {
            RenderPartialChunk chunk2 = base.ExitRenderPartial();
            if (string.IsNullOrEmpty(chunk.Name))
            {
                base.Accept(chunk2.Body);
            }
            else if (chunk2.Sections.ContainsKey(chunk.Name))
            {
                base.Accept(chunk2.Sections[chunk.Name]);
            }
            else
            {
                base.EnterRenderPartial(chunk2);
                base.Accept(chunk.Default);
                base.ExitRenderPartial(chunk2);
            }
            base.EnterRenderPartial(chunk2);
        }
    }
}

