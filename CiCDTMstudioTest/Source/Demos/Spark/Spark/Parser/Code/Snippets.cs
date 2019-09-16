namespace Spark.Parser.Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snippets : List<Snippet>
    {
        private static Snippet[] snippetArray;

        public Snippets()
        {
        }

        public Snippets(Snippets collection) : base(collection)
        {
        }

        public Snippets(int capacity) : base(capacity)
        {
        }

        public Snippets(string value) : base(snippetArray)
        {
            Snippet[] snippetArray = new Snippet[1];
            Snippet snippet = new Snippet {
                Value = value
            };
            snippetArray[0] = snippet;
        }

        public Snippets(IEnumerable<Snippet> collection) : base(collection)
        {
        }

        public static bool IsNullOrEmpty(Snippets value)
        {
            if (((value != null) && (value.Count != 0)) && !value.All<Snippet>(s => string.IsNullOrEmpty(s.Value)))
            {
                return false;
            }
            return true;
        }

        public static implicit operator string(Snippets c)
        {
            if (c != null)
            {
                return c.ToString();
            }
            return null;
        }

        public static implicit operator Snippets(string value)
        {
            return new Snippets(value);
        }

        public override string ToString()
        {
            return string.Concat((from s in this select s.Value).ToArray<string>());
        }
    }
}

