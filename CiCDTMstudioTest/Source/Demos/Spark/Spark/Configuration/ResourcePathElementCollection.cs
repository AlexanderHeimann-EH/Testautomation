namespace Spark.Configuration
{
    using System;
    using System.Configuration;

    public class ResourcePathElementCollection : ConfigurationElementCollection
    {
        public void Add(string match, string location, bool stop)
        {
            ResourcePathElement element = new ResourcePathElement {
                Match = match,
                Location = location,
                Stop = stop
            };
            base.BaseAdd(element);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ResourcePathElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ResourcePathElement) element).Match;
        }
    }
}

