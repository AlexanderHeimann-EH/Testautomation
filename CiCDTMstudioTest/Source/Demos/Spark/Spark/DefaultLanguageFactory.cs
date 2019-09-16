namespace Spark
{
    using Spark.Compiler;
    using Spark.Compiler.CSharp;
    using Spark.Compiler.Javascript;
    using Spark.Compiler.VisualBasic;
    using System;

    public class DefaultLanguageFactory : ISparkLanguageFactory
    {
        public virtual ViewCompiler CreateViewCompiler(ISparkViewEngine engine, SparkViewDescriptor descriptor)
        {
            ViewCompiler compiler;
            string pageBaseType = engine.Settings.PageBaseType;
            if (string.IsNullOrEmpty(pageBaseType))
            {
                pageBaseType = engine.DefaultPageBaseType;
            }
            LanguageType language = descriptor.Language;
            if (language == LanguageType.Default)
            {
                language = engine.Settings.DefaultLanguage;
            }
            switch (language)
            {
                case LanguageType.Default:
                case LanguageType.CSharp:
                    compiler = new CSharpViewCompiler();
                    break;

                case LanguageType.Javascript:
                    compiler = new JavascriptViewCompiler();
                    break;

                case LanguageType.VisualBasic:
                    compiler = new VisualBasicViewCompiler();
                    break;

                default:
                    throw new CompilerException(string.Format("Unknown language type {0}", descriptor.Language));
            }
            compiler.BaseClass = pageBaseType;
            compiler.Descriptor = descriptor;
            compiler.Debug = engine.Settings.Debug;
            compiler.NullBehaviour = engine.Settings.NullBehaviour;
            compiler.UseAssemblies = engine.Settings.UseAssemblies;
            compiler.UseNamespaces = engine.Settings.UseNamespaces;
            return compiler;
        }

        public virtual void InstanceCreated(ViewCompiler compiler, ISparkView view)
        {
        }

        public virtual void InstanceReleased(ViewCompiler compiler, ISparkView view)
        {
        }
    }
}

