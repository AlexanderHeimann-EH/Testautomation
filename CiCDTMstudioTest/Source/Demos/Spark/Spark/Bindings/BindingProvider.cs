namespace Spark.Bindings
{
    using Spark.Compiler;
    using Spark.Parser;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public abstract class BindingProvider : IBindingProvider
    {
        protected BindingProvider()
        {
        }

        public abstract IEnumerable<Binding> GetBindings(BindingRequest bindingRequest);
        public IEnumerable<Binding> LoadStandardMarkup(TextReader reader)
        {
            IEnumerable<XElement> enumerable = XDocument.Load(reader).Elements("bindings").Elements<XElement>("element");
            BindingGrammar grammar = new BindingGrammar();
            return (from element in enumerable select ParseBinding(element, grammar));
        }

        private static Binding ParseBinding(XElement element, BindingGrammar grammar)
        {
            Binding binding = new Binding {
                ElementName = (string) element.Attribute("name")
            };
            XElement element2 = element.Element("start");
            XElement element3 = element.Element("end");
            if ((element2 != null) && (element3 != null))
            {
                binding.Phrases = new BindingPhrase[] { ParsePhrase(element2, grammar), ParsePhrase(element3, grammar) };
            }
            else
            {
                binding.Phrases = new BindingPhrase[] { ParsePhrase(element, grammar) };
            }
            binding.HasChildReference = (from phrase in binding.Phrases select phrase.Nodes).OfType<BindingChildReference>().Any<BindingChildReference>();
            if ((binding.Phrases.Count<BindingPhrase>() > 1) && binding.HasChildReference)
            {
                throw new CompilerException("Binding element '" + element.Attribute("name") + "' can not have child::* in start or end phrases.");
            }
            return binding;
        }

        private static BindingPhrase ParsePhrase(XElement element, BindingGrammar grammar)
        {
            return grammar.Phrase(new Position(new SourceContext(element.Value))).Value;
        }
    }
}

