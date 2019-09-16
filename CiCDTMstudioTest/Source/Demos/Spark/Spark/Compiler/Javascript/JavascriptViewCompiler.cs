namespace Spark.Compiler.Javascript
{
    using Spark.Compiler;
    using Spark.Compiler.Javascript.ChunkVisitors;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class JavascriptViewCompiler : ViewCompiler
    {
        public override void CompileView(IEnumerable<IList<Chunk>> viewTemplates, IEnumerable<IList<Chunk>> allResources)
        {
            this.GenerateSourceCode(viewTemplates, allResources);
        }

        public override void GenerateSourceCode(IEnumerable<IList<Chunk>> viewTemplates, IEnumerable<IList<Chunk>> allResources)
        {
            StringBuilder source = new StringBuilder();
            JavascriptAnonymousTypeVisitor visitor = new JavascriptAnonymousTypeVisitor();
            JavascriptGlobalMembersVisitor visitor2 = new JavascriptGlobalMembersVisitor(source);
            JavascriptPreRenderVisitor visitor3 = new JavascriptPreRenderVisitor(source);
            JavascriptGeneratedCodeVisitor visitor4 = new JavascriptGeneratedCodeVisitor(source);
            JavascriptPostRenderVisitor visitor5 = new JavascriptPostRenderVisitor(source);
            string str = base.Descriptor.Templates[0];
            IEnumerable<string> enumerable = str.Split(new char[] { Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Select<string, string>(new Func<string, string>(JavascriptViewCompiler.SafeName));
            foreach (IList<Chunk> list in viewTemplates)
            {
                visitor.Accept(list);
            }
            string str2 = "window.Spark";
            foreach (string str3 in from p in enumerable
                where p != "~"
                select p)
            {
                source.Append("if (!").Append(str2).Append(") ").Append(str2).AppendLine(" = {};");
                str2 = str2 + "." + str3;
            }
            source.Append(str2).AppendLine(" = {");
            foreach (IList<Chunk> list2 in allResources)
            {
                visitor2.Accept(list2);
            }
            source.AppendLine("RenderView: function(viewData) {");
            source.Append("var StringWriter = function() {");
            source.Append("this._parts = [];");
            source.Append("this.Write = function(arg) {if(arg !== null){this._parts.push(arg.toString());}};");
            source.Append("this.toString = function() {return this._parts.join('');};");
            source.AppendLine("};");
            source.AppendLine("var Output = new StringWriter();");
            source.AppendLine("var Content = {};");
            source.Append("function OutputScope(arg) {");
            source.Append("if (typeof arg == 'string') {if (!Content[arg]) Content[arg] = new StringWriter(); arg = Content[arg];}");
            source.Append("OutputScope._frame = {_frame:OutputScope.Frame, _output:Output};");
            source.Append("Output = arg;");
            source.AppendLine("};");
            source.Append("function DisposeOutputScope() {");
            source.Append("Output = OutputScope._frame._output;");
            source.Append("OutputScope._frame = OutputScope._frame._frame;");
            source.AppendLine("};");
            foreach (IList<Chunk> list3 in allResources)
            {
                visitor3.Accept(list3);
            }
            int num = 0;
            foreach (IList<Chunk> list4 in viewTemplates)
            {
                source.Append("function RenderViewLevel").Append(num).AppendLine("() {");
                visitor4.Accept(list4);
                source.AppendLine("}");
                num++;
            }
            source.AppendLine("RenderViewLevel0();");
            foreach (IList<Chunk> list5 in allResources)
            {
                visitor5.Accept(list5);
            }
            source.AppendLine("return Output.toString();");
            source.AppendLine("} // function RenderView");
            source.Append("} // ").AppendLine(str2);
            base.SourceCode = source.ToString();
        }

        private static string SafeName(string name)
        {
            string str = name;
            if (str.EndsWith(".spark"))
            {
                str = str.Substring(0, str.Length - ".spark".Length);
            }
            return str.Replace(".", "");
        }
    }
}

