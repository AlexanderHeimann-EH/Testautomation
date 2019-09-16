namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class SourceWriter
    {
        private string _escrow;
        private readonly StringWriter _writer;

        static SourceWriter()
        {
            AdjustDebugSymbolsDefault = true;
        }

        public SourceWriter(StringWriter writer)
        {
            this._writer = writer;
            this.Mappings = new List<SourceMapping>();
            this.AdjustDebugSymbols = AdjustDebugSymbolsDefault;
        }

        public SourceWriter AddIndent()
        {
            this.Indentation += 4;
            return this;
        }

        public SourceWriter ClearEscrowLine()
        {
            this._escrow = null;
            return this;
        }

        public SourceWriter EscrowLine(string value)
        {
            if (this._escrow != null)
            {
                this._writer.Write(this._escrow);
            }
            this._escrow = new string(' ', this.Indentation) + value + this._writer.NewLine;
            return this;
        }

        private void Flush()
        {
            if (this._escrow != null)
            {
                this._writer.Write(this._escrow);
                this._escrow = null;
            }
            this.Indent();
        }

        public StringBuilder GetStringBuilder()
        {
            return this._writer.GetStringBuilder();
        }

        public SourceWriter Indent()
        {
            return this.Indent(this.Indentation);
        }

        public SourceWriter Indent(int size)
        {
            if (this.StartOfLine)
            {
                this._writer.Write(new string(' ', size));
                this.StartOfLine = false;
            }
            return this;
        }

        public SourceWriter RemoveIndent()
        {
            this.Indentation -= 4;
            return this;
        }

        private static bool SnippetAreConnected(Snippet first, Snippet second)
        {
            if ((first.End == null) || (second.Begin == null))
            {
                return false;
            }
            if (first.End.SourceContext != second.Begin.SourceContext)
            {
                return false;
            }
            if (first.End.Offset != second.Begin.Offset)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return this._writer.ToString();
        }

        public SourceWriter Write(IEnumerable<Snippet> value)
        {
            return this.WriteCode(value);
        }

        public SourceWriter Write(string value)
        {
            this.Flush();
            this._writer.Write(value);
            return this;
        }

        public SourceWriter WriteCode(IEnumerable<Snippet> snippets)
        {
            Snippets snippets2 = new Snippets(snippets.Count<Snippet>());
            Snippet first = null;
            foreach (Snippet snippet2 in snippets)
            {
                if ((first != null) && SnippetAreConnected(first, snippet2))
                {
                    first = new Snippet {
                        Value = first.Value + snippet2.Value,
                        Begin = first.Begin,
                        End = snippet2.End
                    };
                }
                else
                {
                    if (first != null)
                    {
                        snippets2.Add(first);
                    }
                    first = snippet2;
                }
            }
            if (first != null)
            {
                snippets2.Add(first);
            }
            foreach (Snippet snippet4 in snippets2)
            {
                if (snippet4.Begin != null)
                {
                    SourceMapping item = new SourceMapping {
                        Source = snippet4,
                        OutputBegin = this.Length,
                        OutputEnd = this.Length + snippet4.Value.Length
                    };
                    this.Mappings.Add(item);
                }
                this.Write(snippet4.Value);
            }
            return this;
        }

        public SourceWriter WriteDirective(string line)
        {
            if (!this.StartOfLine)
            {
                this.WriteLine();
            }
            this.StartOfLine = false;
            return this.WriteLine(line);
        }

        public SourceWriter WriteDirective(string format, params object[] args)
        {
            return this.WriteDirective(string.Format(format, args));
        }

        public SourceWriter WriteFormat(string format, params object[] args)
        {
            return this.Write(string.Format(format, args));
        }

        public SourceWriter WriteLine()
        {
            this.Flush();
            this._writer.WriteLine();
            this.StartOfLine = true;
            return this;
        }

        public SourceWriter WriteLine(string value)
        {
            return this.Write(value).WriteLine();
        }

        public SourceWriter WriteLine(string format, params object[] args)
        {
            return this.WriteLine(string.Format(format, args));
        }

        public bool AdjustDebugSymbols { get; set; }

        public static bool AdjustDebugSymbolsDefault
        {
            [CompilerGenerated]
            get
            {
                return <AdjustDebugSymbolsDefault>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <AdjustDebugSymbolsDefault>k__BackingField = value;
            }
        }

        public int Indentation { get; set; }

        public int Length
        {
            get
            {
                return this._writer.GetStringBuilder().Length;
            }
        }

        public IList<SourceMapping> Mappings { get; set; }

        public bool StartOfLine { get; set; }
    }
}

