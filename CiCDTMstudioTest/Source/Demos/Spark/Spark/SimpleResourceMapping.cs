namespace Spark
{
    using System;
    using System.Runtime.CompilerServices;

    public class SimpleResourceMapping : IResourceMapping
    {
        public bool IsMatch(string path)
        {
            return path.StartsWith(this.Match, StringComparison.InvariantCultureIgnoreCase);
        }

        public string Map(string path)
        {
            return (this.Location + path.Substring(this.Match.Length));
        }

        public string Location { get; set; }

        public string Match { get; set; }

        public bool Stop { get; set; }
    }
}

