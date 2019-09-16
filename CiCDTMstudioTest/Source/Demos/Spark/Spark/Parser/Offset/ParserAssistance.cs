namespace Spark.Parser.Offset
{
    using Spark.Parser;
    using System;
    using System.Runtime.CompilerServices;

    internal static class ParserAssistance
    {
        public static ParseAction<TValue1> Skip<TValue1, TValue2>(this ParseAction<TValue1> p1, ParseAction<TValue2> p2)
        {
            return delegate (Position input) {
                ParseResult<TValue1> result = p1(input);
                if (result == null)
                {
                    return null;
                }
                ParseResult<TValue2> result2 = p2(result.Rest);
                if (result2 == null)
                {
                    return null;
                }
                return new ParseResult<TValue1>(result2.Rest, result.Value);
            };
        }
    }
}

