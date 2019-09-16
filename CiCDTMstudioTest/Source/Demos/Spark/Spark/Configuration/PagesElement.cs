namespace Spark.Configuration
{
    using System;
    using System.Configuration;

    public class PagesElement : ConfigurationElement
    {
        [ConfigurationProperty("automaticEncoding", DefaultValue=false)]
        public bool AutomaticEncoding
        {
            get
            {
                return (bool) base["automaticEncoding"];
            }
            set
            {
                base["automaticEncoding"] = value;
            }
        }

        [ConfigurationCollection(typeof(NamespaceElementCollection)), ConfigurationProperty("namespaces")]
        public NamespaceElementCollection Namespaces
        {
            get
            {
                return (NamespaceElementCollection) base["namespaces"];
            }
            set
            {
                base["namespaces"] = value;
            }
        }

        [ConfigurationProperty("pageBaseType")]
        public string PageBaseType
        {
            get
            {
                return (string) base["pageBaseType"];
            }
            set
            {
                base["pageBaseType"] = value;
            }
        }

        [ConfigurationProperty("parseSectionTagAsSegment")]
        public bool ParseSectionTagAsSegment
        {
            get
            {
                return (bool) base["parseSectionTagAsSegment"];
            }
            set
            {
                base["parseSectionTagAsSegment"] = value;
            }
        }

        [ConfigurationProperty("prefix")]
        public string Prefix
        {
            get
            {
                return (string) base["prefix"];
            }
            set
            {
                base["prefix"] = value;
            }
        }

        [ConfigurationCollection(typeof(ResourcePathElementCollection)), ConfigurationProperty("resources")]
        public ResourcePathElementCollection Resources
        {
            get
            {
                return (ResourcePathElementCollection) base["resources"];
            }
            set
            {
                base["resources"] = value;
            }
        }

        [ConfigurationProperty("statementMarker", DefaultValue="#")]
        public string StatementMarker
        {
            get
            {
                return (string) base["statementMarker"];
            }
            set
            {
                base["statementMarker"] = value;
            }
        }
    }
}

