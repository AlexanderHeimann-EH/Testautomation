namespace Spark.Parser.Syntax
{
    using Spark.Parser;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CSharpGrammar : CharGrammar
    {
        public ParseAction<IList<Node>> Nodes;

        public CSharpGrammar()
        {
            ParseAction<Node> action = CharGrammar.Ch("${").And<string, IList<char>>(Grammar.Rep1<char>(CharGrammar.ChNot('}'))).And<Chain<string, IList<char>>, char>(CharGrammar.Ch('}')).Build<Chain<Chain<string, IList<char>>, char>, Node>(hit => new ExpressionNode(new string(hit.Left.Down.ToArray<char>())));
            ParseAction<Node> action2 = Grammar.Opt<char>(CharGrammar.Ch('\r')).And<char, char>(CharGrammar.Ch('\n')).And<Chain<char, char>, IList<char>>(Grammar.Rep<char>(CharGrammar.Ch(new Func<char, bool>(char.IsWhiteSpace)))).And<Chain<Chain<char, char>, IList<char>>, string>(CharGrammar.Ch("//:")).And<Chain<Chain<Chain<char, char>, IList<char>>, string>, IList<char>>(Grammar.Rep<char>(CharGrammar.ChNot(new char[] { '\r', '\n' }))).Build<Chain<Chain<Chain<Chain<char, char>, IList<char>>, string>, IList<char>>, Node>(hit => new StatementNode(new string(hit.Down.ToArray<char>())));
            ParseAction<Node> action3 = Grammar.Rep1<char>(CharGrammar.Ch((Func<char, bool>) (c => true)).Unless<char, Node>(action2).Unless<char, Node>(action)).Build<IList<char>, Node>(hit => new TextNode(hit));
            this.Nodes = Grammar.Rep<Node>(action2.Or<Node>(action).Or<Node>(action3));
        }
    }
}

