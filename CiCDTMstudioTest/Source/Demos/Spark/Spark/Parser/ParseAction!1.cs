namespace Spark.Parser
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate ParseResult<TValue> ParseAction<TValue>(Position position);
}

