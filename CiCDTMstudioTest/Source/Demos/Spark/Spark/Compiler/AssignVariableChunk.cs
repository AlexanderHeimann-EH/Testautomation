namespace Spark.Compiler
{
    using Spark.Parser.Code;
    using System;
    using System.Runtime.CompilerServices;

    public class AssignVariableChunk : Chunk
    {
        public string Name { get; set; }

        public Snippets Value { get; set; }
    }
}

