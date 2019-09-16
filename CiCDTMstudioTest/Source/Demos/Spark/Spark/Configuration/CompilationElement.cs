namespace Spark.Configuration
{
    using Spark;
    using System;
    using System.Configuration;

    public class CompilationElement : ConfigurationElement
    {
        [ConfigurationProperty("assemblies"), ConfigurationCollection(typeof(AssemblyElementCollection))]
        public AssemblyElementCollection Assemblies
        {
            get
            {
                return (AssemblyElementCollection) base["assemblies"];
            }
            set
            {
                base["assemblies"] = value;
            }
        }

        [ConfigurationProperty("attributeBehaviour", DefaultValue=0)]
        public Spark.AttributeBehaviour AttributeBehaviour
        {
            get
            {
                return (Spark.AttributeBehaviour) base["attributeBehaviour"];
            }
            set
            {
                base["attributeBehaviour"] = value;
            }
        }

        [ConfigurationProperty("debug")]
        public bool Debug
        {
            get
            {
                return (bool) base["debug"];
            }
            set
            {
                base["debug"] = value;
            }
        }

        [ConfigurationProperty("defaultLanguage", DefaultValue=0)]
        public LanguageType DefaultLanguage
        {
            get
            {
                return (LanguageType) base["defaultLanguage"];
            }
            set
            {
                base["defaultLanguage"] = value;
            }
        }

        [ConfigurationProperty("nullBehaviour", DefaultValue=0)]
        public Spark.NullBehaviour NullBehaviour
        {
            get
            {
                return (Spark.NullBehaviour) base["nullBehaviour"];
            }
            set
            {
                base["nullBehaviour"] = value;
            }
        }
    }
}

