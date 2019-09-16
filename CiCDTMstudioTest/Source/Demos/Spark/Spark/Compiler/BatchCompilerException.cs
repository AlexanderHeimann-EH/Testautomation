namespace Spark.Compiler
{
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    public class BatchCompilerException : CompilerException
    {
        public BatchCompilerException(string message, CompilerResults results) : base(message)
        {
            this.Results = results;
        }

        public CompilerResults Results { get; set; }
    }
}

