namespace Spark.Compiler.VisualBasic.ChunkVisitors
{
    using Spark;
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;

    public class GlobalMembersVisitor : ChunkVisitor
    {
        private readonly Dictionary<string, GlobalVariableChunk> _globalAdded = new Dictionary<string, GlobalVariableChunk>();
        private readonly Dictionary<string, object> _globalSymbols;
        private readonly NullBehaviour _nullBehaviour;
        private readonly SourceWriter _source;
        private readonly Dictionary<string, string> _viewDataAdded = new Dictionary<string, string>();

        public GlobalMembersVisitor(SourceWriter output, Dictionary<string, object> globalSymbols, NullBehaviour nullBehaviour)
        {
            this._source = output;
            this._globalSymbols = globalSymbols;
            this._nullBehaviour = nullBehaviour;
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

        protected override void Visit(ExtensionChunk chunk)
        {
            chunk.Extension.VisitChunk(this, OutputLocation.ClassMembers, chunk.Body, this._source.GetStringBuilder());
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
            if (!this._globalSymbols.ContainsKey((string) chunk.Name))
            {
                this._globalSymbols.Add((string) chunk.Name, null);
            }
            if (this._globalAdded.ContainsKey((string) chunk.Name))
            {
                if ((this._globalAdded[(string) chunk.Name].Type != chunk.Type) || (this._globalAdded[(string) chunk.Name].Value != chunk.Value))
                {
                    throw new CompilerException(string.Format("The global named {0} cannot be declared repeatedly with different types or values", chunk.Name));
                }
            }
            else
            {
                Snippets snippets = chunk.Type ?? "Object";
                this._source.WriteFormat("\r\n    Private _{1} As {0} = {2}\r\n    Public Property {1}() As {0}\r\n        Get\r\n            Return _{1}\r\n        End Get\r\n        Set(ByVal value as {0})\r\n            _{1} = value\r\n        End Set\r\n    End Property", new object[] { snippets, chunk.Name, chunk.Value });
                this._source.WriteLine();
            }
        }

        protected override void Visit(MacroChunk chunk)
        {
            this._source.Write("Public Function ").Write(chunk.Name).Write("(");
            string str = "";
            foreach (MacroParameter parameter in chunk.Parameters)
            {
                this._source.Write(str).Write(parameter.Name).Write(" As ").WriteCode(parameter.Type);
                str = ", ";
            }
            this._source.WriteLine(") As String").AddIndent();
            this._source.WriteLine("Using OutputScope(new Global.System.IO.StringWriter())").AddIndent();
            Dictionary<string, object> globalSymbols = new Dictionary<string, object>();
            foreach (MacroParameter parameter2 in chunk.Parameters)
            {
                globalSymbols.Add(parameter2.Name, null);
            }
            new GeneratedCodeVisitor(this._source, globalSymbols, this._nullBehaviour).Accept(chunk.Body);
            this._source.WriteLine("Return Output.ToString()").RemoveIndent().WriteLine("End Using").RemoveIndent().WriteLine("End Function");
        }

        protected override void Visit(ViewDataChunk chunk)
        {
            string key = chunk.Key;
            Snippets name = chunk.Name;
            Snippets snippets2 = chunk.Type ?? "object";
            if (!this._globalSymbols.ContainsKey((string) name))
            {
                this._globalSymbols.Add((string) name, null);
            }
            if (this._viewDataAdded.ContainsKey((string) name))
            {
                if (this._viewDataAdded[(string) name] != (key + ":" + ((string) snippets2)))
                {
                    throw new CompilerException(string.Format("The view data named {0} cannot be declared with different types '{1}' and '{2}'", name, snippets2, this._viewDataAdded[(string) name]));
                }
            }
            else
            {
                this._viewDataAdded.Add((string) name, key + ":" + ((string) snippets2));
                this._source.Write("Public ReadOnly Property ").WriteCode(name).Write("() As ").WriteCode(snippets2).WriteLine().AddIndent().WriteLine("Get").AddIndent();
                if (Snippets.IsNullOrEmpty(chunk.Default))
                {
                    this.CodeIndent(chunk).Write("Return CType(ViewData.Eval(\"").Write(key).Write("\"),").WriteCode(snippets2).WriteLine(")");
                }
                else
                {
                    this.CodeIndent(chunk).Write("Return CType(If(ViewData.Eval(\"").Write(key).Write("\"),").WriteCode(chunk.Default).Write("),").WriteCode(snippets2).WriteLine(")");
                }
                this._source.RemoveIndent().WriteLine("End Get").RemoveIndent().WriteLine("End Property");
                this.CodeDefault();
            }
        }

        protected override void Visit(ViewDataModelChunk chunk)
        {
            if (!Snippets.IsNullOrEmpty(chunk.TModelAlias))
            {
                this._source.Write("Public ReadOnly Property ").WriteCode(chunk.TModelAlias).Write("() As ").WriteCode(chunk.TModel).WriteLine().AddIndent();
                this._source.WriteLine("Get").AddIndent();
                this._source.WriteLine("Return ViewData.Model");
                this._source.RemoveIndent().WriteLine("End Get");
                this._source.RemoveIndent().WriteLine("End Property");
                this.CodeDefault();
            }
        }
    }
}

