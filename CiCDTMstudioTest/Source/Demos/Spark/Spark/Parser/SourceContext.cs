namespace Spark.Parser
{
    using System;
    using System.Runtime.CompilerServices;

    public class SourceContext
    {
        public SourceContext(string content)
        {
            this.Content = content;
        }

        public SourceContext(string content, long lastModified)
        {
            this.Content = content;
            this.LastModified = lastModified;
        }

        public SourceContext(string content, long lastModified, string fileName)
        {
            this.Content = content;
            this.LastModified = lastModified;
            this.FileName = fileName;
        }

        public string Content { get; private set; }

        public string FileName { get; private set; }

        public long LastModified { get; private set; }
    }
}

