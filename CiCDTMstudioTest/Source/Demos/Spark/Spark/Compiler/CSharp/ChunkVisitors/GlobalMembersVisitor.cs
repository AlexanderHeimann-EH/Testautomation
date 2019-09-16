namespace Spark.Compiler.CSharp.ChunkVisitors
{
    using Spark;
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
                Snippets snippets = chunk.Type ?? "object";
                string[] source = snippets.ToString().Split(new char[] { ' ', '\t' });
                if (source.Contains<string>("const") || source.Contains<string>("readonly"))
                {
                    this._source.WriteFormat("\r\n    {0} {1} = {2};", new object[] { snippets, chunk.Name, chunk.Value });
                }
                else
                {
                    this._source.WriteFormat("\r\n    {0} _{1} = {2};\r\n    public {0} {1} {{ get {{return _{1};}} set {{_{1} = value;}} }}", new object[] { snippets, chunk.Name, chunk.Value });
                }
                this._source.WriteLine();
            }
        }

        protected override void Visit(MacroChunk chunk)
        {
            this._source.Write(string.Format("\r\n    object {0}(", chunk.Name));
            string str = "";
            foreach (MacroParameter parameter in chunk.Parameters)
            {
                this._source.Write(str).WriteCode(parameter.Type).Write(" ").Write(parameter.Name);
                str = ", ";
            }
            this._source.WriteLine(")");
            this.CodeIndent(chunk).WriteLine("{");
            this.CodeHidden();
            this._source.WriteLine("        using(OutputScope(new System.IO.StringWriter()))");
            this._source.WriteLine("        {");
            this.CodeDefault();
            Dictionary<string, object> globalSymbols = new Dictionary<string, object>();
            foreach (MacroParameter parameter2 in chunk.Parameters)
            {
                globalSymbols.Add(parameter2.Name, null);
            }
            new GeneratedCodeVisitor(this._source, globalSymbols, this._nullBehaviour).Accept(chunk.Body);
            this.CodeHidden();
            this._source.WriteLine("            return HTML(Output);");
            this._source.WriteLine("        }");
            this._source.WriteLine("    }");
            this.CodeDefault();
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
                this._source.WriteCode(snippets2).Write(" ").WriteLine((string) name);
                if (Snippets.IsNullOrEmpty(chunk.Default))
                {
                    this.CodeIndent(chunk).Write("{get {return (").WriteCode(snippets2).Write(")ViewData.Eval(\"").Write(key).WriteLine("\");}}");
                }
                else
                {
                    this.CodeIndent(chunk).Write("{get {return (").WriteCode(snippets2).Write(")(ViewData.Eval(\"").Write(key).Write("\")??").WriteCode(chunk.Default).WriteLine(");}}");
                }
                this.CodeDefault();
            }
        }

        protected override void Visit(ViewDataModelChunk chunk)
        {
            if (!Snippets.IsNullOrEmpty(chunk.TModelAlias))
            {
                this._source.WriteCode(chunk.TModel).Write(" ").WriteCode(chunk.TModelAlias).WriteLine();
                this.CodeIndent(chunk).WriteLine("{get {return ViewData.Model;}}");
                this.CodeDefault();
            }
        }
    }
}

