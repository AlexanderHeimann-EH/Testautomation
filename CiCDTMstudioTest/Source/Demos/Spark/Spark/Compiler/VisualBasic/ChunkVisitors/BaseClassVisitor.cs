namespace Spark.Compiler.VisualBasic.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Compiler.ChunkVisitors;
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class BaseClassVisitor : ChunkVisitor
    {
        private bool _encounteredBaseClass;
        private bool _encounteredTModel;

        protected override void Visit(PageBaseTypeChunk chunk)
        {
            if (this._encounteredBaseClass && !string.Equals((string) this.BaseClass, (string) chunk.BaseClass, StringComparison.Ordinal))
            {
                throw new CompilerException(string.Format("Only one pageBaseType can be declared. {0} != {1}", this.BaseClass, chunk.BaseClass));
            }
            this.BaseClass = chunk.BaseClass;
            this._encounteredBaseClass = true;
        }

        protected override void Visit(ViewDataModelChunk chunk)
        {
            if (this._encounteredTModel && !string.Equals((string) this.TModel, (string) chunk.TModel, StringComparison.Ordinal))
            {
                throw new CompilerException(string.Format("Only one viewdata model can be declared. {0} != {1}", this.TModel, chunk.TModel));
            }
            this.TModel = chunk.TModel;
            this._encounteredTModel = true;
        }

        public Snippets BaseClass { get; set; }

        public Snippets BaseClassTypeName
        {
            get
            {
                Snippets baseClass = this.BaseClass;
                if (Snippets.IsNullOrEmpty(baseClass))
                {
                    baseClass = "Spark.SparkViewBase";
                }
                if (Snippets.IsNullOrEmpty(this.TModel))
                {
                    return baseClass;
                }
                Snippets snippets2 = new Snippets();
                snippets2.AddRange(baseClass);
                Snippet item = new Snippet {
                    Value = "(Of "
                };
                snippets2.Add(item);
                snippets2.AddRange(this.TModel);
                Snippet snippet2 = new Snippet {
                    Value = ")"
                };
                snippets2.Add(snippet2);
                return snippets2;
            }
        }

        public Snippets TModel { get; set; }
    }
}

