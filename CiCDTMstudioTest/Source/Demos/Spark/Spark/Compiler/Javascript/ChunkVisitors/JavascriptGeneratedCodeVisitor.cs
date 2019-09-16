namespace Spark.Compiler.Javascript.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using Spark.Parser.Code;
    using System;
    using System.Text;

    public class JavascriptGeneratedCodeVisitor : GeneratedCodeVisitorBase
    {
        private readonly StringBuilder _source;

        public JavascriptGeneratedCodeVisitor(StringBuilder source)
        {
            this._source = source;
        }

        protected override void Visit(AssignVariableChunk chunk)
        {
            this._source.Append(chunk.Name).Append(" = ").Append((string) chunk.Value).AppendLine(";");
        }

        protected override void Visit(CodeStatementChunk chunk)
        {
            this._source.Append((string) chunk.Code);
        }

        protected override void Visit(ConditionalChunk chunk)
        {
            switch (chunk.Type)
            {
                case ConditionalType.If:
                    this._source.Append("if (").Append((string) chunk.Condition).AppendLine(") {");
                    base.Accept(chunk.Body);
                    this._source.AppendLine("}");
                    return;

                case ConditionalType.Else:
                    this._source.AppendLine("else {");
                    base.Accept(chunk.Body);
                    this._source.AppendLine("}");
                    return;

                case ConditionalType.ElseIf:
                    this._source.Append("else if (").Append((string) chunk.Condition).AppendLine(") {");
                    base.Accept(chunk.Body);
                    this._source.AppendLine("}");
                    return;

                case ConditionalType.Once:
                    break;

                case ConditionalType.Unless:
                    this._source.Append("if (!(").Append((string) chunk.Condition).AppendLine(")) {");
                    base.Accept(chunk.Body);
                    this._source.AppendLine("}");
                    break;

                default:
                    return;
            }
        }

        protected override void Visit(ContentChunk chunk)
        {
            this._source.Append("OutputScope('").Append(chunk.Name).AppendLine("'); {");
            base.Accept(chunk.Body);
            this._source.AppendLine("} DisposeOutputScope();");
        }

        protected override void Visit(ContentSetChunk chunk)
        {
            this._source.AppendLine("OutputScope(new StringWriter()); {");
            base.Accept(chunk.Body);
            switch (chunk.AddType)
            {
                case ContentAddType.InsertBefore:
                    this._source.Append((string) chunk.Variable).Append(" = Output.toString() + ").Append((string) chunk.Variable).AppendLine(";");
                    break;

                case ContentAddType.AppendAfter:
                    this._source.Append((string) chunk.Variable).Append(" = ").Append((string) chunk.Variable).AppendLine(" + Output.toString();");
                    break;

                default:
                    this._source.Append((string) chunk.Variable).Append(" = Output.toString();");
                    break;
            }
            this._source.AppendLine("DisposeOutputScope();}");
        }

        protected override void Visit(ForEachChunk chunk)
        {
            ForEachInspector inspector = new ForEachInspector(chunk.Code);
            if (inspector.Recognized)
            {
                DetectCodeExpressionVisitor visitor = new DetectCodeExpressionVisitor(base.OuterPartial);
                DetectCodeExpressionVisitor.Entry entry = visitor.Add(inspector.VariableName + "Index");
                DetectCodeExpressionVisitor.Entry entry2 = visitor.Add(inspector.VariableName + "Count");
                DetectCodeExpressionVisitor.Entry entry3 = visitor.Add(inspector.VariableName + "IsFirst");
                DetectCodeExpressionVisitor.Entry entry4 = visitor.Add(inspector.VariableName + "IsLast");
                visitor.Accept(chunk.Body);
                if (entry4.Detected)
                {
                    entry.Detected = true;
                    entry2.Detected = true;
                }
                string str = "__iter__" + inspector.VariableName;
                if (entry2.Detected)
                {
                    this._source.Append("var ").Append(inspector.VariableName).Append("Count=0;for(var ").Append(str).Append(" in ").Append(inspector.CollectionCode).Append("){ if(typeof(").Append(inspector.CollectionCode).Append("[").Append(str).Append("])!='function') {").Append("++").Append(inspector.VariableName).Append("Count;}}");
                }
                if (entry.Detected)
                {
                    this._source.Append("var ").Append(inspector.VariableName).Append("Index=0;");
                }
                if (entry3.Detected)
                {
                    this._source.Append("var ").Append(inspector.VariableName).Append("IsFirst=true;");
                }
                this._source.Append("for (var ").Append(str).Append(" in ").Append(inspector.CollectionCode).Append(") {");
                this._source.Append("var ").Append(inspector.VariableName).Append("=").Append(inspector.CollectionCode).Append("[__iter__").Append(inspector.VariableName).Append("];");
                this._source.Append("if(typeof(").Append(inspector.VariableName).Append(")!='function') {");
                if (entry4.Detected)
                {
                    this._source.Append("var ").Append(inspector.VariableName).Append("IsLast=(").Append(inspector.VariableName).Append("Index==").Append(inspector.VariableName).Append("Count-1);");
                }
                this._source.AppendLine();
                base.Accept(chunk.Body);
                if (entry3.Detected)
                {
                    this._source.Append(inspector.VariableName).Append("IsFirst=false;");
                }
                if (entry.Detected)
                {
                    this._source.Append("++").Append(inspector.VariableName).Append("Index;");
                }
                this._source.AppendLine("}}");
            }
            else
            {
                this._source.Append("for (").Append((string) chunk.Code).AppendLine(") {");
                base.Accept(chunk.Body);
                this._source.Append("}");
            }
        }

        protected override void Visit(LocalVariableChunk chunk)
        {
            if (Snippets.IsNullOrEmpty(chunk.Value))
            {
                this._source.Append("var ").Append((string) chunk.Name).AppendLine(" = null;");
            }
            else
            {
                this._source.Append("var ").Append((string) chunk.Name).Append(" = ").Append((string) chunk.Value).AppendLine(";");
            }
        }

        protected override void Visit(MacroChunk chunk)
        {
        }

        protected override void Visit(ScopeChunk chunk)
        {
            this._source.AppendLine("{");
            base.Visit(chunk);
            this._source.AppendLine("}");
        }

        protected override void Visit(SendExpressionChunk chunk)
        {
            if (chunk.SilentNulls)
            {
                this._source.Append("if(typeof(").Append((string) chunk.Code).Append(") != 'undefined') ");
            }
            this._source.Append("Output.Write(").Append((string) chunk.Code).AppendLine(");");
        }

        protected override void Visit(SendLiteralChunk chunk)
        {
            if (!string.IsNullOrEmpty(chunk.Text))
            {
                string str = chunk.Text.Replace(@"\", @"\\").Replace("\t", @"\t").Replace("\r", @"\r").Replace("\n", @"\n").Replace("\"", "\\\"");
                this._source.Append("Output.Write(\"").Append(str).AppendLine("\");");
            }
        }

        protected override void Visit(UseContentChunk chunk)
        {
            this._source.Append("if (Content['").Append(chunk.Name).AppendLine("']) {");
            this._source.Append("Output.Write(Content['").Append(chunk.Name).AppendLine("']);}");
            if (chunk.Default.Count != 0)
            {
                this._source.AppendLine("else {");
                base.Accept(chunk.Default);
                this._source.AppendLine("}");
            }
        }
    }
}

