using Spark.Parser.Code;

namespace Spark.Parser.Offset
{
    using Spark.Parser;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OffsetGrammar : MarkupGrammar
    {
        public ParseAction<IndentationNode> Indentation;
        public ParseAction<ElementNode> OffsetElement;
        public ParseAction<ExpressionNode> OffsetExpression;
        public ParseAction<IList<Node>> OffsetNodes;
        public ParseAction<StatementNode> OffsetStatement;
        public ParseAction<TextNode> OffsetText;
        public ParseAction<IList<Node>> OffsetTexts;
        public ParseAction<Node[]> TestLine;

        public OffsetGrammar() : this(ParserSettings.DefaultBehavior)
        {
        }

        public OffsetGrammar(IParserSettings settings) : base(settings)
        {
            ParseAction<Chain<char, char>> action = Grammar.Opt<char>(CharGrammar.Ch('\r')).And<char, char>(CharGrammar.Ch('\n').Or<char>(CharGrammar.ChSTX()).Or<char>(CharGrammar.ChETX()));
            ParseAction<Chain<char, char>> action2 = Grammar.Opt<char>(CharGrammar.Ch('\r')).And<char, char>(CharGrammar.Ch('\n').Or<char>(CharGrammar.ChSTX()));
            ParseAction<Chain<char, char>> cond = Grammar.Opt<char>(CharGrammar.Ch('\r')).And<char, char>(CharGrammar.Ch('\n').Or<char>(CharGrammar.ChETX()));
            ParseAction<IndentationNode> action4 = action2.And<Chain<char, char>, IList<char>>(Grammar.Rep<char>(CharGrammar.Ch(new char[] { ' ', '\t' }))).NotNext<Chain<Chain<char, char>, IList<char>>, Chain<char, char>>(cond).Build<Chain<Chain<char, char>, IList<char>>, IndentationNode>(hit => new IndentationNode(hit.Down));
            Grammar.Rep1<char>(CharGrammar.Ch(new char[] { ' ', '\t' }));
            ParseAction<IList<char>> action5 = Grammar.Rep<char>(CharGrammar.Ch(new char[] { ' ', '\t' }));
            ParseAction<Node[]> action6 = action2.And<Chain<char, char>, IList<char>>(Grammar.Rep<char>(CharGrammar.Ch(new char[] { ' ', '\t' }))).IfNext<Chain<Chain<char, char>, IList<char>>, Chain<char, char>>(cond).Build<Chain<Chain<char, char>, IList<char>>, Node[]>(hit => new Node[0]);
            ParseAction<char> parse = CharGrammar.Ch(new Func<char, bool>(char.IsLetterOrDigit)).Or<char>(CharGrammar.Ch(new char[] { '-', '_', ':' }));
            ParseAction<string> action8 = CharGrammar.Ch(new Func<char, bool>(char.IsLetter)).Or<char>(CharGrammar.Ch(new char[] { '_', ':' })).And<char, IList<char>>(Grammar.Rep<char>(parse)).Build<Chain<char, IList<char>>, string>(hit => hit.Left + new string(hit.Down.ToArray<char>()));
            ParseAction<TextNode> action9 = CharGrammar.Ch('|').And<char, IList<char>>(Grammar.Rep<char>(CharGrammar.Ch((Func<char, bool>) (_ => true)).Unless<char, Chain<char, char>>(action))).Build<Chain<char, IList<char>>, TextNode>(hit => new TextNode(hit.Down));
            ParseAction<Node> action10 = base.AsNode<EntityNode>(base.EntityRef).Or<Node>(base.AsNode<ExpressionNode>(base.Code));
            ParseAction<TextNode> parser = Grammar.Rep1<char>(CharGrammar.Ch((Func<char, bool>) (ch => true)).Unless<char, Chain<char, char>>(cond).Unless<char, Node>(action10)).Build<IList<char>, TextNode>(hit => new TextNode(hit));
            ParseAction<IList<Node>> action12 = CharGrammar.Ch('|').And<char, IList<Node>>(Grammar.Rep<Node>(base.AsNode<TextNode>(parser).Or<Node>(action10))).Build<Chain<char, IList<Node>>, IList<Node>>(hit => hit.Down);
            ParseAction<ExpressionNode> action13 = CharGrammar.Ch('=').And<char, Snippets>(base.LimitedExpression(cond.Build<Chain<char, char>, string>(x => ""))).Build<Chain<char, Snippets>, ExpressionNode>(hit => new ExpressionNode(hit.Down) { AutomaticEncoding = true });
            ParseAction<StatementNode> action14 = CharGrammar.Ch('-').And<char, IList<Snippet>>(base.Statement1).Build<Chain<char, IList<Snippet>>, StatementNode>(hit => new StatementNode(hit.Down));
            ParseAction<StatementNode> action15 = CharGrammar.Ch("@{").And<string, Snippets>(base.LimitedExpression(CharGrammar.Ch("}"))).And<Chain<string, Snippets>, char>(CharGrammar.Ch('}')).Build<Chain<Chain<string, Snippets>, char>, StatementNode>(hit => new StatementNode(hit.Left.Down));
            ParseAction<StatementNode> action16 = action14.Or<StatementNode>(action15);
            ParseAction<string> action17 = CharGrammar.Ch('#').And<char, IList<char>>(Grammar.Rep<char>(CharGrammar.Ch(new Func<char, bool>(char.IsLetterOrDigit)).Or<char>(CharGrammar.Ch(new char[] { '-', '_' })))).Skip<Chain<char, IList<char>>, IList<char>>(action5).Build<Chain<char, IList<char>>, string>(hit => new string(hit.Down.ToArray<char>()));
            ParseAction<string> action18 = CharGrammar.Ch('.').And<char, IList<char>>(Grammar.Rep<char>(CharGrammar.Ch(new Func<char, bool>(char.IsLetterOrDigit)).Or<char>(CharGrammar.Ch(new char[] { '-', '_' })))).Skip<Chain<char, IList<char>>, IList<char>>(action5).Build<Chain<char, IList<char>>, string>(hit => new string(hit.Down.ToArray<char>()));
            var action19 = Grammar.Rep<string>(action18).And<IList<string>, string>(Grammar.Opt<string>(action17)).And<Chain<IList<string>, string>, IList<string>>(Grammar.Rep<string>(action18)).Build(hit => new { id = hit.Left.Down, classes = hit.Left.Left.Concat<string>(hit.Down) });
            var action20 = Grammar.Rep<string>(action18).And<IList<string>, string>(action17).And<Chain<IList<string>, string>, IList<string>>(Grammar.Rep<string>(action18)).Or<Chain<Chain<IList<string>, string>, IList<string>>>(Grammar.Rep1<string>(action18).And<IList<string>, string>(Grammar.Opt<string>(action17)).And<Chain<IList<string>, string>, IList<string>>(Grammar.Rep<string>(action18))).Or<Chain<Chain<IList<string>, string>, IList<string>>>(Grammar.Rep<string>(action18).And<IList<string>, string>(Grammar.Opt<string>(action17)).And<Chain<IList<string>, string>, IList<string>>(Grammar.Rep1<string>(action18))).Build(hit => new { id = hit.Left.Down, classes = hit.Left.Left.Concat<string>(hit.Down) });
            ParseAction<ElementNode> action22 = action8.Skip<string, IList<char>>(action5).And(action19).Or(Grammar.Opt<string>(action8).And(action20)).Build(hit => new { name = hit.Left ?? "div", attrs = ((hit.Down.id != null) ? new AttributeNode[] { new AttributeNode("id", hit.Down.id) } : new AttributeNode[0]).Concat<AttributeNode>(hit.Down.classes.Any<string>() ? new AttributeNode[] { new AttributeNode("class", string.Join(" ", hit.Down.classes.ToArray<string>())) } : new AttributeNode[0]) }).And(Grammar.Rep<AttributeNode>(base.Attribute.Skip<AttributeNode, IList<char>>(action5))).Build(hit => new ElementNode(hit.Left.name, hit.Left.attrs.Concat<AttributeNode>(hit.Down).ToList<AttributeNode>(), false));
            ParseAction<IList<Node>> action23 = action12.Or<IList<Node>>(action13.Build<ExpressionNode, IList<Node>>(hit => ((IList<Node>) new Node[] { hit }))).Or<IList<Node>>(action16.Build<StatementNode, IList<Node>>(hit => (IList<Node>) new Node[] { hit }));
            ParseAction<Chain<ElementNode, IList<Node>>> action24 = action22.Skip<ElementNode, IList<char>>(action5).And<ElementNode, IList<Node>>(Grammar.Opt<IList<Node>>(action23));
            ParseAction<Node[]> action25 = action4.And<IndentationNode, Chain<ElementNode, IList<Node>>>(action24).Build<Chain<IndentationNode, Chain<ElementNode, IList<Node>>>, Node[]>(hit => new Node[] { hit.Left, hit.Down.Left }.Concat<Node>((hit.Down.Down ?? ((IList<Node>) new Node[0]))).ToArray<Node>());
            ParseAction<Node[]> action26 = action4.And<IndentationNode, IList<Node>>(action12).Build<Chain<IndentationNode, IList<Node>>, Node[]>(hit => new Node[] { hit.Left }.Concat<Node>(hit.Down).ToArray<Node>());
            ParseAction<Node[]> action27 = action4.And<IndentationNode, ExpressionNode>(action13).Build<Chain<IndentationNode, ExpressionNode>, Node[]>(hit => new Node[] { hit.Left, hit.Down });
            ParseAction<Node[]> action28 = action4.And<IndentationNode, StatementNode>(action16).Build<Chain<IndentationNode, StatementNode>, Node[]>(hit => new Node[] { hit.Left, hit.Down });
            ParseAction<Node[]> action29 = action24.Build<Chain<ElementNode, IList<Node>>, Node[]>(hit => new Node[] { hit.Left }.Concat<Node>((hit.Down ?? ((IList<Node>) new Node[0]))).ToArray<Node>());
            ParseAction<Node[]> action30 = action6.Or<Node[]>(action25).Or<Node[]>(action26).Or<Node[]>(action27).Or<Node[]>(action28).Or<Node[]>(action29).Skip<Node[], IList<char>>(action5);
            ParseAction<IList<Node[]>> action31 = Grammar.Rep<Node[]>(action30);
            this.Indentation = action4;
            this.TestLine = action30;
            this.OffsetElement = action22;
            this.OffsetText = action9;
            this.OffsetTexts = action12;
            this.OffsetExpression = action13;
            this.OffsetStatement = action16;
            this.OffsetNodes = action31.Build<IList<Node[]>, IList<Node>>(hit => (from nodes in hit select from node in nodes
                where node != null
                select node).ToList<Node>());
        }
    }
}

