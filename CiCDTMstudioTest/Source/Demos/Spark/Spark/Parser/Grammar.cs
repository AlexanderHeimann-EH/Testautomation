namespace Spark.Parser
{
    using System;
    using System.Collections.Generic;

    public abstract class Grammar
    {
        protected Grammar()
        {
        }

        public static ParseAction<Chain<TValue1, TValue2>> And<TValue1, TValue2>(ParseAction<TValue1> p1, ParseAction<TValue2> p2)
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
                return new ParseResult<Chain<TValue1, TValue2>>(result2.Rest, new Chain<TValue1, TValue2>(result.Value, result2.Value));
            };
        }

        public static ParseAction<TValue> IfNext<TValue, TValue2>(ParseAction<TValue> parse, ParseAction<TValue2> cond)
        {
            return delegate (Position input) {
                ParseResult<TValue> result = parse(input);
                if ((result != null) && (cond(result.Rest) != null))
                {
                    return result;
                }
                return null;
            };
        }

        public static ParseAction<TValue> NotNext<TValue, TValue2>(ParseAction<TValue> parse, ParseAction<TValue2> cond)
        {
            return delegate (Position input) {
                ParseResult<TValue> result = parse(input);
                if ((result != null) && (cond(result.Rest) == null))
                {
                    return result;
                }
                return null;
            };
        }

        public static ParseAction<TValue> Opt<TValue>(ParseAction<TValue> parse)
        {
            return input => (parse(input) ?? new ParseResult<TValue>(input, default(TValue)));
        }

        public static ParseAction<TValue> Or<TValue>(ParseAction<TValue> p1, ParseAction<TValue> p2)
        {
            return input => (p1(input) ?? p2(input));
        }

        public static ParseAction<TValue> Paint<TValue>(ParseAction<TValue> parser)
        {
            return delegate (Position position) {
                ParseResult<TValue> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<TValue>(result.Rest.Paint<TValue>(position, result.Value), result.Value);
            };
        }

        public static ParseAction<TValue> Paint<TValue, TPaintValue>(ParseAction<TValue> parser) where TValue: TPaintValue
        {
            return delegate (Position position) {
                ParseResult<TValue> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<TValue>(result.Rest.Paint<TPaintValue>(position, (TPaintValue) result.Value), result.Value);
            };
        }

        public static ParseAction<TValue> Paint<TValue, TPaintValue>(TPaintValue value, ParseAction<TValue> parser)
        {
            return delegate (Position position) {
                ParseResult<TValue> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<TValue>(result.Rest.Paint<TPaintValue>(position, value), result.Value);
            };
        }

        public static ParseAction<IList<TValue>> Rep<TValue>(ParseAction<TValue> parse)
        {
            return delegate (Position input) {
                List<TValue> list = new List<TValue>();
                Position position = input;
                for (ParseResult<TValue> result = parse(position); result != null; result = parse(position))
                {
                    list.Add(result.Value);
                    position = result.Rest;
                }
                return new ParseResult<IList<TValue>>(position, list);
            };
        }

        public static ParseAction<IList<TValue>> Rep1<TValue>(ParseAction<TValue> parse)
        {
            return delegate (Position input) {
                Position position = input;
                ParseResult<TValue> result = parse(position);
                if (result == null)
                {
                    return null;
                }
                List<TValue> list = new List<TValue>();
                while (result != null)
                {
                    position = result.Rest;
                    list.Add(result.Value);
                    result = parse(position);
                }
                return new ParseResult<IList<TValue>>(position, list);
            };
        }

        public static ParseAction<TValue1> Unless<TValue1, TValue2>(ParseAction<TValue1> p1, ParseAction<TValue2> p2)
        {
            return delegate (Position input) {
                ParseResult<TValue1> result = p1(input);
                if (result == null)
                {
                    return null;
                }
                if (p2(input) != null)
                {
                    return null;
                }
                return result;
            };
        }
    }
}

