namespace Spark.Compiler
{
    using Spark.Parser;
    using System;
    using System.Runtime.CompilerServices;

    public class CompilerException : SystemException
    {
        public CompilerException(string message) : base(message)
        {
        }

        public CompilerException(string message, Position position) : base(message)
        {
            if (position != null)
            {
                if (position.SourceContext != null)
                {
                    this.Filename = position.SourceContext.FileName;
                }
                this.Line = position.Line;
                this.Column = position.Column;
            }
        }

        public int Column { get; set; }

        public string Filename { get; set; }

        public int Line { get; set; }
    }
}

