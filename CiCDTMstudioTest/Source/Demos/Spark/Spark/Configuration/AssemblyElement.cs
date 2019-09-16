namespace Spark.Configuration
{
    using System;
    using System.Configuration;

    public class AssemblyElement : ConfigurationElement
    {
        [ConfigurationProperty("assembly")]
        public string Assembly
        {
            get
            {
                return (string) base["assembly"];
            }
            set
            {
                base["assembly"] = value;
            }
        }
    }
}

