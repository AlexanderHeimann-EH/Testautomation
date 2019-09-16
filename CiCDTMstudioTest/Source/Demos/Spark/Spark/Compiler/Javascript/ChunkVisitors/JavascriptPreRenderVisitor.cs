namespace Spark.Compiler.Javascript.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using System;
    using System.Text;

    public class JavascriptPreRenderVisitor : ChunkVisitor
    {
        private readonly StringBuilder _source;

        public JavascriptPreRenderVisitor(StringBuilder source)
        {
            this._source = source;
        }

        protected override void Visit(DefaultVariableChunk chunk)
        {
            this._source.Append("if (typeof(").Append(chunk.Name).Append(") === 'undefined') ").Append(chunk.Name).Append(" = ").Append((string) chunk.Value).AppendLine(";");
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
            this._source.Append("var ").Append((string) chunk.Name).Append(" = this.").Append((string) chunk.Name).AppendLine(";");
        }

        protected override void Visit(MacroChunk chunk)
        {
            this._source.Append("function ").Append(chunk.Name).Append("(");
            string str = "";
            foreach (MacroParameter parameter in chunk.Parameters)
            {
                this._source.Append(str).Append(parameter.Name);
                str = ", ";
            }
            this._source.AppendLine(") {var __output__ = new StringWriter(); OutputScope(__output__);");
            new JavascriptGeneratedCodeVisitor(this._source).Accept(chunk.Body);
            this._source.AppendLine("DisposeOutputScope(); return __output__.toString();}");
        }

        protected override void Visit(ViewDataChunk chunk)
        {
            this._source.Append("var ").Append((string) chunk.Name).Append(" = viewData[\"").Append(chunk.Key).AppendLine("\"];");
        }
    }
}

