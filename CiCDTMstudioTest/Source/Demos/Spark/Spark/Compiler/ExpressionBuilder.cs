namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExpressionBuilder
    {
        private StringBuilder _literal;
        private readonly IList<string> _parts = new List<string>();

        public void AppendExpression(Snippets code)
        {
            this.Flush();
            this._parts.Add((string) code);
        }

        public void AppendLiteral(string text)
        {
            if (this._literal == null)
            {
                this._literal = new StringBuilder("\"" + EscapeStringContents(text));
            }
            else
            {
                this._literal.Append(EscapeStringContents(text));
            }
        }

        private static string EscapeStringContents(string text)
        {
            return text.Replace(@"\", @"\\").Replace("\t", @"\t").Replace("\r", @"\r").Replace("\n", @"\n").Replace("\"", "\\\"");
        }

        private void Flush()
        {
            if (this._literal != null)
            {
                this._parts.Add(this._literal + "\"");
                this._literal = null;
            }
        }

        public string ToCode()
        {
            this.Flush();
            if (this._parts.Count == 0)
            {
                return "\"\"";
            }
            if (this._parts.Count == 1)
            {
                return this._parts[0];
            }
            return ("string.Concat(" + string.Join(",", this._parts.ToArray<string>()) + ")");
        }
    }
}

