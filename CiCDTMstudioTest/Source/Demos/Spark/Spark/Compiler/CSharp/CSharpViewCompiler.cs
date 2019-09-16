namespace Spark.Compiler.CSharp
{
    using Spark;
    using Spark.Compiler;
    using Spark.Compiler.CSharp.ChunkVisitors;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class CSharpViewCompiler : ViewCompiler
    {
        public override void CompileView(IEnumerable<IList<Chunk>> viewTemplates, IEnumerable<IList<Chunk>> allResources)
        {
            this.GenerateSourceCode(viewTemplates, allResources);
            Assembly assembly = new BatchCompiler().Compile(base.Debug, "csharp", new string[] { base.SourceCode });
            base.CompiledType = assembly.GetType(base.ViewClassFullName);
        }

        private static void EditorBrowsableStateNever(SourceWriter source, int indentation)
        {
            source.Indent(indentation).WriteLine("[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]");
        }

        public override void GenerateSourceCode(IEnumerable<IList<Chunk>> viewTemplates, IEnumerable<IList<Chunk>> allResources)
        {
            Dictionary<string, object> globalSymbols = new Dictionary<string, object>();
            StringWriter writer = new StringWriter();
            SourceWriter output = new SourceWriter(writer);
            UsingNamespaceVisitor visitor = new UsingNamespaceVisitor(output);
            BaseClassVisitor visitor2 = new BaseClassVisitor {
                BaseClass = base.BaseClass
            };
            GlobalMembersVisitor visitor3 = new GlobalMembersVisitor(output, globalSymbols, base.NullBehaviour);
            foreach (string str in base.UseNamespaces ?? ((IEnumerable<string>) new string[0]))
            {
                visitor.UsingNamespace(str);
            }
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
                output.WriteLine().WriteLine(string.Format("namespace {0}", base.TargetNamespace)).WriteLine("{").AddIndent();
            }
            output.WriteLine();
            if (base.Descriptor != null)
            {
                output.WriteLine("[global::Spark.SparkViewAttribute(");
                if (base.TargetNamespace != null)
                {
                    output.WriteFormat("    TargetNamespace=\"{0}\",", new object[] { base.TargetNamespace }).WriteLine();
                }
                output.WriteLine("    Templates = new string[] {");
                output.Write("      ").WriteLine(string.Join(",\r\n      ", (from t in base.Descriptor.Templates select "\"" + SparkViewAttribute.ConvertToAttributeFormat(t) + "\"").ToArray<string>()));
                output.WriteLine("    })]");
            }
            output.Write("public class ").Write(str3).Write(" : ").WriteCode(visitor2.BaseClassTypeName).WriteLine();
            output.WriteLine("{").AddIndent();
            output.WriteLine();
            EditorBrowsableStateNever(output, 4);
            output.WriteLine("private static System.Guid _generatedViewId = new System.Guid(\"{0:n}\");", new object[] { base.GeneratedViewId });
            output.WriteLine("public override System.Guid GeneratedViewId");
            output.WriteLine("{ get { return _generatedViewId; } }");
            if ((base.Descriptor != null) && (base.Descriptor.Accessors != null))
            {
                foreach (SparkViewDescriptor.Accessor accessor in base.Descriptor.Accessors)
                {
                    output.WriteLine();
                    output.Write("public ").WriteLine(accessor.Property);
                    output.Write("{ get { return ").Write(accessor.GetValue).WriteLine("; } }");
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
                output.WriteLine(string.Format("private void RenderViewLevel{0}()", num));
                output.WriteLine("{").AddIndent();
                new GeneratedCodeVisitor(output, globalSymbols, base.NullBehaviour).Accept(list4);
                output.RemoveIndent().WriteLine("}");
                num++;
            }
            output.WriteLine();
            EditorBrowsableStateNever(output, 4);
            output.WriteLine("public override void Render()");
            output.WriteLine("{").AddIndent();
            for (int i = 0; i != num; i++)
            {
                if (i != (num - 1))
                {
                    output.WriteLine("using (OutputScope()) {{RenderViewLevel{0}(); Content[\"view\"] = Output;}}", new object[] { i });
                }
                else
                {
                    output.WriteLine("        RenderViewLevel{0}();", new object[] { i });
                }
            }
            output.RemoveIndent().WriteLine("}");
            output.RemoveIndent().WriteLine("}");
            if (!string.IsNullOrEmpty(base.TargetNamespace))
            {
                output.RemoveIndent().WriteLine("}");
            }
            base.SourceCode = output.ToString();
            base.SourceMappings = output.Mappings;
        }
    }
}

