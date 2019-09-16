namespace Spark.Compiler.NodeVisitors
{
    using Spark.Parser.Markup;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class SpecialNodeInspector
    {
        private SpecialNode _node;

        public SpecialNodeInspector(SpecialNode node)
        {
            this._node = node;
            this.Attributes = new List<AttributeNode>(node.Element.Attributes);
        }

        public AttributeNode TakeAttribute(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            AttributeNode item = this.Attributes.FirstOrDefault<AttributeNode>(a => a.Name == name);
            this.Attributes.Remove(item);
            return item;
        }

        public AttributeNode TakeAttribute(string name, NamespacesType nsType)
        {
            AttributeNode node;
            Func<AttributeNode, bool> predicate = null;
            Func<AttributeNode, bool> func2 = null;
            if (nsType == NamespacesType.Unqualified)
            {
                if (predicate == null)
                {
                    predicate = a => a.Name == name;
                }
                node = this.Attributes.FirstOrDefault<AttributeNode>(predicate);
            }
            else
            {
                if (func2 == null)
                {
                    func2 = a => ((this._node.Element.Namespace == "http://sparkviewengine.com/") && (a.Name == name)) || ((a.Namespace == "http://sparkviewengine.com/") && (NameUtility.GetName(a.Name) == name));
                }
                node = this.Attributes.FirstOrDefault<AttributeNode>(func2);
            }
            this.Attributes.Remove(node);
            return node;
        }

        public IList<AttributeNode> Attributes { get; set; }

        public IList<Node> Body
        {
            get
            {
                return this._node.Body;
            }
        }

        public bool IsEmptyElement
        {
            get
            {
                return this._node.Element.IsEmptyElement;
            }
        }

        public string Name
        {
            get
            {
                return this._node.Element.Name;
            }
        }

        public ElementNode OriginalNode
        {
            get
            {
                return this._node.Element;
            }
        }
    }
}

