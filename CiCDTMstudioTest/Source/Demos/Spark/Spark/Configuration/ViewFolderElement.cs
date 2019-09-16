namespace Spark.Configuration
{
    using Spark;
    using Spark.FileSystem;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Runtime.CompilerServices;

    public class ViewFolderElement : ConfigurationElement, IViewFolderSettings
    {
        public ViewFolderElement()
        {
            this.Parameters = new Dictionary<string, string>();
        }

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            this.Parameters.Add(name, value);
            return true;
        }

        [ConfigurationProperty("folderType")]
        public ViewFolderType FolderType
        {
            get
            {
                return (ViewFolderType) base["folderType"];
            }
            set
            {
                base["folderType"] = value;
            }
        }

        [ConfigurationProperty("name")]
        public string Name
        {
            get
            {
                return (string) base["name"];
            }
            set
            {
                base["name"] = value;
            }
        }

        public IDictionary<string, string> Parameters { get; set; }

        [ConfigurationProperty("subfolder")]
        public string Subfolder
        {
            get
            {
                return (string) base["subfolder"];
            }
            set
            {
                base["subfolder"] = value;
            }
        }

        [ConfigurationProperty("type")]
        public string Type
        {
            get
            {
                return (string) base["type"];
            }
            set
            {
                base["type"] = value;
            }
        }
    }
}

