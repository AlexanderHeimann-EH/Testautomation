namespace Spark.Bindings
{
    using Spark.Parser;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class BindingGrammar : CharGrammar
    {
        public BindingGrammar()
        {
            ParseAction<char> parse = CharGrammar.Ch(new Func<char, bool>(char.IsLetterOrDigit)).Or<char>(CharGrammar.Ch(new char[] { '.', '-', '_', ':' }));
            ParseAction<string> action2 = CharGrammar.Ch(new Func<char, bool>(char.IsLetter)).Or<char>(CharGrammar.Ch(new char[] { '_', ':' })).And<char, IList<char>>(Grammar.Rep<char>(parse)).Build<Chain<char, IList<char>>, string>(hit => hit.Left + new string(hit.Down.ToArray<char>()));
            ParseAction<BindingPrefixReference> action3 = CharGrammar.Ch("\"@").And<string, string>(Grammar.Opt<string>(action2)).And<Chain<string, string>, string>(CharGrammar.Ch("*\"")).Or<Chain<Chain<string, string>, string>>(CharGrammar.Ch("'@").And<string, string>(Grammar.Opt<string>(action2)).And<Chain<string, string>, string>(CharGrammar.Ch("*'"))).Build<Chain<Chain<string, string>, string>, BindingPrefixReference>(hit => new BindingPrefixReference(hit.Left.Down) { AssumeStringValue = true });
            ParseAction<BindingPrefixReference> action4 = CharGrammar.Ch('@').And<char, string>(Grammar.Opt<string>(action2)).And<Chain<char, string>, char>(CharGrammar.Ch('*')).Build<Chain<Chain<char, string>, char>, BindingPrefixReference>(hit => new BindingPrefixReference(hit.Left.Down));
            ParseAction<BindingPrefixReference> action5 = CharGrammar.Ch("{{").And<string, BindingPrefixReference>(action3.Or<BindingPrefixReference>(action4)).And<Chain<string, BindingPrefixReference>, string>(CharGrammar.Ch("}}")).Build<Chain<Chain<string, BindingPrefixReference>, string>, BindingPrefixReference>(delegate (Chain<Chain<string, BindingPrefixReference>, string> hit) {
                hit.Left.Down.AssumeDictionarySyntax = true;
                return hit.Left.Down;
            });
            this.PrefixReference = action3.Or<BindingPrefixReference>(action4).Or<BindingPrefixReference>(action5).Build<BindingPrefixReference, BindingNode>(hit => hit);
            ParseAction<BindingNode> action6 = CharGrammar.Ch("\"@").And<string, string>(action2).And<Chain<string, string>, char>(CharGrammar.Ch('"')).Or<Chain<Chain<string, string>, char>>(CharGrammar.Ch("'@").And<string, string>(action2).And<Chain<string, string>, char>(CharGrammar.Ch('\''))).Build<Chain<Chain<string, string>, char>, BindingNode>(hit => new BindingNameReference(hit.Left.Down) { AssumeStringValue = true });
            ParseAction<BindingNode> action7 = CharGrammar.Ch('@').And<char, string>(action2).Build<Chain<char, string>, BindingNode>(hit => new BindingNameReference(hit.Down));
            ParseAction<BindingNode> action8 = CharGrammar.Ch("child::*").Or<string>(CharGrammar.Ch("'child::*'")).Or<string>(CharGrammar.Ch("\"child::*\"")).Build<string, BindingNode>(hit => new BindingChildReference());
            this.NameReference = action6.Or<BindingNode>(action7);
            ParseAction<BindingNode> action9 = this.PrefixReference.Or<BindingNode>(this.NameReference).Or<BindingNode>(action8);
            ParseAction<char> action10 = CharGrammar.Ch("[[").Build<string, char>(hit => '<').Or<char>(CharGrammar.Ch("]]").Build<string, char>(hit => '>'));
            ParseAction<char> action11 = CharGrammar.Ch((Func<char, bool>) (ch => true)).Unless<char, BindingNode>(action9).Unless<char, char>(action10);
            this.Literal = Grammar.Rep1<char>(action10.Or<char>(action11)).Build<IList<char>, BindingNode>(hit => new BindingLiteral(hit));
            this.Nodes = Grammar.Rep<BindingNode>(action9.Or<BindingNode>(this.Literal));
            this.Phrase = CharGrammar.Ch("#").And<string, IList<BindingNode>>(this.Nodes).Build<Chain<string, IList<BindingNode>>, BindingPhrase>(hit => new BindingPhrase { Type = BindingPhrase.PhraseType.Statement, Nodes = hit.Down }).Or<BindingPhrase>(this.Nodes.Build<IList<BindingNode>, BindingPhrase>(hit => new BindingPhrase { Type = BindingPhrase.PhraseType.Expression, Nodes = hit }));
        }

        public ParseAction<BindingNode> Literal { get; set; }

        public ParseAction<BindingNode> NameReference { get; set; }

        public ParseAction<IList<BindingNode>> Nodes { get; set; }

        public ParseAction<BindingPhrase> Phrase { get; set; }

        public ParseAction<BindingNode> PrefixReference { get; set; }
    }
}

