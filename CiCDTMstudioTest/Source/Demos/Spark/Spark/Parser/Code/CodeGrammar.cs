namespace Spark.Parser.Code
{
    using Spark.Parser;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class CodeGrammar : CharGrammar
    {
        public ParseAction<IList<Snippet>> _stringLiteral;
        public ParseAction<Snippets> Expression;
        public ParseAction<IList<Snippet>> ExpressionTerms;
        public Func<ParseAction<string>, ParseAction<Snippets>> LimitedExpression;
        public Func<ParseAction<string>, ParseAction<IList<Snippet>>> LimitedExpressionTerms;
        public ParseAction<IList<Snippet>> Statement1;
        public ParseAction<IList<Snippet>> Statement2;

        public CodeGrammar()
        {
            Func<ParseAction<string>, ParseAction<Snippets>> func = null;
            Func<IList<char>, string> bs = hit => new string(hit.ToArray<char>());
            Func<IList<string>, string> js = hit => string.Concat(hit.ToArray<string>());
            ParseAction<string> action = CharGrammar.Ch('\\').And<char, char>(CharGrammar.Ch((Func<char, bool>) (c => true))).Build<Chain<char, char>, string>(hit => @"\" + hit.Down);
            ParseAction<string> parse = Grammar.Rep1<char>(CharGrammar.ChNot(new char[] { '"', '\\' })).Build<IList<char>, string>(bs).Or<string>(action);
            ParseAction<IList<Snippet>> action3 = Snip<Chain<Chain<char, IList<string>>, char>>(CharGrammar.Ch('"').And<char, IList<string>>(Grammar.Rep<string>(parse)).And<Chain<char, IList<string>>, char>(CharGrammar.Ch('"')), (Func<Chain<Chain<char, IList<string>>, char>, string>) (hit => ("\"" + js(hit.Left.Down) + "\"")));
            ParseAction<string> action4 = CharGrammar.Ch("\"\"").Or<string>(CharGrammar.ChNot('"').Build<char, string>(ch => new string(ch, 1)));
            ParseAction<IList<Snippet>> action5 = Snip<Chain<Chain<string, IList<string>>, char>>(CharGrammar.Ch("@\"").And<string, IList<string>>(Grammar.Rep<string>(action4)).And<Chain<string, IList<string>>, char>(CharGrammar.Ch('"')), (Func<Chain<Chain<string, IList<string>>, char>, string>) (hit => ("@\"" + js(hit.Left.Down) + "\"")));
            ParseAction<IList<Snippet>> action6 = Snip(Grammar.Rep1<char>(CharGrammar.ChNot(new char[] { '\'', '\\', '"' }))).Or<IList<Snippet>>(Snip(action)).Or<IList<Snippet>>(Swap<char>(CharGrammar.Ch('"'), "\\\""));
            ParseAction<IList<Snippet>> action7 = Snip(Swap<char>(CharGrammar.Ch('\''), "\"").And<IList<Snippet>, IList<Snippet>>(Snip(Grammar.Rep<IList<Snippet>>(action6))).And<Chain<IList<Snippet>, IList<Snippet>>, IList<Snippet>>(Swap<char>(CharGrammar.Ch('\''), "\"")));
            ParseAction<IList<Snippet>> action8 = Swap<string>(CharGrammar.Ch("''"), "'").Or<IList<Snippet>>(Swap<char>(CharGrammar.Ch('"'), "\"\"")).Or<IList<Snippet>>(Snip(CharGrammar.ChNot('\'')));
            ParseAction<IList<Snippet>> action9 = Snip(Swap<string>(CharGrammar.Ch("@'"), "@\"").And<IList<Snippet>, IList<Snippet>>(Snip(Grammar.Rep<IList<Snippet>>(action8))).And<Chain<IList<Snippet>, IList<Snippet>>, IList<Snippet>>(Swap<char>(CharGrammar.Ch('\''), "\"")));
            ParseAction<IList<Snippet>> stringLiteral = TkStr<IList<Snippet>>(action3.Or<IList<Snippet>>(action5).Or<IList<Snippet>>(action7).Or<IList<Snippet>>(action9));
            this._stringLiteral = stringLiteral;
            ParseAction<IList<Snippet>> SpecialCharCast = Snip<Chain<Chain<string, string>, char>>(CharGrammar.Ch("(char)'").And<string, string>(CharGrammar.ChNot(new char[] { '\'', '\\' }).Build<char, string>(ch => ch.ToString()).Or<string>(action)).And<Chain<string, string>, char>(CharGrammar.Ch('\'')), (Func<Chain<Chain<string, string>, char>, string>) (hit => ("(char)'" + hit.Left.Down + "'")));
            ParseAction<IList<Snippet>> oneLineComment = Snip<Chain<string, IList<char>>>(CharGrammar.Ch("//").And<string, IList<char>>(Grammar.Rep<char>(CharGrammar.ChNot(new char[] { '\r', '\n' }))), (Func<Chain<string, IList<char>>, string>) (hit => ("//" + bs(hit.Down))));
            ParseAction<IList<Snippet>> multiLineComment = Snip<Chain<Chain<string, IList<char>>, string>>(CharGrammar.Ch("/*").And<string, IList<char>>(Grammar.Rep<char>(CharGrammar.Ch((Func<char, bool>) (c => true)).Unless<char, string>(CharGrammar.Ch("*/")))).And<Chain<string, IList<char>>, string>(CharGrammar.Ch("*/")), (Func<Chain<Chain<string, IList<char>>, string>, string>) (hit => ("/*" + bs(hit.Left.Down) + "*/")));
            ParseAction<char> action10 = CharGrammar.Ch((Func<char, bool>) (c => (char.GetUnicodeCategory(c) == UnicodeCategory.ConnectorPunctuation)));
            ParseAction<char> action11 = CharGrammar.Ch(delegate (char c) {
                if (char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    return char.GetUnicodeCategory(c) == UnicodeCategory.SpacingCombiningMark;
                }
                return true;
            });
            ParseAction<char> action12 = CharGrammar.Ch((Func<char, bool>) (c => (char.GetUnicodeCategory(c) == UnicodeCategory.Format)));
            ParseAction<char> action13 = CharGrammar.Ch(new Func<char, bool>(char.IsLetter)).Or<char>(CharGrammar.Ch('_'));
            ParseAction<char> action14 = CharGrammar.Ch(new Func<char, bool>(char.IsLetterOrDigit)).Or<char>(action10).Or<char>(action11).Or<char>(action12);
            ParseAction<string> action15 = action13.And<char, IList<char>>(Grammar.Rep<char>(action14)).Build<Chain<char, IList<char>>, string>(hit => hit.Left + new string(hit.Down.ToArray<char>()));
            ParseAction<IList<Snippet>> keyword = Snip(CharGrammar.Ch("abstract").Or<string>(CharGrammar.Ch("as")).Or<string>(CharGrammar.Ch("base")).Or<string>(CharGrammar.Ch("bool")).Or<string>(CharGrammar.Ch("break")).Or<string>(CharGrammar.Ch("byte")).Or<string>(CharGrammar.Ch("case")).Or<string>(CharGrammar.Ch("catch")).Or<string>(CharGrammar.Ch("char")).Or<string>(CharGrammar.Ch("checked")).Or<string>(CharGrammar.Ch("class")).Or<string>(CharGrammar.Ch("const")).Or<string>(CharGrammar.Ch("continue")).Or<string>(CharGrammar.Ch("decimal")).Or<string>(CharGrammar.Ch("default")).Or<string>(CharGrammar.Ch("delegate")).Or<string>(CharGrammar.Ch("double")).Or<string>(CharGrammar.Ch("do")).Or<string>(CharGrammar.Ch("else")).Or<string>(CharGrammar.Ch("enum")).Or<string>(CharGrammar.Ch("event")).Or<string>(CharGrammar.Ch("explicit")).Or<string>(CharGrammar.Ch("extern")).Or<string>(CharGrammar.Ch("false")).Or<string>(CharGrammar.Ch("finally")).Or<string>(CharGrammar.Ch("fixed")).Or<string>(CharGrammar.Ch("float")).Or<string>(CharGrammar.Ch("foreach")).Or<string>(CharGrammar.Ch("for")).Or<string>(CharGrammar.Ch("goto")).Or<string>(CharGrammar.Ch("if")).Or<string>(CharGrammar.Ch("implicit")).Or<string>(CharGrammar.Ch("int")).Or<string>(CharGrammar.Ch("in")).Or<string>(CharGrammar.Ch("interface")).Or<string>(CharGrammar.Ch("internal")).Or<string>(CharGrammar.Ch("is")).Or<string>(CharGrammar.Ch("lock")).Or<string>(CharGrammar.Ch("long")).Or<string>(CharGrammar.Ch("namespace")).Or<string>(CharGrammar.Ch("new")).Or<string>(CharGrammar.Ch("null")).Or<string>(CharGrammar.Ch("object")).Or<string>(CharGrammar.Ch("operator")).Or<string>(CharGrammar.Ch("out")).Or<string>(CharGrammar.Ch("override")).Or<string>(CharGrammar.Ch("params")).Or<string>(CharGrammar.Ch("private")).Or<string>(CharGrammar.Ch("protected")).Or<string>(CharGrammar.Ch("public")).Or<string>(CharGrammar.Ch("readonly")).Or<string>(CharGrammar.Ch("ref")).Or<string>(CharGrammar.Ch("return")).Or<string>(CharGrammar.Ch("sbyte")).Or<string>(CharGrammar.Ch("sealed")).Or<string>(CharGrammar.Ch("short")).Or<string>(CharGrammar.Ch("sizeof")).Or<string>(CharGrammar.Ch("stackalloc")).Or<string>(CharGrammar.Ch("static")).Or<string>(CharGrammar.Ch("string")).Or<string>(CharGrammar.Ch("struct")).Or<string>(CharGrammar.Ch("switch")).Or<string>(CharGrammar.Ch("this")).Or<string>(CharGrammar.Ch("throw")).Or<string>(CharGrammar.Ch("true")).Or<string>(CharGrammar.Ch("try")).Or<string>(CharGrammar.Ch("typeof")).Or<string>(CharGrammar.Ch("uint")).Or<string>(CharGrammar.Ch("ulong")).Or<string>(CharGrammar.Ch("unchecked")).Or<string>(CharGrammar.Ch("unsafe")).Or<string>(CharGrammar.Ch("ushort")).Or<string>(CharGrammar.Ch("using")).Or<string>(CharGrammar.Ch("virtual")).Or<string>(CharGrammar.Ch("void")).Or<string>(CharGrammar.Ch("volatile")).Or<string>(CharGrammar.Ch("while"))).NotNext<IList<Snippet>, char>(action14);
            ParseAction<IList<Snippet>> identifier = Snip(action15.Unless<string, IList<Snippet>>(keyword)).Or<IList<Snippet>>(Swap<string>(CharGrammar.Ch("class"), "@class")).Or<IList<Snippet>>(Snip<Chain<char, string>>(CharGrammar.Ch('@').And<char, string>(action15), (Func<Chain<char, string>, string>) (hit => ("@" + hit.Down))));
            ParseAction<IList<Snippet>> action17 = Snip<Chain<char, string>>(CharGrammar.Ch('.').And<char, string>(action15), (Func<Chain<char, string>, string>) (hit => (hit.Left + hit.Down)));
            ParseAction<IList<Snippet>> action18 = Swap<Chain<IList<char>, Chain<Chain<char, IList<char>>, char>>>(Grammar.Opt<IList<char>>(Grammar.Rep<char>(CharGrammar.Ch(new char[] { ' ', '\t' }))).And<IList<char>, Chain<Chain<char, IList<char>>, char>>(CharGrammar.Ch('"').And<char, IList<char>>(Grammar.Rep1<char>(CharGrammar.ChNot('"'))).And<Chain<char, IList<char>>, char>(CharGrammar.Ch('"')).Or<Chain<Chain<char, IList<char>>, char>>(CharGrammar.Ch('\'').And<char, IList<char>>(Grammar.Rep1<char>(CharGrammar.ChNot('\''))).And<Chain<char, IList<char>>, char>(CharGrammar.Ch('\'')))), (Func<Chain<IList<char>, Chain<Chain<char, IList<char>>, char>>, string>) (hit => (", \"{0:" + new string(hit.Down.Left.Down.ToArray<char>()) + "}\"")));
            ParseAction<IList<Snippet>> lateBound = CharGrammar.Ch('#').And<char, IList<Snippet>>(Snip(action15)).And<Chain<char, IList<Snippet>>, IList<Snippet>>(Snip(Grammar.Rep<IList<Snippet>>(action17))).And<Chain<Chain<char, IList<Snippet>>, IList<Snippet>>, IList<Snippet>>(Grammar.Opt<IList<Snippet>>(action18)).Build<Chain<Chain<Chain<char, IList<Snippet>>, IList<Snippet>>, IList<Snippet>>, IList<Snippet>>(hit => new Snippets("Eval(\"").Concat<Snippet>(hit.Left.Left.Down).Concat<Snippet>(hit.Left.Down).Concat<Snippet>(new Snippets("\"")).Concat<Snippet>((hit.Down ?? ((IList<Snippet>) new Snippet[0]))).Concat<Snippet>(new Snippets(")")).ToList<Snippet>());
            ParseAction<IList<Snippet>> action19 = Snip(Grammar.Rep1<IList<Snippet>>(Swap<string>(CharGrammar.Ch("[["), "<").Or<IList<Snippet>>(Swap<string>(CharGrammar.Ch("]]"), ">")).Or<IList<Snippet>>(lateBound).Or<IList<Snippet>>(Snip(CharGrammar.ChNot(new char[] { '"', '\'', '{', '}', '(', ')' }))).Unless<IList<Snippet>, IList<Snippet>>(identifier.Or<IList<Snippet>>(keyword).Or<IList<Snippet>>(SpecialCharCast)).Unless<IList<Snippet>, string>(CharGrammar.Ch("%>").Or<string>(CharGrammar.Ch("@\"")).Or<string>(CharGrammar.Ch("@'")).Or<string>(CharGrammar.Ch("//")).Or<string>(CharGrammar.Ch("/*")))));
            Func<ParseAction<string>, ParseAction<IList<Snippet>>> limitedCodeStretch = limit => Snip(Grammar.Rep1<IList<Snippet>>(Swap<string>(CharGrammar.Ch("[["), "<").Or<IList<Snippet>>(Swap<string>(CharGrammar.Ch("]]"), ">")).Or<IList<Snippet>>(lateBound).Or<IList<Snippet>>(Snip(CharGrammar.ChNot(new char[] { '"', '\'', '{', '}', '(', ')' }))).Unless<IList<Snippet>, IList<Snippet>>(identifier.Or<IList<Snippet>>(keyword).Or<IList<Snippet>>(SpecialCharCast)).Unless<IList<Snippet>, string>(limit.Or<string>(CharGrammar.Ch("@\"")).Or<string>(CharGrammar.Ch("@'")).Or<string>(CharGrammar.Ch("//")).Or<string>(CharGrammar.Ch("/*")))));
            ParseAction<IList<Snippet>> braced = Snip(Snip(CharGrammar.Ch('{')).And<IList<Snippet>, IList<Snippet>>(new ParseAction<IList<Snippet>>(this.FnTerms)).And<Chain<IList<Snippet>, IList<Snippet>>, IList<Snippet>>(Snip(CharGrammar.Ch('}'))));
            ParseAction<IList<Snippet>> parens = Snip(Snip(CharGrammar.Ch('(')).And<IList<Snippet>, IList<Snippet>>(new ParseAction<IList<Snippet>>(this.FnTerms)).And<Chain<IList<Snippet>, IList<Snippet>>, IList<Snippet>>(Snip(CharGrammar.Ch(')')))).Unless<IList<Snippet>, IList<Snippet>>(SpecialCharCast);
            this.ExpressionTerms = Snip(Grammar.Rep1<IList<Snippet>>(stringLiteral.Or<IList<Snippet>>(braced).Or<IList<Snippet>>(parens).Or<IList<Snippet>>(action19).Or<IList<Snippet>>(identifier).Or<IList<Snippet>>(keyword).Or<IList<Snippet>>(SpecialCharCast).Or<IList<Snippet>>(oneLineComment).Or<IList<Snippet>>(multiLineComment))).Or<IList<Snippet>>(EmptySnip());
            this.LimitedExpressionTerms = limit => Snip(Grammar.Rep1<IList<Snippet>>(stringLiteral.Or<IList<Snippet>>(braced).Or<IList<Snippet>>(parens).Or<IList<Snippet>>(limitedCodeStretch(limit)).Or<IList<Snippet>>(identifier).Or<IList<Snippet>>(keyword).Or<IList<Snippet>>(SpecialCharCast).Or<IList<Snippet>>(oneLineComment).Or<IList<Snippet>>(multiLineComment))).Or<IList<Snippet>>(EmptySnip());
            this.Expression = this.ExpressionTerms.Build<IList<Snippet>, Snippets>(hit => new Snippets(hit));
            if (func == null)
            {
                func = limit => this.LimitedExpressionTerms(limit).Build<IList<Snippet>, Snippets>(hit => new Snippets(hit));
            }
            this.LimitedExpression = func;
            ParseAction<IList<Snippet>> action20 = Swap<string>(CharGrammar.Ch("[["), "<").Or<IList<Snippet>>(Swap<string>(CharGrammar.Ch("]]"), ">")).Or<IList<Snippet>>(lateBound).Or<IList<Snippet>>(Snip(CharGrammar.ChNot(new char[] { '"', '\'' }))).Unless<IList<Snippet>, IList<Snippet>>(SpecialCharCast).Unless<IList<Snippet>, string>(CharGrammar.Ch("@\"").Or<string>(CharGrammar.Ch("@'")).Or<string>(CharGrammar.Ch("//")).Or<string>(CharGrammar.Ch("/*")));
            ParseAction<IList<Snippet>> action21 = Snip(Grammar.Rep1<IList<Snippet>>(action20.Unless<IList<Snippet>, char>(CharGrammar.Ch(new char[] { '\r', '\n' }))));
            ParseAction<IList<Snippet>> action22 = Snip(Grammar.Rep1<IList<Snippet>>(action20.Unless<IList<Snippet>, string>(CharGrammar.Ch("%>"))));
            this.Statement1 = Snip(Grammar.Rep<IList<Snippet>>(stringLiteral.Or<IList<Snippet>>(action21).Or<IList<Snippet>>(SpecialCharCast).Or<IList<Snippet>>(oneLineComment).Or<IList<Snippet>>(multiLineComment)));
            this.Statement2 = Snip(Grammar.Rep<IList<Snippet>>(stringLiteral.Or<IList<Snippet>>(action22).Or<IList<Snippet>>(SpecialCharCast).Or<IList<Snippet>>(oneLineComment).Or<IList<Snippet>>(multiLineComment)));
        }

        private static ParseAction<IList<Snippet>> EmptySnip()
        {
            return delegate (Position position) {
                Snippet[] snippetArray = new Snippet[1];
                Snippet snippet = new Snippet {
                    Value = "",
                    Begin = position,
                    End = position
                };
                snippetArray[0] = snippet;
                return new ParseResult<IList<Snippet>>(position, snippetArray);
            };
        }

        private ParseResult<IList<Snippet>> FnTerms(Position position)
        {
            return this.ExpressionTerms(position);
        }

        private static ParseAction<IList<Snippet>> Snip(ParseAction<char> parser)
        {
            return delegate (Position position) {
                ParseResult<char> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                Snippet snippet = new Snippet {
                    Value = new string(result.Value, 1),
                    Begin = position,
                    End = result.Rest
                };
                return new ParseResult<IList<Snippet>>(result.Rest, new Snippet[] { snippet });
            };
        }

        private static ParseAction<IList<Snippet>> Snip(ParseAction<Chain<Chain<IList<Snippet>, IList<Snippet>>, IList<Snippet>>> parser)
        {
            return Snip<Chain<Chain<IList<Snippet>, IList<Snippet>>, IList<Snippet>>>(parser, (Func<Chain<Chain<IList<Snippet>, IList<Snippet>>, IList<Snippet>>, IList<IList<Snippet>>>) (hit => new IList<Snippet>[] { hit.Left.Left, hit.Left.Down, hit.Down }));
        }

        private static ParseAction<IList<Snippet>> Snip(ParseAction<IList<Snippet>> parser)
        {
            return parser;
        }

        private static ParseAction<IList<Snippet>> Snip(ParseAction<IList<char>> parser)
        {
            return delegate (Position position) {
                ParseResult<IList<char>> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                Snippet snippet = new Snippet {
                    Value = new string(result.Value.ToArray<char>()),
                    Begin = position,
                    End = result.Rest
                };
                return new ParseResult<IList<Snippet>>(result.Rest, new Snippet[] { snippet });
            };
        }

        private static ParseAction<IList<Snippet>> Snip(ParseAction<IList<IList<Snippet>>> parser)
        {
            return delegate (Position position) {
                ParseResult<IList<IList<Snippet>>> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<IList<Snippet>>(result.Rest, (from s in result.Value select s).ToArray<Snippet>());
            };
        }

        private static ParseAction<IList<Snippet>> Snip(ParseAction<IList<string>> parser)
        {
            return delegate (Position position) {
                ParseResult<IList<string>> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                Snippet snippet = new Snippet {
                    Value = string.Concat(result.Value.ToArray<string>()),
                    Begin = position,
                    End = result.Rest
                };
                return new ParseResult<IList<Snippet>>(result.Rest, new Snippet[] { snippet });
            };
        }

        private static ParseAction<IList<Snippet>> Snip(ParseAction<string> parser)
        {
            return delegate (Position position) {
                ParseResult<string> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                Snippet snippet = new Snippet {
                    Value = new string(result.Value.ToArray<char>()),
                    Begin = position,
                    End = result.Rest
                };
                return new ParseResult<IList<Snippet>>(result.Rest, new Snippet[] { snippet });
            };
        }

        private static ParseAction<IList<Snippet>> Snip<TValue>(ParseAction<TValue> parser, Func<TValue, IList<IList<Snippet>>> combiner)
        {
            return delegate (Position position) {
                ParseResult<TValue> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                return new ParseResult<IList<Snippet>>(result.Rest, (from s in combiner(result.Value) select s).ToArray<Snippet>());
            };
        }

        private static ParseAction<IList<Snippet>> Snip<TValue>(ParseAction<TValue> parser, Func<TValue, string> builder)
        {
            return delegate (Position position) {
                ParseResult<TValue> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                Snippet snippet = new Snippet {
                    Value = builder(result.Value),
                    Begin = position,
                    End = result.Rest
                };
                return new ParseResult<IList<Snippet>>(result.Rest, new Snippet[] { snippet });
            };
        }

        private static ParseAction<IList<Snippet>> Swap<TValue>(ParseAction<TValue> parser, Func<TValue, string> replacement)
        {
            return delegate (Position position) {
                ParseResult<TValue> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                Snippet snippet = new Snippet {
                    Value = replacement(result.Value)
                };
                return new ParseResult<IList<Snippet>>(result.Rest, new Snippet[] { snippet });
            };
        }

        private static ParseAction<IList<Snippet>> Swap<TValue>(ParseAction<TValue> parser, string replacement)
        {
            return delegate (Position position) {
                ParseResult<TValue> result = parser(position);
                if (result == null)
                {
                    return null;
                }
                Snippet snippet = new Snippet {
                    Value = replacement
                };
                return new ParseResult<IList<Snippet>>(result.Rest, new Snippet[] { snippet });
            };
        }

        protected static ParseAction<TValue> TkAspxCode<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlServerSideScript, parser);
        }

        protected static ParseAction<TValue> TkAttDelim<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlOperator, parser);
        }

        protected static ParseAction<TValue> TkAttNam<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlAttributeName, parser);
        }

        protected static ParseAction<TValue> TkAttQuo<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlAttributeValue, parser);
        }

        protected static ParseAction<TValue> TkAttVal<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlAttributeValue, parser);
        }

        protected static ParseAction<TValue> TkCDATA<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.PlainText, parser);
        }

        protected static ParseAction<TValue> TkCode<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.SparkDelimiter, parser);
        }

        protected static ParseAction<TValue> TkComm<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlComment, parser);
        }

        protected static ParseAction<TValue> TkEleNam<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlElementName, parser);
        }

        protected static ParseAction<TValue> TkEntity<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlEntity, parser);
        }

        protected static ParseAction<TValue> TkStr<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.String, parser);
        }

        protected static ParseAction<TValue> TkTagDelim<TValue>(ParseAction<TValue> parser)
        {
            return Grammar.Paint<TValue, SparkTokenType>(SparkTokenType.HtmlTagDelimiter, parser);
        }
    }
}

