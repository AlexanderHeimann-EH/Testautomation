using System.Collections.Generic;

namespace Spark.Parser
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ParseActionExtensions
    {
        public static ParseAction<Chain<TValue1, TValue2>> And<TValue1, TValue2>(this ParseAction<TValue1> p1, ParseAction<TValue2> p2)
        {
            return Grammar.And<TValue1, TValue2>(p1, p2);
        }

        public static ParseAction<TValue2> Build<TValue1, TValue2>(this ParseAction<TValue1> parser, Func<TValue1, TValue2> builder)
        {
            return delegate (Position input) {
                ParseResult<TValue1> result = parser(input);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<TValue2>(result.Rest, builder(result.Value));
            };
        }

        public static ParseAction<TDown> Down<TLeft, TDown>(this ParseAction<Chain<TLeft, TDown>> parse)
        {
            return delegate (Position input) {
                ParseResult<Chain<TLeft, TDown>> result = parse(input);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<TDown>(result.Rest, result.Value.Down);
            };
        }

        public static ParseAction<TValue> IfNext<TValue, TValue2>(this ParseAction<TValue> parse, ParseAction<TValue2> cond)
        {
            return Grammar.IfNext<TValue, TValue2>(parse, cond);
        }

        public static ParseAction<TLeft> Left<TLeft, TDown>(this ParseAction<Chain<TLeft, TDown>> parse)
        {
            return delegate (Position input) {
                ParseResult<Chain<TLeft, TDown>> result = parse(input);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<TLeft>(result.Rest, result.Value.Left);
            };
        }

        public static ParseAction<TValue> NotNext<TValue, TValue2>(this ParseAction<TValue> parse, ParseAction<TValue2> cond)
        {
            return Grammar.NotNext<TValue, TValue2>(parse, cond);
        }

        public static ParseAction<TValue> Opt<TValue>(ParseAction<TValue> parse)
        {
            return Grammar.Opt<TValue>(parse);
        }

        public static ParseAction<TValue> Or<TValue>(this ParseAction<TValue> p1, ParseAction<TValue> p2)
        {
            return Grammar.Or<TValue>(p1, p2);
        }

        public static ParseAction<TValue> Paint<TValue>(this ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue>(parser);
        }

        public static ParseAction<TValue> Paint<TValue, TPaintValue>(this ParseAction<TValue> parser) where TValue: TPaintValue
        {
            return Grammar.Paint<TValue, TPaintValue>(parser);
        }

        public static ParseAction<TValue> Paint<TValue, TPaintValue>(this ParseAction<TValue> parser, TPaintValue value)
        {
            return Grammar.Paint<TValue, TPaintValue>(value, parser);
        }

        public static ParseAction<IList<TValue>> Rep<TValue>(this ParseAction<TValue> parse)
        {
            return Grammar.Rep<TValue>(parse);
        }

        public static ParseAction<IList<TValue>> Rep1<TValue>(this ParseAction<TValue> parse)
        {
            return Grammar.Rep1<TValue>(parse);
        }

        public static ParseAction<TValue1> Unless<TValue1, TValue2>(this ParseAction<TValue1> p1, ParseAction<TValue2> p2)
        {
            return Grammar.Unless<TValue1, TValue2>(p1, p2);
        }
    }
}

