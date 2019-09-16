using Spark.Parser.Markup;

namespace Spark.Parser.Syntax
{
    using Spark;
    using Spark.Compiler;
    using Spark.Compiler.NodeVisitors;
    using Spark.FileSystem;
    using Spark.Parser;
    using Spark.Parser.Code;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public abstract class AbstractSyntaxProvider : ISparkSyntaxProvider
    {
        protected AbstractSyntaxProvider()
        {
        }

        public static SourceContext CreateSourceContext(string viewPath, IViewFolder viewFolder)
        {
            SourceContext context;
            IViewFile viewSource = viewFolder.GetViewSource(viewPath);
            if (viewSource == null)
            {
                throw new FileNotFoundException("View file not found", viewPath);
            }
            using (Stream stream = viewSource.OpenViewStream())
            {
                string fileName = viewPath;
                if (stream is FileStream)
                {
                    fileName = ((FileStream) stream).Name;
                }
                using (TextReader reader = new StreamReader(stream))
                {
                    context = new SourceContext(reader.ReadToEnd(), viewSource.LastModified, fileName);
                }
            }
            return context;
        }

        public abstract IList<Chunk> GetChunks(VisitorContext context, string path);
        public abstract IList<Node> IncludeFile(VisitorContext context, string path, string parse);
        public abstract Snippets ParseFragment(Position begin, Position end);
        protected void ThrowParseException(string viewPath, Position position, Position rest)
        {
            string str = string.Format("Unable to parse view {0} around line {1} column {2}", viewPath, rest.Line, rest.Column);
            int count = Math.Min(30, rest.Offset);
            int num2 = Math.Min(30, rest.PotentialLength());
            string str2 = position.Advance(rest.Offset - count).Peek(count);
            string str3 = rest.Peek(num2);
            throw new CompilerException(str + Environment.NewLine + str2 + "[error:]" + str3);
        }
    }
}

