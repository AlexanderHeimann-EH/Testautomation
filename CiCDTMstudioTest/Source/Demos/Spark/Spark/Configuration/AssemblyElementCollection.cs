namespace Spark.Configuration
{
    using System;
    using System.Configuration;

    public class AssemblyElementCollection : ConfigurationElementCollection
    {
        public void Add(string assembly)
        {
            AssemblyElement element = new AssemblyElement {
                Assembly = assembly
            };
            this.BaseAdd(element);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new AssemblyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AssemblyElement) element).Assembly;
        }
    }
}

