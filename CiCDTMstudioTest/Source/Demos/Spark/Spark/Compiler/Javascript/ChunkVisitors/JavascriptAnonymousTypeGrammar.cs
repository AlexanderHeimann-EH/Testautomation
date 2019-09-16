namespace Spark.Compiler.Javascript.ChunkVisitors
{
    using Spark.Parser;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class JavascriptAnonymousTypeGrammar : CharGrammar
    {
        private readonly ParseAction<string> _valuePart;
        public ParseAction<string> test_anonymousType;
        public ParseAction<string> test_doubleString;
        public ParseAction<string> test_propName;
        public ParseAction<string> test_propValue;
        public ParseAction<string> test_singleString;
        public ParseAction<string> test_term;
        public ParseAction<string> test_terms;
        public ParseAction<string> test_ws;

        public JavascriptAnonymousTypeGrammar()
        {
            ParseAction<IList<char>> action = Grammar.Rep<char>(CharGrammar.Ch(new char[] { ' ', '\t', '\r', '\n' }));
            ParseAction<Chain<char, IList<char>>> parser = CharGrammar.Ch(new Func<char, bool>(char.IsLetter)).Or<char>(CharGrammar.Ch('_')).And<char, IList<char>>(Grammar.Rep<char>(CharGrammar.Ch(new Func<char, bool>(char.IsLetterOrDigit)).Or<char>(CharGrammar.Ch('_'))));
            ParseAction<Chain<Chain<char, IList<char>>, char>> action3 = CharGrammar.Ch('"').And<char, IList<char>>(Grammar.Rep<char>(CharGrammar.ChNot('"'))).And<Chain<char, IList<char>>, char>(CharGrammar.Ch('"'));
            ParseAction<Chain<Chain<char, IList<char>>, char>> action4 = CharGrammar.Ch('\'').And<char, IList<char>>(Grammar.Rep<char>(CharGrammar.ChNot('\''))).And<Chain<char, IList<char>>, char>(CharGrammar.Ch('\''));
            ParseAction<string> action5 = new ParseAction<string>(this.ValuePart);
            ParseAction<IList<string>> action7 = Grammar.Rep<string>(Str<IList<char>>(Grammar.Rep1<char>(CharGrammar.ChNot(new char[] { '}', ',' }).Unless<char, string>(action5))).Or<string>(action5));
            ParseAction<string> action8 = action.And<IList<char>, string>(Str<Chain<char, IList<char>>>(parser)).And<Chain<IList<char>, string>, IList<char>>(action).And<Chain<Chain<IList<char>, string>, IList<char>>, char>(CharGrammar.Ch('=')).And<Chain<Chain<Chain<IList<char>, string>, IList<char>>, char>, IList<char>>(action).And<Chain<Chain<Chain<Chain<IList<char>, string>, IList<char>>, char>, IList<char>>, IList<string>>(action7).Build<Chain<Chain<Chain<Chain<Chain<IList<char>, string>, IList<char>>, char>, IList<char>>, IList<string>>, string>(hit => hit.Left.Left.Left.Left.Down + ":" + string.Concat(hit.Down.ToArray<string>()));
            ParseAction<Chain<Chain<IList<char>, char>, IList<char>>> action9 = action.And<IList<char>, char>(CharGrammar.Ch(',')).And<Chain<IList<char>, char>, IList<char>>(action);
            ParseAction<IEnumerable<string>> action10 = action8.And<string, IList<Chain<Chain<Chain<IList<char>, char>, IList<char>>, string>>>(Grammar.Rep<Chain<Chain<Chain<IList<char>, char>, IList<char>>, string>>(action9.And<Chain<Chain<IList<char>, char>, IList<char>>, string>(action8))).Build<Chain<string, IList<Chain<Chain<Chain<IList<char>, char>, IList<char>>, string>>>, IEnumerable<string>>(hit => new string[] { hit.Left }.Concat<string>(from x in hit.Down select x.Down));
            ParseAction<string> action11 = CharGrammar.Ch("new").And<string, IList<char>>(action).And<Chain<string, IList<char>>, char>(CharGrammar.Ch('{')).And<Chain<Chain<string, IList<char>>, char>, IEnumerable<string>>(action10).And<Chain<Chain<Chain<string, IList<char>>, char>, IEnumerable<string>>, char>(CharGrammar.Ch('}')).Build<Chain<Chain<Chain<Chain<string, IList<char>>, char>, IEnumerable<string>>, char>, string>(hit => "{" + string.Join(",", hit.Left.Down.ToArray<string>()) + "}");
            this._valuePart = Str<Chain<Chain<char, IList<char>>, char>>(action3.Or<Chain<Chain<char, IList<char>>, char>>(action4)).Or<string>(action11);
            ParseAction<IList<char>> action12 = Grammar.Rep1<char>(CharGrammar.Ch((Func<char, bool>) (ch => true)).Unless<char, string>(action11));
            this.ReformatCode = Grammar.Rep<string>(Str<IList<char>>(action12).Or<string>(action11)).Build<IList<string>, string>(hit => string.Concat(hit.ToArray<string>()));
            this.test_ws = Test<IList<char>>(action);
            this.test_doubleString = Test<Chain<Chain<char, IList<char>>, char>>(action3);
            this.test_singleString = Test<Chain<Chain<char, IList<char>>, char>>(action4);
            this.test_propName = Test<Chain<char, IList<char>>>(parser);
            this.test_propValue = Test<IList<string>>(action7);
            this.test_term = Test<string>(action8);
            this.test_terms = Test<IEnumerable<string>>(action10);
            this.test_anonymousType = action11;
        }

        private static ParseAction<string> Str<TValue>(ParseAction<TValue> parser)
        {
            return delegate (Position pos) {
                ParseResult<TValue> result = parser(pos);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<string>(result.Rest, pos.Peek(result.Rest.Offset - pos.Offset));
            };
        }

        private static ParseAction<string> Test<TValue>(ParseAction<TValue> parser)
        {
            return Str<TValue>(parser);
        }

        private ParseResult<string> ValuePart(Position pos)
        {
            return this._valuePart(pos);
        }

        public ParseAction<string> ReformatCode { get; set; }
    }
}

