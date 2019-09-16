namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Code;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class TypeInspector
    {
        public TypeInspector(Snippets dataDeclaration)
        {
            string str = dataDeclaration.ToString().Trim();
            int length = str.LastIndexOfAny(new char[] { ' ', '\t', '\r', '\n' });
            if (length < 0)
            {
                this.Type = dataDeclaration;
            }
            else
            {
                this.Name = str.Substring(length + 1);
                if (!this.Name.ToString().ToCharArray().All<char>(delegate (char ch) {
                    if (!char.IsLetterOrDigit(ch) && (ch != '_'))
                    {
                        return (ch == '@');
                    }
                    return true;
                }))
                {
                    this.Name = null;
                    this.Type = dataDeclaration;
                }
                else
                {
                    this.Type = str.Substring(0, length).Trim();
                }
            }
        }

        public Snippets Name { get; set; }

        public Snippets Type { get; set; }
    }
}

