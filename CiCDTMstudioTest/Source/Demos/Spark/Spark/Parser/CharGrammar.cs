namespace Spark.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CharGrammar : Grammar
    {
        public static ParseAction<char> Ch(char allowed)
        {
            return delegate (Position input) {
                if (input.Peek() != allowed)
                {
                    return null;
                }
                return new ParseResult<char>(input.Advance(1), allowed);
            };
        }

        public static ParseAction<char> Ch(Func<char, bool> predicate)
        {
            return delegate (Position input) {
                if ((input.PotentialLength() != 0) && predicate(input.Peek()))
                {
                    return new ParseResult<char>(input.Advance(1), input.Peek());
                }
                return null;
            };
        }

        public static ParseAction<char> Ch(params char[] allowed)
        {
            return delegate (Position input) {
                char item = input.Peek();
                if ((input.PotentialLength() != 0) && ((IList<char>) allowed).Contains(item))
                {
                    return new ParseResult<char>(input.Advance(1), item);
                }
                return null;
            };
        }

        public static ParseAction<string> Ch(string match)
        {
            return delegate (Position input) {
                if (!input.PeekTest(match))
                {
                    return null;
                }
                return new ParseResult<string>(input.Advance(match.Length), match);
            };
        }

        public static ParseAction<char> ChControl()
        {
            return ChSTX().Or<char>(ChETX());
        }

        public static ParseAction<char> ChETX()
        {
            return delegate (Position input) {
                if (input.PotentialLength() == 0)
                {
                    return new ParseResult<char>(input, '\x0003');
                }
                return null;
            };
        }

        public static ParseAction<char> ChNot(char disallowed)
        {
            return delegate (Position input) {
                char ch = input.Peek();
                if ((ch != '\0') && (ch != disallowed))
                {
                    return new ParseResult<char>(input.Advance(1), ch);
                }
                return null;
            };
        }

        public static ParseAction<char> ChNot(Func<char, bool> predicate)
        {
            return delegate (Position input) {
                if ((input.PotentialLength() != 0) && !predicate(input.Peek()))
                {
                    return new ParseResult<char>(input.Advance(1), input.Peek());
                }
                return null;
            };
        }

        public static ParseAction<char> ChNot(params char[] disallowed)
        {
            return delegate (Position input) {
                char item = input.Peek();
                if ((input.PotentialLength() != 0) && !((IList<char>) disallowed).Contains(item))
                {
                    return new ParseResult<char>(input.Advance(1), item);
                }
                return null;
            };
        }

        public static ParseAction<string> ChNot(string match)
        {
            return delegate (Position input) {
                if (input.PeekTest(match))
                {
                    return null;
                }
                return new ParseResult<string>(input.Advance(match.Length), match);
            };
        }

        public static ParseAction<char> ChSTX()
        {
            return delegate (Position input) {
                if (input.Offset == 0)
                {
                    return new ParseResult<char>(input, '\x0003');
                }
                return null;
            };
        }

        public static ParseAction<string> StringOf(ParseAction<char> parse)
        {
            return delegate (Position input) {
                StringBuilder builder = new StringBuilder();
                Position position = input;
                for (ParseResult<char> result = parse(position); result != null; result = parse(position))
                {
                    builder.Append(result.Value);
                    position = result.Rest;
                }
                return new ParseResult<string>(position, builder.ToString());
            };
        }
    }
}

