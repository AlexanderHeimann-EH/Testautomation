namespace Spark.Compiler.VisualBasic
{
    using Spark;
    using Spark.Compiler;
    using Spark.Compiler.VisualBasic.ChunkVisitors;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class VisualBasicViewCompiler : ViewCompiler
    {
        public override void CompileView(IEnumerable<IList<Chunk>> viewTemplates, IEnumerable<IList<Chunk>> allResources)
        {
            this.GenerateSourceCode(viewTemplates, allResources);
            Assembly assembly = new BatchCompiler().Compile(base.Debug, "visualbasic", new string[] { base.SourceCode });
            base.CompiledType = assembly.GetType(base.ViewClassFullName);
        }

        private static void EditorBrowsableStateNever(SourceWriter source, int indentation)
        {
            source.Indent(indentation).WriteLine("<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _");
        }

        public override void GenerateSourceCode(IEnumerable<IList<Chunk>> viewTemplates, IEnumerable<IList<Chunk>> allResources)
        {
            Dictionary<string, object> globalSymbols = new Dictionary<string, object>();
            StringWriter writer = new StringWriter();
            SourceWriter output = new SourceWriter(writer) {
                AdjustDebugSymbols = false
            };
            UsingNamespaceVisitor visitor = new UsingNamespaceVisitor(output);
            BaseClassVisitor visitor2 = new BaseClassVisitor {
                BaseClass = base.BaseClass
            };
            GlobalMembersVisitor visitor3 = new GlobalMembersVisitor(output, globalSymbols, base.NullBehaviour);
            output.WriteLine("Option Infer On");
            visitor.UsingNamespace("Microsoft.VisualBasic");
            foreach (string str in base.UseNamespaces ?? ((IEnumerable<string>) new string[0]))
            {
                visitor.UsingNamespace(str);
            }
            visitor.UsingAssembly("Microsoft.VisualBasic, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            foreach (string str2 in base.UseAssemblies ?? ((IEnumerable<string>) new string[0]))
            {
                visitor.UsingAssembly(str2);
            }
            foreach (IList<Chunk> list in allResources)
            {
                visitor.Accept(list);
            }
            foreach (IList<Chunk> list2 in allResources)
            {
                visitor2.Accept(list2);
            }
            string str3 = "View" + base.GeneratedViewId.ToString("n");
            if (string.IsNullOrEmpty(base.TargetNamespace))
            {
                base.ViewClassFullName = str3;
            }
            else
            {
                base.ViewClassFullName = base.TargetNamespace + "." + str3;
                output.WriteLine();
                output.WriteLine(string.Format("Namespace {0}", base.TargetNamespace));
            }
            output.WriteLine();
            if (base.Descriptor != null)
            {
                output.WriteLine("<Global.Spark.SparkViewAttribute( _");
                if (base.TargetNamespace != null)
                {
                    output.WriteFormat("    TargetNamespace:=\"{0}\", _", new object[] { base.TargetNamespace }).WriteLine();
                }
                output.WriteLine("    Templates := New String() { _");
                output.Write("      ").Write(string.Join(", _\r\n      ", (from t in base.Descriptor.Templates select "\"" + SparkViewAttribute.ConvertToAttributeFormat(t) + "\"").ToArray<string>()));
                output.WriteLine("    })> _");
            }
            output.Write("Public Class ").WriteLine(str3).Write("    Inherits ").WriteLine((string) visitor2.BaseClassTypeName).AddIndent();
            output.WriteLine();
            output.WriteLine(string.Format("    Private Shared ReadOnly _generatedViewId As Global.System.Guid = New Global.System.Guid(\"{0:n}\")", base.GeneratedViewId));
            output.WriteLine("    Public Overrides ReadOnly Property GeneratedViewId() As Global.System.Guid").WriteLine("      Get").WriteLine("        Return _generatedViewId").WriteLine("      End Get").WriteLine("    End Property");
            if ((base.Descriptor != null) && (base.Descriptor.Accessors != null))
            {
                foreach (SparkViewDescriptor.Accessor accessor in base.Descriptor.Accessors)
                {
                    output.WriteLine();
                    output.Write("    public ").WriteLine(accessor.Property);
                    output.Write("    { get { return ").Write(accessor.GetValue).WriteLine("; } }");
                }
            }
            foreach (IList<Chunk> list3 in allResources)
            {
                visitor3.Accept(list3);
            }
            int num = 0;
            foreach (IList<Chunk> list4 in viewTemplates)
            {
                output.WriteLine();
                EditorBrowsableStateNever(output, 4);
                output.WriteLine("Private Sub RenderViewLevel{0}()", new object[] { num }).AddIndent();
                new GeneratedCodeVisitor(output, globalSymbols, base.NullBehaviour).Accept(list4);
                output.RemoveIndent().WriteLine("End Sub");
                num++;
            }
            output.WriteLine();
            EditorBrowsableStateNever(output, 4);
            output.WriteLine("Public Overrides Sub Render()").AddIndent();
            for (int i = 0; i != num; i++)
            {
                if (i != (num - 1))
                {
                    output.WriteLine("Using OutputScope()").AddIndent().WriteLine("RenderViewLevel{0}()", new object[] { i }).WriteLine("Content(\"view\") = Output").RemoveIndent().WriteLine("End Using");
                }
                else
                {
                    output.WriteLine("RenderViewLevel{0}()", new object[] { i });
                }
            }
            output.RemoveIndent().WriteLine("End Sub");
            output.RemoveIndent().WriteLine("End Class");
            if (!string.IsNullOrEmpty(base.TargetNamespace))
            {
                output.WriteLine("End Namespace");
            }
            base.SourceCode = output.ToString();
            base.SourceMappings = output.Mappings;
        }
    }
}

