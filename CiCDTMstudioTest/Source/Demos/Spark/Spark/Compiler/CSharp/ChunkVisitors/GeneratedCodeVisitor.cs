namespace Spark.Compiler.CSharp.ChunkVisitors
{
    using Spark;
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class GeneratedCodeVisitor : GeneratedCodeVisitorBase
    {
        private readonly NullBehaviour _nullBehaviour;
        private Scope _scope;
        private readonly SourceWriter _source;

        public GeneratedCodeVisitor(SourceWriter source, Dictionary<string, object> globalSymbols, NullBehaviour nullBehaviour)
        {
            this._nullBehaviour = nullBehaviour;
            this._source = source;
            Scope prior = new Scope(null) {
                Variables = globalSymbols
            };
            this._scope = new Scope(prior);
        }

        private void AppendCloseBrace()
        {
            this._source.RemoveIndent().WriteLine("}");
            this.PopScope();
        }

        private void AppendOpenBrace()
        {
            this.PushScope();
            this._source.WriteLine("{").AddIndent();
        }

        private void CodeDefault()
        {
            if (this._source.AdjustDebugSymbols)
            {
                this._source.WriteDirective("#line default");
            }
        }

        private void CodeHidden()
        {
            if (this._source.AdjustDebugSymbols)
            {
                this._source.WriteDirective("#line hidden");
            }
        }

        private SourceWriter CodeIndent(Chunk chunk)
        {
            if (!this._source.AdjustDebugSymbols)
            {
                return this._source;
            }
            if ((chunk != null) && (chunk.Position != null))
            {
                this._source.StartOfLine = false;
                return this._source.WriteDirective("#line {0} \"{1}\"", new object[] { chunk.Position.Line, chunk.Position.SourceContext.FileName }).Indent(chunk.Position.Column - 1);
            }
            this._source.StartOfLine = false;
            return this._source.WriteLine("#line default");
        }

        private void DeclareVariable(string name)
        {
            this._scope.Variables.Add(name, null);
        }

        private static string EscapeStringContents(string text)
        {
            return text.Replace(@"\", @"\\").Replace("\t", @"\t").Replace("\r", @"\r").Replace("\n", @"\n").Replace("\"", "\\\"");
        }

        private bool IsVariableDeclared(string name)
        {
            for (Scope scope = this._scope; scope != null; scope = scope.Prior)
            {
                if (scope.Variables.ContainsKey(name))
                {
                    return true;
                }
            }
            return false;
        }

        private void PopScope()
        {
            this._scope = this._scope.Prior;
        }

        private void PushScope()
        {
            this._scope = new Scope(this._scope);
        }

        protected override void Visit(AssignVariableChunk chunk)
        {
            this.CodeIndent(chunk).Write(chunk.Name).Write(" = ").WriteCode(chunk.Value).WriteLine(";");
            this.CodeDefault();
        }

        protected override void Visit(CacheChunk chunk)
        {
            Guid guid = Guid.NewGuid();
            this.CodeIndent(chunk).Write("if (BeginCachedContent(\"").Write(guid.ToString("n")).Write("\", new global::Spark.CacheExpires(").WriteCode(chunk.Expires).Write("), ").WriteCode(chunk.Key).WriteLine("))").WriteLine("{").AddIndent();
            this._source.WriteLine("try");
            this.AppendOpenBrace();
            base.Accept(chunk.Body);
            this.AppendCloseBrace();
            this._source.WriteLine("finally").WriteLine("{").AddIndent().Write("EndCachedContent(").WriteCode(chunk.Signal).Write(");").RemoveIndent().WriteLine("}").RemoveIndent().WriteLine("}");
        }

        protected override void Visit(CodeStatementChunk chunk)
        {
            this.CodeIndent(chunk).WriteCode(chunk.Code).WriteLine();
            this.CodeDefault();
        }

        protected override void Visit(ConditionalChunk chunk)
        {
            switch (chunk.Type)
            {
                case ConditionalType.If:
                    this.CodeIndent(chunk).Write("if (").WriteCode(chunk.Condition).WriteLine(")");
                    break;

                case ConditionalType.Else:
                    this._source.WriteLine("else");
                    break;

                case ConditionalType.ElseIf:
                    this.CodeIndent(chunk).Write("else if (").WriteCode(chunk.Condition).WriteLine(")");
                    break;

                case ConditionalType.Once:
                    this.CodeIndent(chunk).Write("if (Once(").WriteCode(chunk.Condition).WriteLine("))");
                    break;

                case ConditionalType.Unless:
                    this.CodeIndent(chunk).Write("if (!(").WriteCode(chunk.Condition).WriteLine("))");
                    break;

                default:
                    throw new CompilerException("Unexpected conditional type " + chunk.Type);
            }
            this.CodeDefault();
            this.AppendOpenBrace();
            base.Accept(chunk.Body);
            this.AppendCloseBrace();
        }

        protected override void Visit(ContentChunk chunk)
        {
            this.CodeIndent(chunk).WriteLine("using(OutputScope(\"{0}\"))", new object[] { chunk.Name });
            this.CodeDefault();
            this.AppendOpenBrace();
            base.Accept(chunk.Body);
            this.AppendCloseBrace();
        }

        protected override void Visit(ContentSetChunk chunk)
        {
            string str;
            this.CodeIndent(chunk).WriteLine("using(OutputScope(new System.IO.StringWriter()))");
            this.CodeDefault();
            this.AppendOpenBrace();
            base.Accept(chunk.Body);
            this.CodeHidden();
            switch (chunk.AddType)
            {
                case ContentAddType.InsertBefore:
                    str = "{0} = Output.ToString() + {0};";
                    break;

                case ContentAddType.AppendAfter:
                    str = "{0} = {0} + Output.ToString();";
                    break;

                default:
                    str = "{0} = Output.ToString();";
                    break;
            }
            this._source.WriteLine(str, new object[] { chunk.Variable });
            this.AppendCloseBrace();
            this.CodeDefault();
        }

        protected override void Visit(DefaultVariableChunk chunk)
        {
            if (!this.IsVariableDeclared(chunk.Name))
            {
                this.DeclareVariable(chunk.Name);
                this.CodeIndent(chunk).WriteCode(chunk.Type).Write(" ").Write(chunk.Name);
                if (!Snippets.IsNullOrEmpty(chunk.Value))
                {
                    this._source.Write(" = ").WriteCode(chunk.Value);
                }
                this._source.WriteLine(";");
                this.CodeDefault();
            }
        }

        protected override void Visit(ExtensionChunk chunk)
        {
            chunk.Extension.VisitChunk(this, OutputLocation.RenderMethod, chunk.Body, this._source.GetStringBuilder());
        }

        protected override void Visit(ForEachChunk chunk)
        {
            List<string> list = chunk.Code.ToString().Split(new char[] { ' ', '\r', '\n', '\t' }).ToList<string>();
            int index = list.IndexOf("in");
            string name = (index < 2) ? null : list[index - 1];
            if (name == null)
            {
                this.CodeIndent(chunk).Write("foreach(").WriteCode(chunk.Code).WriteLine(")");
                this.CodeDefault();
                this.AppendOpenBrace();
                base.Accept(chunk.Body);
                this.AppendCloseBrace();
            }
            else
            {
                DetectCodeExpressionVisitor visitor = new DetectCodeExpressionVisitor(base.OuterPartial);
                DetectCodeExpressionVisitor.Entry entry = visitor.Add(name + "Index");
                DetectCodeExpressionVisitor.Entry entry2 = visitor.Add(name + "Count");
                DetectCodeExpressionVisitor.Entry entry3 = visitor.Add(name + "IsFirst");
                DetectCodeExpressionVisitor.Entry entry4 = visitor.Add(name + "IsLast");
                visitor.Accept(chunk.Body);
                if (entry4.Detected)
                {
                    entry.Detected = true;
                    entry2.Detected = true;
                }
                this.AppendOpenBrace();
                if (entry.Detected)
                {
                    this.DeclareVariable(name + "Index");
                    this._source.WriteLine("int {0}Index = 0;", new object[] { name });
                }
                if (entry3.Detected)
                {
                    this.DeclareVariable(name + "IsFirst");
                    this._source.WriteLine("bool {0}IsFirst = true;", new object[] { name });
                }
                if (entry2.Detected)
                {
                    this.DeclareVariable(name + "Count");
                    string str2 = string.Join(" ", list.ToArray(), index + 1, (list.Count - index) - 1);
                    this._source.WriteLine("int {0}Count = global::Spark.Compiler.CollectionUtility.Count({1});", new object[] { name, str2 });
                }
                this.CodeIndent(chunk).Write("foreach(").WriteCode(chunk.Code).WriteLine(")");
                this.CodeDefault();
                this.AppendOpenBrace();
                this.DeclareVariable(name);
                this.CodeHidden();
                if (entry4.Detected)
                {
                    this.DeclareVariable(name + "IsLast");
                    this._source.WriteLine("bool {0}IsLast = ({0}Index == {0}Count - 1);", new object[] { name });
                }
                this.CodeDefault();
                base.Accept(chunk.Body);
                this.CodeHidden();
                if (entry.Detected)
                {
                    this._source.WriteLine("++{0}Index;", new object[] { name });
                }
                if (entry3.Detected)
                {
                    this._source.WriteLine("{0}IsFirst = false;", new object[] { name });
                }
                this.CodeDefault();
                this.AppendCloseBrace();
                this.AppendCloseBrace();
            }
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
        }

        protected override void Visit(LocalVariableChunk chunk)
        {
            this.DeclareVariable((string) chunk.Name);
            this.CodeIndent(chunk).WriteCode(chunk.Type).Write(" ").WriteCode(chunk.Name);
            if (!Snippets.IsNullOrEmpty(chunk.Value))
            {
                this._source.Write(" = ").WriteCode(chunk.Value);
            }
            this._source.WriteLine(";");
            this.CodeDefault();
        }

        protected override void Visit(MacroChunk chunk)
        {
        }

        protected override void Visit(MarkdownChunk chunk)
        {
            this.CodeIndent(chunk).WriteLine("using(MarkdownOutputScope())");
            this.CodeDefault();
            this.AppendOpenBrace();
            base.Accept(chunk.Body);
            this.AppendCloseBrace();
        }

        protected override void Visit(ScopeChunk chunk)
        {
            this.AppendOpenBrace();
            this.CodeDefault();
            base.Accept(chunk.Body);
            this.AppendCloseBrace();
        }

        protected override void Visit(SendExpressionChunk chunk)
        {
            bool automaticallyEncode = chunk.AutomaticallyEncode;
            if (chunk.Code.ToString().StartsWith("H("))
            {
                automaticallyEncode = false;
            }
            this._source.WriteLine("try").WriteLine("{");
            this.CodeIndent(chunk).Write("Output.Write(").Write(automaticallyEncode ? "H(" : "").WriteCode(chunk.Code).Write(automaticallyEncode ? ")" : "").WriteLine(");");
            this.CodeDefault();
            this._source.WriteLine("}");
            if (this._nullBehaviour == NullBehaviour.Lenient)
            {
                this._source.WriteLine("catch(System.NullReferenceException)");
                this.AppendOpenBrace();
                if (!chunk.SilentNulls)
                {
                    this._source.Write("Output.Write(\"${").Write(EscapeStringContents((string) chunk.Code)).WriteLine("}\");");
                }
                this.AppendCloseBrace();
            }
            else
            {
                this._source.WriteLine("catch(System.NullReferenceException ex)");
                this.AppendOpenBrace();
                this._source.Write("throw new System.ArgumentNullException(\"${").Write(EscapeStringContents((string) chunk.Code)).WriteLine("}\", ex);");
                this.AppendCloseBrace();
            }
        }

        protected override void Visit(SendLiteralChunk chunk)
        {
            if (!string.IsNullOrEmpty(chunk.Text))
            {
                this.CodeHidden();
                this._source.Write("Output.Write(\"").Write(EscapeStringContents(chunk.Text)).WriteLine("\");");
                this.CodeDefault();
            }
        }

        protected override void Visit(UseAssemblyChunk chunk)
        {
        }

        protected override void Visit(UseContentChunk chunk)
        {
            this.CodeIndent(chunk).WriteLine(string.Format("if (Content.ContainsKey(\"{0}\"))", chunk.Name));
            this.CodeHidden();
            this.AppendOpenBrace();
            this._source.WriteFormat("global::Spark.Spool.TextWriterExtensions.WriteTo(Content[\"{0}\"], Output);", new object[] { chunk.Name });
            this.AppendCloseBrace();
            if (chunk.Default.Count != 0)
            {
                this._source.WriteLine("else");
                this.AppendOpenBrace();
                base.Accept(chunk.Default);
                this.AppendCloseBrace();
            }
            this.CodeDefault();
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

        private class Scope
        {
            public Scope(GeneratedCodeVisitor.Scope prior)
            {
                this.Variables = new Dictionary<string, object>();
                this.Prior = prior;
            }

            public GeneratedCodeVisitor.Scope Prior { get; private set; }

            public Dictionary<string, object> Variables { get; set; }
        }
    }
}

