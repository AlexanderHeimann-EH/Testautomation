namespace Spark.Configuration
{
    using System;
    using System.Configuration;

    public class NamespaceElement : ConfigurationElement
    {
        [ConfigurationProperty("namespace")]
        public string Namespace
        {
            get
            {
                return (string) base["namespace"];
            }
            set
            {
                base["namespace"] = value;
            }
        }
    }
}

