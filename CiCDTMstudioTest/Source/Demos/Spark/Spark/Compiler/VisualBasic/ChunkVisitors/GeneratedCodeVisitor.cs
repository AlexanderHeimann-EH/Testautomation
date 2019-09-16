namespace Spark.Compiler.VisualBasic.ChunkVisitors
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

        private void AppendCloseScope()
        {
            this._source.RemoveIndent().WriteLine("End If");
            this.PopScope();
        }

        private void AppendOpenScope()
        {
            this.PushScope();
            this._source.WriteLine("If True Then").AddIndent();
        }

        private void CodeDefault()
        {
            if (this._source.AdjustDebugSymbols)
            {
                this._source.WriteLine("#End ExternalSource");
            }
        }

        private void CodeHidden()
        {
            if (this._source.AdjustDebugSymbols)
            {
                this._source.WriteLine("#ExternalSource(\"\", 16707566)");
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
                return this._source.WriteDirective("#ExternalSource(\"{1}\",  {0})", new object[] { chunk.Position.Line, chunk.Position.SourceContext.FileName }).Indent(chunk.Position.Column - 1);
            }
            return this._source.WriteDirective("#ExternalSource(\"\", 16707566)");
        }

        private void DeclareVariable(string name)
        {
            this._scope.Variables.Add(name, null);
        }

        private static string EscapeStringContents(string text)
        {
            return text.Replace("\"", "[\"]").Replace("\t", "\" & vbTab & \"").Replace("\r\n", "\" & vbCrLf & \"").Replace("\r", "\" & vbCr & \"").Replace("\n", "\" & vbLf & \"").Replace(" & \"\"", "").Replace("[\"]", "\"\"");
        }

        private static bool IsIn(string part)
        {
            return string.Equals(part, "In", StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool IsInOrAs(string part)
        {
            if (!string.Equals(part, "In", StringComparison.InvariantCultureIgnoreCase))
            {
                return string.Equals(part, "As", StringComparison.InvariantCultureIgnoreCase);
            }
            return true;
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

        private void LocalVariableImpl(Chunk chunk, Snippets name, Snippets type, Snippets value)
        {
            this.DeclareVariable((string) name);
            if (Snippets.IsNullOrEmpty(type) || string.Equals((string) type, "var"))
            {
                this.CodeIndent(chunk).Write("Dim ").WriteCode(name);
            }
            else
            {
                this.CodeIndent(chunk).Write("Dim ").WriteCode(name).Write(" As ").WriteCode(type);
            }
            if (!Snippets.IsNullOrEmpty(value))
            {
                this._source.Write(" = ").WriteCode(value);
            }
            this._source.WriteLine();
            this.CodeDefault();
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
            this.CodeIndent(chunk).Write(chunk.Name).Write(" = ").WriteLine((string) chunk.Value);
            this.CodeDefault();
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
                    this.CodeIndent(chunk).Write("If ").WriteCode(chunk.Condition).WriteLine(" Then");
                    break;

                case ConditionalType.Else:
                    this._source.ClearEscrowLine();
                    this._source.WriteLine("Else");
                    break;

                case ConditionalType.ElseIf:
                    this._source.ClearEscrowLine();
                    this.CodeIndent(chunk).Write("ElseIf ").WriteCode(chunk.Condition).WriteLine(" Then");
                    break;

                case ConditionalType.Once:
                    this._source.Write("If Once(").WriteCode(chunk.Condition).WriteLine(") Then");
                    break;

                case ConditionalType.Unless:
                    this.CodeIndent(chunk).Write("If Not ").WriteCode(chunk.Condition).WriteLine(" Then");
                    break;

                default:
                    throw new CompilerException(string.Format("Unknown ConditionalChunk type {0}", chunk.Type));
            }
            this._source.AddIndent();
            this.PushScope();
            base.Accept(chunk.Body);
            this.PopScope();
            this._source.RemoveIndent().EscrowLine("End If");
        }

        protected override void Visit(ContentChunk chunk)
        {
            this.CodeIndent(chunk).Write("Using OutputScope(\"").Write(chunk.Name).WriteLine("\")").AddIndent();
            this.PushScope();
            base.Accept(chunk.Body);
            this.PopScope();
            this._source.RemoveIndent().WriteLine("End Using");
        }

        protected override void Visit(ContentSetChunk chunk)
        {
            string str;
            this.CodeIndent(chunk).WriteLine("Using OutputScope(new System.IO.StringWriter())").AddIndent();
            this.CodeDefault();
            this.PushScope();
            base.Accept(chunk.Body);
            this.CodeHidden();
            switch (chunk.AddType)
            {
                case ContentAddType.InsertBefore:
                    str = "{0} = Output.ToString() + {0}";
                    break;

                case ContentAddType.AppendAfter:
                    str = "{0} = {0} + Output.ToString()";
                    break;

                default:
                    str = "{0} = Output.ToString()";
                    break;
            }
            this._source.WriteFormat(str, new object[] { chunk.Variable }).WriteLine();
            this.PopScope();
            this._source.RemoveIndent().WriteLine("End Using");
            this.CodeDefault();
        }

        protected override void Visit(DefaultVariableChunk chunk)
        {
            if (!this.IsVariableDeclared(chunk.Name))
            {
                this.LocalVariableImpl(chunk, chunk.Name, chunk.Type, chunk.Value);
            }
        }

        protected override void Visit(ExtensionChunk chunk)
        {
            chunk.Extension.VisitChunk(this, OutputLocation.RenderMethod, chunk.Body, this._source.GetStringBuilder());
        }

        protected override void Visit(ForEachChunk chunk)
        {
            List<string> list = chunk.Code.ToString().Split(new char[] { ' ', '\r', '\n', '\t' }).ToList<string>();
            int num = list.FindIndex(new Predicate<string>(GeneratedCodeVisitor.IsIn));
            int num2 = list.FindIndex(new Predicate<string>(GeneratedCodeVisitor.IsInOrAs));
            string name = (num2 < 1) ? null : list[num2 - 1];
            if (name == null)
            {
                this.CodeIndent(chunk).Write("For Each ").WriteLine((string) chunk.Code).AddIndent();
                this.CodeDefault();
                this.PushScope();
                base.Accept(chunk.Body);
                this._source.RemoveIndent().WriteLine("Next");
                this.PopScope();
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
                this.AppendOpenScope();
                if (entry.Detected)
                {
                    this.DeclareVariable(name + "Index");
                    this._source.WriteLine("Dim {0}Index As Integer = 0", new object[] { name });
                }
                if (entry3.Detected)
                {
                    this.DeclareVariable(name + "IsFirst");
                    this._source.WriteLine("Dim {0}IsFirst As Boolean = True", new object[] { name });
                }
                if (entry2.Detected)
                {
                    this.DeclareVariable(name + "Count");
                    string str2 = string.Join(" ", list.ToArray(), num + 1, (list.Count - num) - 1);
                    this._source.WriteLine("Dim {0}Count As Integer = Global.Spark.Compiler.CollectionUtility.Count({1})", new object[] { name, str2 });
                }
                this.CodeIndent(chunk).Write("For Each ").WriteLine((string) chunk.Code).AddIndent();
                this.CodeDefault();
                this.PushScope();
                this.DeclareVariable(name);
                this.CodeHidden();
                if (entry4.Detected)
                {
                    this.DeclareVariable(name + "IsLast");
                    this._source.WriteLine("Dim {0}IsLast As Boolean = ({0}Index = {0}Count - 1)", new object[] { name });
                }
                this.CodeDefault();
                base.Accept(chunk.Body);
                this.CodeHidden();
                if (entry.Detected)
                {
                    this._source.WriteLine("{0}Index = {0}Index + 1", new object[] { name });
                }
                if (entry3.Detected)
                {
                    this._source.WriteLine("{0}IsFirst = False", new object[] { name });
                }
                this.CodeDefault();
                this.PopScope();
                this._source.RemoveIndent().WriteLine("Next");
                this.AppendCloseScope();
            }
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
        }

        protected override void Visit(LocalVariableChunk chunk)
        {
            this.LocalVariableImpl(chunk, chunk.Name, chunk.Type, chunk.Value);
        }

        protected override void Visit(MacroChunk chunk)
        {
        }

        protected override void Visit(PageBaseTypeChunk chunk)
        {
        }

        protected override void Visit(ScopeChunk chunk)
        {
            this.AppendOpenScope();
            base.Accept(chunk.Body);
            this.AppendCloseScope();
        }

        protected override void Visit(SendExpressionChunk chunk)
        {
            bool automaticallyEncode = chunk.AutomaticallyEncode;
            if (chunk.Code.ToString().StartsWith("H("))
            {
                automaticallyEncode = false;
            }
            this._source.WriteLine("Try").AddIndent();
            this.CodeIndent(chunk).Write("Output.Write(").Write(automaticallyEncode ? "H(" : "").WriteCode(chunk.Code).Write(automaticallyEncode ? ")" : "").WriteLine(")").RemoveIndent();
            this.CodeDefault();
            if (this._nullBehaviour == NullBehaviour.Lenient)
            {
                this._source.WriteLine("Catch ex As Global.System.NullReferenceException");
                if (!chunk.SilentNulls)
                {
                    this._source.AddIndent().Write("Output.Write(\"${").Write(EscapeStringContents((string) chunk.Code)).WriteLine("}\")").RemoveIndent();
                }
                this._source.WriteLine("End Try");
            }
            else
            {
                this._source.WriteLine("Catch ex As Global.System.NullReferenceException");
                this._source.AddIndent().Write("Throw New Global.System.ArgumentNullException(\"${").Write(EscapeStringContents((string) chunk.Code)).WriteLine("}\", ex)").RemoveIndent();
                this._source.WriteLine("End Try");
            }
        }

        protected override void Visit(SendLiteralChunk chunk)
        {
            if (!string.IsNullOrEmpty(chunk.Text))
            {
                this.CodeHidden();
                this._source.Write("Output.Write(\"").Write(EscapeStringContents(chunk.Text)).WriteLine("\")");
                this.CodeDefault();
            }
        }

        protected override void Visit(UseAssemblyChunk chunk)
        {
        }

        protected override void Visit(UseContentChunk chunk)
        {
            this.CodeIndent(chunk).Write("If Content.ContainsKey(\"").Write(chunk.Name).WriteLine("\") Then").AddIndent().Write("Global.Spark.Spool.TextWriterExtensions.WriteTo(Content(\"").Write(chunk.Name).WriteLine("\"), Output)").RemoveIndent();
            if (chunk.Default.Any<Chunk>())
            {
                this._source.WriteLine("Else").AddIndent();
                this.PushScope();
                base.Accept(chunk.Default);
                this.PopScope();
                this._source.RemoveIndent();
            }
            this._source.WriteLine("End If");
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

