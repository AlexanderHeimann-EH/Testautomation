namespace Spark.Configuration
{
    using System;
    using System.Configuration;

    public class ViewFolderElementCollection : ConfigurationElementCollection
    {
        public void Add(string name)
        {
            ViewFolderElement element = new ViewFolderElement {
                Name = name
            };
            base.BaseAdd(element);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ViewFolderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ViewFolderElement) element).Name;
        }
    }
}

