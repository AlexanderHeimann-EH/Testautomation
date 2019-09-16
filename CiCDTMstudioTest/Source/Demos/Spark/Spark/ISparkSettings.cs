namespace Spark
{
    using Spark.Parser;
    using System;
    using System.Collections.Generic;

    public interface ISparkSettings : IParserSettings
    {
        Spark.AttributeBehaviour AttributeBehaviour { get; }

        bool Debug { get; }

        LanguageType DefaultLanguage { get; }

        Spark.NullBehaviour NullBehaviour { get; }

        string PageBaseType { get; set; }

        bool ParseSectionTagAsSegment { get; }

        string Prefix { get; }

        IEnumerable<IResourceMapping> ResourceMappings { get; }

        IEnumerable<string> UseAssemblies { get; }

        IEnumerable<string> UseNamespaces { get; }

        IEnumerable<IViewFolderSettings> ViewFolders { get; }
    }
}

