namespace Spark.Compiler.NodeVisitors
{
    using Spark;
    using Spark.Compiler;
    using Spark.Parser;
    using Spark.Parser.Code;
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class ChunkBuilderVisitor : AbstractNodeVisitor
    {
        private readonly IDictionary<Node, Paint<Node>> _nodePaint;
        private Chunk _sendAttributeIncrement;
        private ConditionalChunk _sendAttributeOnce;
        private readonly IDictionary<string, Action<SpecialNode, SpecialNodeInspector>> _specialNodeMap;

        public ChunkBuilderVisitor(VisitorContext context) : base(context)
        {
            Action<SpecialNode, SpecialNodeInspector> action = null;
            Action<SpecialNode, SpecialNodeInspector> action2 = null;
            Action<SpecialNode, SpecialNodeInspector> action3 = null;
            Action<SpecialNode, SpecialNodeInspector> action4 = null;
            Action<SpecialNode, SpecialNodeInspector> action5 = null;
            Action<SpecialNode, SpecialNodeInspector> action6 = null;
            this._nodePaint = base.Context.Paint.OfType<Paint<Node>>().ToDictionary<Paint<Node>, Node>(paint => paint.Value);
            this.Chunks = new List<Chunk>();
            Dictionary<string, Action<SpecialNode, SpecialNodeInspector>> dictionary = new Dictionary<string, Action<SpecialNode, SpecialNodeInspector>>();
            dictionary.Add("var", new Action<SpecialNode, SpecialNodeInspector>(this.VisitVar));
            dictionary.Add("def", new Action<SpecialNode, SpecialNodeInspector>(this.VisitVar));
            dictionary.Add("default", new Action<SpecialNode, SpecialNodeInspector>(this.VisitDefault));
            if (action == null)
            {
                action = (n, i) => this.VisitGlobal(n);
            }
            dictionary.Add("global", action);
            if (action2 == null)
            {
                action2 = (n, i) => this.VisitViewdata(i);
            }
            dictionary.Add("viewdata", action2);
            if (action3 == null)
            {
                action3 = (n, i) => this.VisitSet(i);
            }
            dictionary.Add("set", action3);
            dictionary.Add("for", new Action<SpecialNode, SpecialNodeInspector>(this.VisitFor));
            dictionary.Add("test", new Action<SpecialNode, SpecialNodeInspector>(this.VisitIf));
            dictionary.Add("if", new Action<SpecialNode, SpecialNodeInspector>(this.VisitIf));
            if (action4 == null)
            {
                action4 = (n, i) => this.VisitElse(i);
            }
            dictionary.Add("else", action4);
            dictionary.Add("elseif", new Action<SpecialNode, SpecialNodeInspector>(this.VisitElseIf));
            dictionary.Add("unless", new Action<SpecialNode, SpecialNodeInspector>(this.VisitUnless));
            if (action5 == null)
            {
                action5 = (n, i) => this.VisitContent(i);
            }
            dictionary.Add("content", action5);
            dictionary.Add("use", new Action<SpecialNode, SpecialNodeInspector>(this.VisitUse));
            if (action6 == null)
            {
                action6 = (n, i) => this.VisitMacro(i);
            }
            dictionary.Add("macro", action6);
            dictionary.Add("render", new Action<SpecialNode, SpecialNodeInspector>(this.VisitRender));
            dictionary.Add("segment", new Action<SpecialNode, SpecialNodeInspector>(this.VisitSection));
            dictionary.Add("cache", new Action<SpecialNode, SpecialNodeInspector>(this.VisitCache));
            dictionary.Add("markdown", new Action<SpecialNode, SpecialNodeInspector>(this.VisitMarkdown));
            dictionary.Add("ignore", new Action<SpecialNode, SpecialNodeInspector>(this.VisitIgnore));
            this._specialNodeMap = dictionary;
            if (context.ParseSectionTagAsSegment)
            {
                this._specialNodeMap.Add("section", new Action<SpecialNode, SpecialNodeInspector>(this.VisitSection));
            }
        }

        private void AddLiteral(string text)
        {
            SendLiteralChunk item = this.Chunks.LastOrDefault<Chunk>() as SendLiteralChunk;
            if (item == null)
            {
                item = new SendLiteralChunk {
                    Text = text
                };
                this.Chunks.Add(item);
            }
            else
            {
                item.Text = item.Text + text;
            }
        }

        private void AddUnordered(Chunk chunk)
        {
            if (!(this.Chunks.LastOrDefault<Chunk>() is SendLiteralChunk))
            {
                this.Chunks.Add(chunk);
            }
            else
            {
                this.Chunks.Insert(this.Chunks.Count - 1, chunk);
            }
        }

        private Snippets AsCode(AttributeNode attr)
        {
            Position begin = this.Locate(attr.Nodes.FirstOrDefault<Node>());
            Position end = this.LocateEnd(attr.Nodes.LastOrDefault<Node>());
            if ((begin == null) || (end == null))
            {
                begin = new Position(new SourceContext(attr.Value));
                end = begin.Advance(begin.PotentialLength());
            }
            return base.Context.SyntaxProvider.ParseFragment(begin, end);
        }

        private Snippets AsTextOrientedCode(AttributeNode attr)
        {
            if (base.Context.AttributeBehaviour != AttributeBehaviour.CodeOriented)
            {
                return attr.AsCodeInverted();
            }
            return this.AsCode(attr);
        }

        private Position Locate(Node expressionNode)
        {
            for (Node node = expressionNode; node != null; node = node.OriginalNode)
            {
                Paint<Node> paint;
                if (this._nodePaint.TryGetValue(node, out paint))
                {
                    return paint.Begin;
                }
            }
            return null;
        }

        private Position LocateEnd(Node expressionNode)
        {
            for (Node node = expressionNode; node != null; node = node.OriginalNode)
            {
                Paint<Node> paint;
                if (this._nodePaint.TryGetValue(node, out paint))
                {
                    return paint.End;
                }
            }
            return null;
        }

        private static void MovePriorNodesUnderCondition(ConditionNode condition, ICollection<Node> priorNodes)
        {
            while (priorNodes.Count != 0)
            {
                string text;
                int num;
                Node item = priorNodes.Last<Node>();
                priorNodes.Remove(item);
                if (item is TextNode)
                {
                    text = ((TextNode) item).Text;
                    num = text.LastIndexOfAny(new char[] { ' ', '\t', '\r', '\n' }) + 1;
                    if (num != 0)
                    {
                        goto Label_006A;
                    }
                    condition.Nodes.Insert(0, item);
                }
                else
                {
                    condition.Nodes.Insert(0, item);
                }
                continue;
            Label_0066:
                num--;
            Label_006A:
                if ((num != 0) && char.IsWhiteSpace(text[num - 1]))
                {
                    goto Label_0066;
                }
                TextNode node3 = new TextNode(text.Substring(num)) {
                    OriginalNode = item
                };
                condition.Nodes.Insert(0, node3);
                if (num != 0)
                {
                    TextNode node2 = new TextNode(text.Substring(0, num)) {
                        OriginalNode = item
                    };
                    priorNodes.Add(node2);
                }
                return;
            }
        }

        private bool SatisfyElsePrecondition()
        {
            Chunk item = this.Chunks.LastOrDefault<Chunk>();
            if ((item is SendLiteralChunk) && string.IsNullOrEmpty(((SendLiteralChunk) item).Text.Trim()))
            {
                this.Chunks.Remove(item);
                item = this.Chunks.LastOrDefault<Chunk>();
            }
            if (item is ConditionalChunk)
            {
                switch (((ConditionalChunk) item).Type)
                {
                    case ConditionalType.If:
                    case ConditionalType.ElseIf:
                        return true;
                }
            }
            return false;
        }

        private static string UnarmorCode(string code)
        {
            return code.Replace("[[", "<").Replace("]]", ">");
        }

        protected override void Visit(AttributeNode attributeNode)
        {
            List<Node> priorNodes = new List<Node>();
            List<Node> source = new List<Node>();
            foreach (Node node in attributeNode.Nodes)
            {
                if (node is ConditionNode)
                {
                    ConditionNode condition = (ConditionNode) node;
                    MovePriorNodesUnderCondition(condition, priorNodes);
                    source.AddRange(priorNodes);
                    source.Add(condition);
                    priorNodes.Clear();
                }
                else
                {
                    priorNodes.Add(node);
                }
            }
            source.AddRange(priorNodes);
            if (!source.All<Node>(node => (node is ConditionNode)) || !source.Any<Node>())
            {
                this.AddLiteral(string.Format(" {0}={1}", attributeNode.Name, attributeNode.QuotChar));
                foreach (Node node3 in source)
                {
                    base.Accept(node3);
                }
                this.AddLiteral(attributeNode.QuotChar.ToString());
            }
            else
            {
                ScopeChunk item = new ScopeChunk();
                LocalVariableChunk chunk3 = new LocalVariableChunk {
                    Name = "__just__once__",
                    Value = new Snippets("0")
                };
                item.Body.Add(chunk3);
                ConditionalChunk chunk4 = new ConditionalChunk {
                    Type = ConditionalType.If,
                    Condition = new Snippets("__just__once__ < 1")
                };
                this._sendAttributeOnce = chunk4;
                SendLiteralChunk chunk5 = new SendLiteralChunk {
                    Text = " " + attributeNode.Name + "=\""
                };
                this._sendAttributeOnce.Body.Add(chunk5);
                AssignVariableChunk chunk6 = new AssignVariableChunk {
                    Name = "__just__once__",
                    Value = "1"
                };
                this._sendAttributeIncrement = chunk6;
                this.Chunks.Add(item);
                using (new Frame(this, item.Body))
                {
                    foreach (Node node4 in source)
                    {
                        base.Accept(node4);
                    }
                }
                this._sendAttributeOnce = null;
                this._sendAttributeIncrement = null;
                ConditionalChunk chunk2 = new ConditionalChunk {
                    Type = ConditionalType.If,
                    Condition = new Snippets("__just__once__ > 0")
                };
                item.Body.Add(chunk2);
                SendLiteralChunk chunk8 = new SendLiteralChunk {
                    Text = "\""
                };
                chunk2.Body.Add(chunk8);
            }
        }

        protected override void Visit(CommentNode commentNode)
        {
            this.AddLiteral("<!--" + commentNode.Text + "-->");
        }

        protected override void Visit(ConditionNode conditionNode)
        {
            ConditionalChunk item = new ConditionalChunk {
                Condition = conditionNode.Code,
                Type = ConditionalType.If,
                Position = this.Locate(conditionNode)
            };
            this.Chunks.Add(item);
            if (this._sendAttributeOnce != null)
            {
                item.Body.Add(this._sendAttributeOnce);
            }
            if (this._sendAttributeIncrement != null)
            {
                item.Body.Add(this._sendAttributeIncrement);
            }
            using (new Frame(this, item.Body))
            {
                base.Accept(conditionNode.Nodes);
            }
        }

        protected override void Visit(DoctypeNode docTypeNode)
        {
            if (docTypeNode.ExternalId == null)
            {
                this.AddLiteral(string.Format("<!DOCTYPE {0}>", docTypeNode.Name));
            }
            else if (docTypeNode.ExternalId.ExternalIdType == "SYSTEM")
            {
                char ch = docTypeNode.ExternalId.SystemId.Contains("\"") ? '\'' : '"';
                this.AddLiteral(string.Format("<!DOCTYPE {0} SYSTEM {2}{1}{2}>", docTypeNode.Name, docTypeNode.ExternalId.SystemId, ch));
            }
            else if (docTypeNode.ExternalId.ExternalIdType == "PUBLIC")
            {
                char ch2 = docTypeNode.ExternalId.SystemId.Contains("\"") ? '\'' : '"';
                this.AddLiteral(string.Format("<!DOCTYPE {0} PUBLIC \"{1}\" {3}{2}{3}>", new object[] { docTypeNode.Name, docTypeNode.ExternalId.PublicId, docTypeNode.ExternalId.SystemId, ch2 }));
            }
        }

        protected override void Visit(ElementNode node)
        {
            this.AddLiteral(node.PreceedingWhitespace + "<" + node.Name);
            foreach (AttributeNode node2 in node.Attributes)
            {
                base.Accept(node2);
            }
            this.AddLiteral(node.IsEmptyElement ? "/>" : ">");
        }

        protected override void Visit(EndElementNode node)
        {
            this.AddLiteral(node.PreceedingWhitespace + "</" + node.Name + ">");
        }

        protected override void Visit(EntityNode entityNode)
        {
            this.AddLiteral("&" + entityNode.Name + ";");
        }

        protected override void Visit(ExpressionNode node)
        {
            SendExpressionChunk item = new SendExpressionChunk {
                Code = node.Code,
                Position = this.Locate(node),
                SilentNulls = node.SilentNulls,
                AutomaticallyEncode = node.AutomaticEncoding
            };
            this.Chunks.Add(item);
        }

        protected override void Visit(ExtensionNode extensionNode)
        {
            ExtensionChunk item = new ExtensionChunk {
                Extension = extensionNode.Extension,
                Position = this.Locate(extensionNode)
            };
            this.Chunks.Add(item);
            using (new Frame(this, item.Body))
            {
                extensionNode.Extension.VisitNode(this, extensionNode.Body, this.Chunks);
            }
        }

        protected override void Visit(IndentationNode node)
        {
        }

        protected override void Visit(ProcessingInstructionNode node)
        {
            if (string.IsNullOrEmpty(node.Body))
            {
                this.AddLiteral("<?" + node.Name + "?>");
            }
            else
            {
                this.AddLiteral("<?" + node.Name + " " + node.Body + "?>");
            }
        }

        protected override void Visit(SpecialNode specialNode)
        {
            string name = NameUtility.GetName(specialNode.Element.Name);
            if (!this.SpecialNodeMap.ContainsKey(name))
            {
                throw new CompilerException(string.Format("Unknown special node {0}", specialNode.Element.Name));
            }
            Action<SpecialNode, SpecialNodeInspector> action = this.SpecialNodeMap[name];
            action(specialNode, new SpecialNodeInspector(specialNode));
        }

        protected override void Visit(StatementNode node)
        {
            CodeStatementChunk item = new CodeStatementChunk {
                Code = node.Code,
                Position = this.Locate(node)
            };
            this.Chunks.Add(item);
        }

        protected override void Visit(TextNode textNode)
        {
            this.AddLiteral(textNode.Text);
        }

        protected override void Visit(XMLDeclNode node)
        {
            string str = "";
            if (!string.IsNullOrEmpty(node.Encoding))
            {
                if (node.Encoding.Contains("\""))
                {
                    str = " encoding='" + node.Encoding + "'";
                }
                else
                {
                    str = " encoding=\"" + node.Encoding + "\"";
                }
            }
            string str2 = "";
            if (!string.IsNullOrEmpty(node.Standalone))
            {
                str2 = " standalone=\"" + node.Standalone + "\"";
            }
            this.AddLiteral("<?xml version=\"1.0\"" + str + str2 + " ?>");
        }

        private void VisitCache(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            AttributeNode attr = inspector.TakeAttribute("key");
            AttributeNode node2 = inspector.TakeAttribute("expires");
            AttributeNode node3 = inspector.TakeAttribute("signal");
            CacheChunk item = new CacheChunk {
                Position = this.Locate(specialNode.Element)
            };
            if (attr != null)
            {
                item.Key = this.AsCode(attr);
            }
            else
            {
                item.Key = "\"\"";
            }
            if (node2 != null)
            {
                item.Expires = this.AsCode(node2);
            }
            else
            {
                item.Expires = "";
            }
            if (node3 != null)
            {
                item.Signal = this.AsCode(node3);
            }
            else
            {
                item.Signal = "";
            }
            this.Chunks.Add(item);
            using (new Frame(this, item.Body))
            {
                base.Accept(inspector.Body);
            }
        }

        private void VisitContent(SpecialNodeInspector inspector)
        {
            AttributeNode node = inspector.TakeAttribute("name");
            AttributeNode node2 = inspector.TakeAttribute("var");
            AttributeNode node3 = inspector.TakeAttribute("def");
            AttributeNode attr = inspector.TakeAttribute("set");
            if (node != null)
            {
                ContentChunk item = new ContentChunk {
                    Name = node.Value,
                    Position = this.Locate(inspector.OriginalNode)
                };
                this.Chunks.Add(item);
                using (new Frame(this, item.Body))
                {
                    base.Accept(inspector.Body);
                    return;
                }
            }
            if ((node2 != null) || (node3 != null))
            {
                LocalVariableChunk chunk3 = new LocalVariableChunk {
                    Name = this.AsCode(node2 ?? node3),
                    Type = "string"
                };
                this.Chunks.Add(chunk3);
                ContentSetChunk chunk4 = new ContentSetChunk {
                    Variable = chunk3.Name,
                    Position = this.Locate(inspector.OriginalNode)
                };
                this.Chunks.Add(chunk4);
                using (new Frame(this, chunk4.Body))
                {
                    base.Accept(inspector.Body);
                    return;
                }
            }
            if (attr != null)
            {
                AttributeNode node5 = inspector.TakeAttribute("add");
                ContentSetChunk chunk7 = new ContentSetChunk {
                    Variable = this.AsCode(attr),
                    Position = this.Locate(inspector.OriginalNode)
                };
                if (node5 != null)
                {
                    if (node5.Value != "before")
                    {
                        if (node5.Value != "after")
                        {
                            if (node5.Value != "replace")
                            {
                                throw new CompilerException("add attribute must be 'before', 'after', or 'replace");
                            }
                            chunk7.AddType = ContentAddType.Replace;
                        }
                        else
                        {
                            chunk7.AddType = ContentAddType.AppendAfter;
                        }
                    }
                    else
                    {
                        chunk7.AddType = ContentAddType.InsertBefore;
                    }
                }
                this.Chunks.Add(chunk7);
                using (new Frame(this, chunk7.Body))
                {
                    base.Accept(inspector.Body);
                    return;
                }
            }
            throw new CompilerException("content element must have name, var, def, or set attribute");
        }

        private void VisitDefault(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            Frame frame = null;
            if (!specialNode.Element.IsEmptyElement)
            {
                ScopeChunk item = new ScopeChunk {
                    Position = this.Locate(specialNode.Element)
                };
                this.Chunks.Add(item);
                frame = new Frame(this, item.Body);
            }
            AttributeNode attr = inspector.TakeAttribute("type");
            Snippets snippets = (attr != null) ? this.AsCode(attr) : "var";
            foreach (AttributeNode node2 in inspector.Attributes)
            {
                DefaultVariableChunk chunk3 = new DefaultVariableChunk {
                    Type = snippets,
                    Name = node2.Name,
                    Value = this.AsTextOrientedCode(node2),
                    Position = this.Locate(node2)
                };
                this.Chunks.Add(chunk3);
            }
            base.Accept(specialNode.Body);
            if (frame != null)
            {
                frame.Dispose();
            }
        }

        private void VisitElse(SpecialNodeInspector inspector)
        {
            if (!this.SatisfyElsePrecondition())
            {
                throw new CompilerException("An 'else' may only follow an 'if' or 'elseif'.");
            }
            AttributeNode attr = inspector.TakeAttribute("if");
            if (attr == null)
            {
                ConditionalChunk chunk = new ConditionalChunk {
                    Type = ConditionalType.Else,
                    Position = this.Locate(inspector.OriginalNode)
                };
                this.Chunks.Add(chunk);
                using (new Frame(this, chunk.Body))
                {
                    base.Accept(inspector.Body);
                    return;
                }
            }
            ConditionalChunk item = new ConditionalChunk {
                Type = ConditionalType.ElseIf,
                Condition = this.AsCode(attr),
                Position = this.Locate(inspector.OriginalNode)
            };
            this.Chunks.Add(item);
            using (new Frame(this, item.Body))
            {
                base.Accept(inspector.Body);
            }
        }

        private void VisitElseIf(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            if (!this.SatisfyElsePrecondition())
            {
                throw new CompilerException("An 'elseif' may only follow an 'if' or 'elseif'.");
            }
            AttributeNode attr = inspector.TakeAttribute("condition");
            ConditionalChunk item = new ConditionalChunk {
                Type = ConditionalType.ElseIf,
                Condition = this.AsCode(attr),
                Position = this.Locate(inspector.OriginalNode)
            };
            this.Chunks.Add(item);
            using (new Frame(this, item.Body))
            {
                base.Accept(specialNode.Body);
            }
        }

        private void VisitFor(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            AttributeNode attr = inspector.TakeAttribute("each");
            ForEachChunk item = new ForEachChunk {
                Code = this.AsCode(attr),
                Position = this.Locate(specialNode.Element)
            };
            this.Chunks.Add(item);
            using (new Frame(this, item.Body))
            {
                foreach (AttributeNode node2 in inspector.Attributes)
                {
                    AssignVariableChunk chunk2 = new AssignVariableChunk {
                        Name = node2.Name,
                        Value = this.AsCode(node2),
                        Position = this.Locate(node2)
                    };
                    this.Chunks.Add(chunk2);
                }
                base.Accept(specialNode.Body);
            }
        }

        private void VisitGlobal(SpecialNode specialNode)
        {
            AttributeNode typeAttr = specialNode.Element.Attributes.FirstOrDefault<AttributeNode>(attr => attr.Name == "type");
            Snippets snippets = (typeAttr != null) ? this.AsCode(typeAttr) : "object";
            foreach (AttributeNode node in from a in specialNode.Element.Attributes
                where a != typeAttr
                select a)
            {
                GlobalVariableChunk chunk = new GlobalVariableChunk {
                    Type = snippets,
                    Name = node.Name,
                    Value = this.AsTextOrientedCode(node)
                };
                this.AddUnordered(chunk);
            }
        }

        private void VisitIf(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            AttributeNode attr = inspector.TakeAttribute("condition") ?? inspector.TakeAttribute("if");
            AttributeNode node2 = inspector.TakeAttribute("once");
            if ((attr == null) && (node2 == null))
            {
                throw new CompilerException("Element must contain an if, condition, or once attribute");
            }
            Frame frame = null;
            if (attr != null)
            {
                ConditionalChunk item = new ConditionalChunk {
                    Type = ConditionalType.If,
                    Condition = this.AsCode(attr),
                    Position = this.Locate(inspector.OriginalNode)
                };
                this.Chunks.Add(item);
                frame = new Frame(this, item.Body);
            }
            Frame frame2 = null;
            if (node2 != null)
            {
                ConditionalChunk chunk3 = new ConditionalChunk {
                    Type = ConditionalType.Once,
                    Condition = node2.AsCodeInverted(),
                    Position = this.Locate(inspector.OriginalNode)
                };
                this.Chunks.Add(chunk3);
                frame2 = new Frame(this, chunk3.Body);
            }
            base.Accept(specialNode.Body);
            if (frame2 != null)
            {
                frame2.Dispose();
            }
            if (frame != null)
            {
                frame.Dispose();
            }
        }

        private void VisitIgnore(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            base.Accept(specialNode.Body);
        }

        private void VisitMacro(SpecialNodeInspector inspector)
        {
            AttributeNode node = inspector.TakeAttribute("name");
            MacroChunk chunk = new MacroChunk {
                Name = node.Value,
                Position = this.Locate(inspector.OriginalNode)
            };
            foreach (AttributeNode node2 in inspector.Attributes)
            {
                MacroParameter item = new MacroParameter {
                    Name = node2.Name,
                    Type = this.AsCode(node2)
                };
                chunk.Parameters.Add(item);
            }
            this.AddUnordered(chunk);
            using (new Frame(this, chunk.Body))
            {
                base.Accept(inspector.Body);
            }
        }

        private void VisitMarkdown(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            MarkdownChunk item = new MarkdownChunk();
            this.Chunks.Add(item);
            using (new Frame(this, item.Body))
            {
                base.Accept(inspector.Body);
            }
        }

        private void VisitRender(SpecialNode node, SpecialNodeInspector inspector)
        {
            AttributeNode node2 = inspector.TakeAttribute("partial");
            if (node2 != null)
            {
                ScopeChunk chunk = new ScopeChunk {
                    Position = this.Locate(inspector.OriginalNode)
                };
                this.Chunks.Add(chunk);
                using (new Frame(this, chunk.Body))
                {
                    foreach (AttributeNode node3 in inspector.Attributes)
                    {
                        LocalVariableChunk chunk2 = new LocalVariableChunk {
                            Name = node3.Name,
                            Value = this.AsTextOrientedCode(node3),
                            Position = this.Locate(node3)
                        };
                        this.Chunks.Add(chunk2);
                    }
                    RenderPartialChunk chunk3 = new RenderPartialChunk {
                        Name = node2.Value,
                        Position = this.Locate(inspector.OriginalNode)
                    };
                    this.Chunks.Add(chunk3);
                    using (new Frame(this, chunk3.Body, chunk3.Sections))
                    {
                        base.Accept(inspector.Body);
                    }
                    return;
                }
            }
            AttributeNode node4 = inspector.TakeAttribute("segment");
            if (base.Context.ParseSectionTagAsSegment && (node4 == null))
            {
                node4 = inspector.TakeAttribute("section");
            }
            string str = null;
            if (node4 != null)
            {
                str = node4.Value;
            }
            ScopeChunk item = new ScopeChunk {
                Position = this.Locate(inspector.OriginalNode)
            };
            this.Chunks.Add(item);
            using (new Frame(this, item.Body))
            {
                foreach (AttributeNode node5 in inspector.Attributes)
                {
                    LocalVariableChunk chunk7 = new LocalVariableChunk {
                        Name = node5.Name,
                        Value = this.AsTextOrientedCode(node5),
                        Position = this.Locate(node5)
                    };
                    this.Chunks.Add(chunk7);
                }
                RenderSectionChunk chunk8 = new RenderSectionChunk {
                    Name = str
                };
                this.Chunks.Add(chunk8);
                using (new Frame(this, chunk8.Default))
                {
                    base.Accept(inspector.Body);
                }
            }
        }

        private void VisitSection(SpecialNode node, SpecialNodeInspector inspector)
        {
            IList<Chunk> list;
            if (this.SectionChunks == null)
            {
                throw new CompilerException("Section cannot be used at this location", this.Locate(node.Element));
            }
            AttributeNode node2 = inspector.TakeAttribute("name");
            if (node2 == null)
            {
                throw new CompilerException("Section element must have a name attribute", this.Locate(node.Element));
            }
            if (!this.SectionChunks.TryGetValue(node2.Value, out list))
            {
                list = new List<Chunk>();
                this.SectionChunks.Add(node2.Value, list);
            }
            ScopeChunk item = new ScopeChunk {
                Position = this.Locate(inspector.OriginalNode)
            };
            list.Add(item);
            using (new Frame(this, item.Body))
            {
                foreach (AttributeNode node3 in inspector.Attributes)
                {
                    LocalVariableChunk chunk2 = new LocalVariableChunk {
                        Name = node3.Name,
                        Value = this.AsCode(node3),
                        Position = this.Locate(node3)
                    };
                    this.Chunks.Add(chunk2);
                }
                base.Accept(inspector.Body);
            }
        }

        private void VisitSet(SpecialNodeInspector inspector)
        {
            foreach (AttributeNode node in inspector.Attributes)
            {
                AssignVariableChunk item = new AssignVariableChunk {
                    Name = node.Name,
                    Value = this.AsTextOrientedCode(node),
                    Position = this.Locate(node)
                };
                this.Chunks.Add(item);
            }
        }

        private void VisitUnless(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            AttributeNode attr = inspector.TakeAttribute("condition") ?? inspector.TakeAttribute("unless");
            ConditionalChunk item = new ConditionalChunk {
                Type = ConditionalType.Unless,
                Condition = this.AsCode(attr),
                Position = this.Locate(inspector.OriginalNode)
            };
            this.Chunks.Add(item);
            using (new Frame(this, item.Body))
            {
                base.Accept(specialNode.Body);
            }
        }

        private void VisitUse(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            AttributeNode node = inspector.TakeAttribute("file");
            if (node != null)
            {
                ScopeChunk item = new ScopeChunk {
                    Position = this.Locate(inspector.OriginalNode)
                };
                this.Chunks.Add(item);
                using (new Frame(this, item.Body))
                {
                    foreach (AttributeNode node2 in inspector.Attributes)
                    {
                        LocalVariableChunk chunk2 = new LocalVariableChunk {
                            Name = node2.Name,
                            Value = this.AsTextOrientedCode(node2),
                            Position = this.Locate(node2)
                        };
                        this.Chunks.Add(chunk2);
                    }
                    RenderPartialChunk chunk3 = new RenderPartialChunk {
                        Name = node.Value,
                        Position = this.Locate(inspector.OriginalNode)
                    };
                    this.Chunks.Add(chunk3);
                    using (new Frame(this, chunk3.Body, chunk3.Sections))
                    {
                        base.Accept(inspector.Body);
                    }
                    return;
                }
            }
            AttributeNode node3 = inspector.TakeAttribute("content");
            AttributeNode attr = inspector.TakeAttribute("namespace");
            AttributeNode node5 = inspector.TakeAttribute("assembly");
            AttributeNode node6 = inspector.TakeAttribute("import");
            AttributeNode node7 = inspector.TakeAttribute("master");
            AttributeNode node8 = inspector.TakeAttribute("pageBaseType");
            if (node3 != null)
            {
                UseContentChunk chunk6 = new UseContentChunk {
                    Name = node3.Value,
                    Position = this.Locate(inspector.OriginalNode)
                };
                this.Chunks.Add(chunk6);
                using (new Frame(this, chunk6.Default))
                {
                    base.Accept(specialNode.Body);
                    return;
                }
            }
            if ((attr != null) || (node5 != null))
            {
                if (attr != null)
                {
                    UseNamespaceChunk chunk = new UseNamespaceChunk {
                        Namespace = this.AsCode(attr)
                    };
                    this.AddUnordered(chunk);
                }
                if (node5 != null)
                {
                    UseAssemblyChunk chunk10 = new UseAssemblyChunk {
                        Assembly = node5.Value
                    };
                    this.AddUnordered(chunk10);
                }
            }
            else if (node6 != null)
            {
                UseImportChunk chunk12 = new UseImportChunk {
                    Name = node6.Value
                };
                this.AddUnordered(chunk12);
            }
            else if (node7 != null)
            {
                UseMasterChunk chunk14 = new UseMasterChunk {
                    Name = node7.Value
                };
                this.AddUnordered(chunk14);
            }
            else
            {
                if (node8 == null)
                {
                    throw new CompilerException("Special node use had no understandable attributes");
                }
                PageBaseTypeChunk chunk16 = new PageBaseTypeChunk {
                    BaseClass = this.AsCode(node8)
                };
                this.AddUnordered(chunk16);
            }
        }

        private void VisitVar(SpecialNode specialNode, SpecialNodeInspector inspector)
        {
            Frame frame = null;
            if (!specialNode.Element.IsEmptyElement)
            {
                ScopeChunk item = new ScopeChunk {
                    Position = this.Locate(specialNode.Element)
                };
                this.Chunks.Add(item);
                frame = new Frame(this, item.Body);
            }
            AttributeNode attr = inspector.TakeAttribute("type");
            Snippets snippets = (attr != null) ? this.AsCode(attr) : "var";
            foreach (AttributeNode node2 in inspector.Attributes)
            {
                LocalVariableChunk chunk3 = new LocalVariableChunk {
                    Type = snippets,
                    Name = node2.Name,
                    Value = this.AsTextOrientedCode(node2),
                    Position = this.Locate(node2)
                };
                this.Chunks.Add(chunk3);
            }
            base.Accept(specialNode.Body);
            if (frame != null)
            {
                frame.Dispose();
            }
        }

        private void VisitViewdata(SpecialNodeInspector inspector)
        {
            AttributeNode attr = inspector.TakeAttribute("default");
            Snippets snippets = null;
            if (attr != null)
            {
                snippets = this.AsTextOrientedCode(attr);
            }
            AttributeNode node2 = inspector.TakeAttribute("model");
            if (node2 != null)
            {
                TypeInspector inspector2 = new TypeInspector(this.AsCode(node2));
                ViewDataModelChunk chunk = new ViewDataModelChunk {
                    TModel = inspector2.Type,
                    TModelAlias = inspector2.Name
                };
                this.AddUnordered(chunk);
            }
            foreach (AttributeNode node3 in inspector.Attributes)
            {
                TypeInspector inspector3 = new TypeInspector(this.AsCode(node3));
                ViewDataChunk chunk2 = new ViewDataChunk {
                    Type = inspector3.Type,
                    Name = inspector3.Name ?? node3.Name,
                    Key = node3.Name,
                    Default = snippets,
                    Position = this.Locate(node3)
                };
                this.AddUnordered(chunk2);
            }
        }

        public IList<Chunk> Chunks { get; set; }

        public override IList<Node> Nodes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private IDictionary<string, IList<Chunk>> SectionChunks { get; set; }

        public IDictionary<string, Action<SpecialNode, SpecialNodeInspector>> SpecialNodeMap
        {
            get
            {
                return this._specialNodeMap;
            }
        }

        private class Frame : IDisposable
        {
            private readonly IList<Chunk> _chunks;
            private readonly IDictionary<string, IList<Chunk>> _sectionChunks;
            private readonly ChunkBuilderVisitor _visitor;

            public Frame(ChunkBuilderVisitor visitor, IList<Chunk> chunks) : this(visitor, chunks, null)
            {
            }

            public Frame(ChunkBuilderVisitor visitor, IList<Chunk> chunks, IDictionary<string, IList<Chunk>> sectionChunks)
            {
                this._visitor = visitor;
                this._chunks = this._visitor.Chunks;
                this._sectionChunks = this._visitor.SectionChunks;
                this._visitor.Chunks = chunks;
                this._visitor.SectionChunks = sectionChunks;
            }

            public void Dispose()
            {
                this._visitor.Chunks = this._chunks;
                this._visitor.SectionChunks = this._sectionChunks;
            }
        }
    }
}

