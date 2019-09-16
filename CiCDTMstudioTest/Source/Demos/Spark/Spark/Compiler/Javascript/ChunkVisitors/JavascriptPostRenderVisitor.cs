namespace Spark.Compiler.Javascript.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using System;
    using System.Text;

    public class JavascriptPostRenderVisitor : ChunkVisitor
    {
        private readonly StringBuilder _source;

        public JavascriptPostRenderVisitor(StringBuilder source)
        {
            this._source = source;
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
            this._source.Append("this.").Append((string) chunk.Name).Append(" = ").Append((string) chunk.Name).AppendLine(";");
        }
    }
}

