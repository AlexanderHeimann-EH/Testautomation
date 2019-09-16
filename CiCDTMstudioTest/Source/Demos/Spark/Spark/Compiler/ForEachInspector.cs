namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class ForEachInspector
    {
        public ForEachInspector(Snippets code)
        {
            List<string> list = code.ToString().Split(new char[] { ' ', '\r', '\n', '\t' }).ToList<string>();
            int index = list.IndexOf("in");
            if (index >= 1)
            {
                this.Recognized = true;
                this.VariableType = string.Join(" ", list.ToArray(), 0, index - 1);
                this.VariableName = list[index - 1];
                this.CollectionCode = string.Join(" ", list.ToArray(), index + 1, (list.Count - index) - 1);
            }
        }

        public string CollectionCode { get; set; }

        public bool Recognized { get; set; }

        public string VariableName { get; set; }

        public string VariableType { get; set; }
    }
}

