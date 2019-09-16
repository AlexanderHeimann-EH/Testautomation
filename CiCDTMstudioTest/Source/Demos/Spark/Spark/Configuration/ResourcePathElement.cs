namespace Spark.Configuration
{
    using System;
    using System.Configuration;

    public class ResourcePathElement : ConfigurationElement
    {
        [ConfigurationProperty("location")]
        public string Location
        {
            get
            {
                return (string) base["location"];
            }
            set
            {
                base["location"] = value;
            }
        }

        [ConfigurationProperty("match")]
        public string Match
        {
            get
            {
                return (string) base["match"];
            }
            set
            {
                base["match"] = value;
            }
        }

        [ConfigurationProperty("stop")]
        public bool Stop
        {
            get
            {
                return (bool) base["stop"];
            }
            set
            {
                base["stop"] = value;
            }
        }
    }
}

