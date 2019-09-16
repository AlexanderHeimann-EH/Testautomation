namespace Spark.Compiler.Javascript.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using System;
    using System.Text;

    public class JavascriptGlobalMembersVisitor : ChunkVisitor
    {
        private readonly StringBuilder _source;

        public JavascriptGlobalMembersVisitor(StringBuilder source)
        {
            this._source = source;
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
            this._source.Append((string) chunk.Name).Append(":").Append((string) chunk.Value).AppendLine(",");
        }
    }
}

