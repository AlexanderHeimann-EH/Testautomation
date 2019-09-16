namespace Spark.Compiler.NodeVisitors
{
    using Spark.Bindings;
    using Spark.Compiler;
    using Spark.Parser.Code;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class BindingExpansionVisitor : NodeVisitor<BindingExpansionVisitor.Frame>
    {
        public BindingExpansionVisitor(VisitorContext context) : base(context)
        {
        }

        private static IEnumerable<BindingNode> AllNodes(Binding binding)
        {
            return (from p in binding.Phrases select p.Nodes);
        }

        private void BeginBinding(ElementNode element, Binding binding)
        {
            if (binding.HasChildReference)
            {
                string code = string.Format("{{var __bindingWriter{0} = new System.IO.StringWriter(); using(OutputScope(__bindingWriter{0})) {{", base.FrameData.NestingLevel);
                base.Accept(new StatementNode(code));
            }
            else
            {
                BindingPhrase phrase = binding.Phrases.First<BindingPhrase>();
                this.ProcessPhrase(binding, phrase, element);
            }
            Frame frameData = new Frame {
                Binding = binding,
                Element = element,
                NestingLevel = base.FrameData.NestingLevel + 1
            };
            base.PushFrame(this.Nodes, frameData);
        }

        private IEnumerable<Snippet> BuildSnippets(BindingChildReference literal)
        {
            Snippet[] snippetArray = new Snippet[1];
            Snippet snippet = new Snippet {
                Value = "__bindingWriter" + base.FrameData.NestingLevel + ".ToString()"
            };
            snippetArray[0] = snippet;
            return snippetArray;
        }

        private static IEnumerable<Snippet> BuildSnippets(BindingLiteral literal)
        {
            Snippet[] snippetArray = new Snippet[1];
            Snippet snippet = new Snippet {
                Value = literal.Text
            };
            snippetArray[0] = snippet;
            return snippetArray;
        }

        private static IEnumerable<Snippet> BuildSnippets(BindingNameReference reference, ElementNode element)
        {
            IEnumerable<AttributeNode> enumerable = from attr in element.Attributes
                where attr.Name == reference.Name
                select attr;
            if (reference.AssumeStringValue)
            {
                ExpressionBuilder builder = new ExpressionBuilder();
                PopulateBuilder(from attr in enumerable select attr.Nodes, builder);
                Snippet[] snippetArray = new Snippet[1];
                Snippet snippet = new Snippet {
                    Value = builder.ToCode()
                };
                snippetArray[0] = snippet;
                return snippetArray;
            }
            return (from attr in enumerable select attr.AsCode());
        }

        private static IEnumerable<Snippet> BuildSnippets(Binding binding, BindingPrefixReference prefix, ElementNode element)
        {
            var enumerable3 = from attr in element.Attributes
                where attr.Name.StartsWith(prefix.Prefix ?? "")
                where !AllNodes(binding).Any<BindingNode>(compare => TestBetterMatch(attr.Name, prefix.Prefix, compare))
                select new { PropertyName = attr.Name.Substring((prefix.Prefix ?? "").Length), Attribute = attr };
            List<Snippet> list = new List<Snippet>();
            if (prefix.AssumeDictionarySyntax)
            {
                Snippet item = new Snippet {
                    Value = "{"
                };
                list.Add(item);
            }
            bool flag = true;
            foreach (var type in enumerable3)
            {
                if (flag)
                {
                    flag = false;
                }
                else
                {
                    Snippet snippet = new Snippet {
                        Value = ","
                    };
                    list.Add(snippet);
                }
                if (prefix.AssumeDictionarySyntax)
                {
                    Snippet snippet3 = new Snippet {
                        Value = "{\"" + type.PropertyName + "\","
                    };
                    list.Add(snippet3);
                }
                else
                {
                    Snippet snippet4 = new Snippet {
                        Value = type.PropertyName + "="
                    };
                    list.Add(snippet4);
                }
                if (prefix.AssumeStringValue)
                {
                    ExpressionBuilder builder = new ExpressionBuilder();
                    PopulateBuilder(type.Attribute.Nodes, builder);
                    Snippet snippet2 = new Snippet {
                        Value = builder.ToCode()
                    };
                    list.Add(snippet2);
                }
                else
                {
                    list.AddRange(type.Attribute.AsCode());
                }
                if (prefix.AssumeDictionarySyntax)
                {
                    Snippet snippet5 = new Snippet {
                        Value = "}"
                    };
                    list.Add(snippet5);
                }
            }
            if (prefix.AssumeDictionarySyntax)
            {
                Snippet snippet7 = new Snippet {
                    Value = "}"
                };
                list.Add(snippet7);
            }
            return list;
        }

        private IEnumerable<Snippet> BuildSnippetsForNode(Binding binding, BindingNode node, ElementNode element)
        {
            if (node is BindingLiteral)
            {
                return BuildSnippets(node as BindingLiteral);
            }
            if (node is BindingNameReference)
            {
                return BuildSnippets(node as BindingNameReference, element);
            }
            if (node is BindingPrefixReference)
            {
                return BuildSnippets(binding, node as BindingPrefixReference, element);
            }
            if (!(node is BindingChildReference))
            {
                throw new CompilerException("Binding node type " + node.GetType() + " not understood");
            }
            return this.BuildSnippets(node as BindingChildReference);
        }

        private void EndBinding()
        {
            ElementNode element = base.FrameData.Element;
            Binding binding = base.FrameData.Binding;
            base.PopFrame();
            if (binding.HasChildReference || (binding.Phrases.Count<BindingPhrase>() == 2))
            {
                if (binding.HasChildReference)
                {
                    base.Accept(new StatementNode("}"));
                }
                this.ProcessPhrase(binding, binding.Phrases.Last<BindingPhrase>(), element);
                if (binding.HasChildReference)
                {
                    base.Accept(new StatementNode("}"));
                }
            }
        }

        private Binding MatchElementBinding(ElementNode node)
        {
            if (base.Context.Bindings == null)
            {
                return null;
            }
            return (from binding in base.Context.Bindings
                where binding.ElementName == node.Name
                where RequiredReferencesSatisfied(binding, node)
                select binding).FirstOrDefault<Binding>();
        }

        private static void PopulateBuilder(IEnumerable<Node> nodes, ExpressionBuilder builder)
        {
            foreach (Node node in nodes)
            {
                if (node is TextNode)
                {
                    TextNode node2 = (TextNode) node;
                    builder.AppendLiteral(node2.Text);
                }
                else if (!(node is EntityNode))
                {
                    if (!(node is ExpressionNode))
                    {
                        throw new CompilerException("Unknown content in attribute");
                    }
                    ExpressionNode node4 = (ExpressionNode) node;
                    builder.AppendExpression(node4.Code);
                }
                else
                {
                    EntityNode node3 = (EntityNode) node;
                    builder.AppendLiteral("&" + node3.Name + ";");
                }
            }
        }

        private void ProcessPhrase(Binding binding, BindingPhrase phrase, ElementNode element)
        {
            IEnumerable<Snippet> code = from bindingNode in phrase.Nodes select this.BuildSnippetsForNode(binding, bindingNode, element);
            if (phrase.Type == BindingPhrase.PhraseType.Expression)
            {
                base.Accept(new ExpressionNode(code));
            }
            else
            {
                if (phrase.Type != BindingPhrase.PhraseType.Statement)
                {
                    throw new CompilerException("Unknown binding phrase type " + phrase.Type);
                }
                base.Accept(new StatementNode(code));
            }
        }

        private static bool RequiredReferencesSatisfied(Binding binding, ElementNode element)
        {
            foreach (BindingNameReference reference in AllNodes(binding).OfType<BindingNameReference>())
            {
                BindingNameReference nameReference = reference;
                if (!element.Attributes.Any<AttributeNode>(attr => (attr.Name == nameReference.Name)))
                {
                    return false;
                }
            }
            if (binding.HasChildReference && element.IsEmptyElement)
            {
                return false;
            }
            return true;
        }

        private static bool TestBetterMatch(string attributeName, string matchingPrefix, BindingNode compareNode)
        {
            if (compareNode is BindingNameReference)
            {
                BindingNameReference reference = (BindingNameReference) compareNode;
                if (attributeName == reference.Name)
                {
                    return true;
                }
            }
            if (compareNode is BindingPrefixReference)
            {
                string str = matchingPrefix ?? "";
                string str2 = ((BindingPrefixReference) compareNode).Prefix ?? "";
                if ((str2.Length > str.Length) && attributeName.StartsWith(str2))
                {
                    return true;
                }
            }
            return false;
        }

        protected override void Visit(ElementNode element)
        {
            Binding binding = this.MatchElementBinding(element);
            if (binding == null)
            {
                if ((!element.IsEmptyElement && (base.FrameData.Binding != null)) && (base.FrameData.Binding.ElementName == element.Name))
                {
                    Frame frameData = base.FrameData;
                    frameData.RedundantDepth++;
                }
                base.Visit(element);
            }
            else
            {
                this.BeginBinding(element, binding);
                if (element.IsEmptyElement)
                {
                    this.EndBinding();
                }
            }
        }

        protected override void Visit(EndElementNode endElement)
        {
            if ((base.FrameData.Binding != null) && (base.FrameData.Binding.ElementName == endElement.Name))
            {
                int num;
                Frame frameData = base.FrameData;
                frameData.RedundantDepth = (num = frameData.RedundantDepth) - 1;
                if (num == 0)
                {
                    this.EndBinding();
                    return;
                }
            }
            base.Visit(endElement);
        }

        public class Frame
        {
            public Spark.Bindings.Binding Binding { get; set; }

            public ElementNode Element { get; set; }

            public int NestingLevel { get; set; }

            public int RedundantDepth { get; set; }
        }
    }
}

