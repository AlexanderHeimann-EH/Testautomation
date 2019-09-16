namespace Spark.Configuration
{
    using System;
    using System.Configuration;

    public class NamespaceElementCollection : ConfigurationElementCollection
    {
        public void Add(string ns)
        {
            NamespaceElement element = new NamespaceElement {
                Namespace = ns
            };
            base.BaseAdd(element);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new NamespaceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NamespaceElement) element).Namespace;
        }
    }
}

