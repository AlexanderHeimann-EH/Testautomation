namespace Spark.Compiler.ChunkVisitors
{
    using Spark.Compiler;
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class DetectCodeExpressionVisitor : AbstractChunkVisitor
    {
        private readonly IList<Entry> _entries = new List<Entry>();

        public DetectCodeExpressionVisitor(RenderPartialChunk currentPartial)
        {
            if (currentPartial != null)
            {
                base.EnterRenderPartial(currentPartial);
            }
        }

        public Entry Add(string expression)
        {
            Entry item = new Entry {
                Expression = expression
            };
            this._entries.Add(item);
            return item;
        }

        private void Examine(Snippets code)
        {
            if (!Snippets.IsNullOrEmpty(code))
            {
                string str = code.ToString();
                foreach (Entry entry in this._entries)
                {
                    if (!entry.Detected && str.Contains(entry.Expression))
                    {
                        entry.Detected = true;
                    }
                }
            }
        }

        protected override void Visit(AssignVariableChunk chunk)
        {
            this.Examine(chunk.Value);
        }

        protected override void Visit(CacheChunk chunk)
        {
            this.Examine(chunk.Key);
            this.Examine(chunk.Expires);
            base.Accept(chunk.Body);
        }

        protected override void Visit(CodeStatementChunk chunk)
        {
            this.Examine(chunk.Code);
        }

        protected override void Visit(ConditionalChunk chunk)
        {
            if (!Snippets.IsNullOrEmpty(chunk.Condition))
            {
                this.Examine(chunk.Condition);
            }
            base.Accept(chunk.Body);
        }

        protected override void Visit(ContentChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(ContentSetChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(DefaultVariableChunk chunk)
        {
            this.Examine(chunk.Value);
        }

        protected override void Visit(ExtensionChunk chunk)
        {
        }

        protected override void Visit(ForEachChunk chunk)
        {
            this.Examine(chunk.Code);
            base.Accept(chunk.Body);
        }

        protected override void Visit(GlobalVariableChunk chunk)
        {
        }

        protected override void Visit(LocalVariableChunk chunk)
        {
            this.Examine(chunk.Value);
        }

        protected override void Visit(MacroChunk chunk)
        {
        }

        protected override void Visit(MarkdownChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(PageBaseTypeChunk chunk)
        {
        }

        protected override void Visit(RenderPartialChunk chunk)
        {
            base.EnterRenderPartial(chunk);
            base.Accept(chunk.FileContext.Contents);
            base.ExitRenderPartial(chunk);
        }

        protected override void Visit(RenderSectionChunk chunk)
        {
            RenderPartialChunk chunk2 = base.ExitRenderPartial();
            if (string.IsNullOrEmpty(chunk.Name))
            {
                base.Accept(chunk2.Body);
            }
            else if (chunk2.Sections.ContainsKey(chunk.Name))
            {
                base.Accept(chunk2.Sections[chunk.Name]);
            }
            else
            {
                base.EnterRenderPartial(chunk2);
                base.Accept(chunk.Default);
                base.ExitRenderPartial(chunk2);
            }
            base.EnterRenderPartial(chunk2);
        }

        protected override void Visit(ScopeChunk chunk)
        {
            base.Accept(chunk.Body);
        }

        protected override void Visit(SendExpressionChunk chunk)
        {
            this.Examine(chunk.Code);
        }

        protected override void Visit(SendLiteralChunk chunk)
        {
        }

        protected override void Visit(UseAssemblyChunk chunk)
        {
        }

        protected override void Visit(UseContentChunk chunk)
        {
            base.Accept(chunk.Default);
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

        public class Entry
        {
            public bool Detected { get; set; }

            public string Expression { get; set; }
        }
    }
}

