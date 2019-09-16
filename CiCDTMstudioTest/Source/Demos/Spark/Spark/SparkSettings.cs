namespace Spark
{
    using Spark.FileSystem;
    using Spark.Parser;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class SparkSettings : ISparkSettings, IParserSettings
    {
        private readonly IList<IResourceMapping> _resourceMappings = new List<IResourceMapping>();
        private readonly IList<string> _useAssemblies = new List<string>();
        private readonly IList<string> _useNamespaces = new List<string>();
        private readonly IList<IViewFolderSettings> _viewFolders = new List<IViewFolderSettings>();

        public SparkSettings()
        {
            this.NullBehaviour = Spark.NullBehaviour.Lenient;
            this.AttributeBehaviour = Spark.AttributeBehaviour.CodeOriented;
            this.AutomaticEncoding = false;
        }

        public SparkSettings AddAssembly(Assembly assembly)
        {
            this._useAssemblies.Add(assembly.FullName);
            return this;
        }

        public SparkSettings AddAssembly(string assembly)
        {
            this._useAssemblies.Add(assembly);
            return this;
        }

        public SparkSettings AddNamespace(string ns)
        {
            this._useNamespaces.Add(ns);
            return this;
        }

        public SparkSettings AddResourceMapping(string match, string replace)
        {
            return this.AddResourceMapping(match, replace, true);
        }

        public SparkSettings AddResourceMapping(string match, string replace, bool stopProcess)
        {
            SimpleResourceMapping item = new SimpleResourceMapping {
                Match = match,
                Location = replace,
                Stop = stopProcess
            };
            this._resourceMappings.Add(item);
            return this;
        }

        public SparkSettings AddViewFolder(ViewFolderType type, IDictionary<string, string> parameters)
        {
            ViewFolderSettings item = new ViewFolderSettings {
                FolderType = type,
                Parameters = parameters
            };
            this._viewFolders.Add(item);
            return this;
        }

        public SparkSettings AddViewFolder(Type customType, IDictionary<string, string> parameters)
        {
            ViewFolderSettings item = new ViewFolderSettings {
                FolderType = ViewFolderType.Custom,
                Type = customType.AssemblyQualifiedName,
                Parameters = parameters
            };
            this._viewFolders.Add(item);
            return this;
        }

        public SparkSettings SetAttributeBehaviour(Spark.AttributeBehaviour attributeBehaviour)
        {
            this.AttributeBehaviour = attributeBehaviour;
            return this;
        }

        public SparkSettings SetAutomaticEncoding(bool automaticEncoding)
        {
            this.AutomaticEncoding = automaticEncoding;
            return this;
        }

        public SparkSettings SetDebug(bool debug)
        {
            this.Debug = debug;
            return this;
        }

        public SparkSettings SetDefaultLanguage(LanguageType language)
        {
            this.DefaultLanguage = language;
            return this;
        }

        public SparkSettings SetNullBehaviour(Spark.NullBehaviour nullBehaviour)
        {
            this.NullBehaviour = nullBehaviour;
            return this;
        }

        public SparkSettings SetPageBaseType(string typeName)
        {
            this.PageBaseType = typeName;
            return this;
        }

        public SparkSettings SetPageBaseType(Type type)
        {
            this.PageBaseType = type.FullName;
            return this;
        }

        public SparkSettings SetParseSectionTagAsSegment(bool parseSectionTagAsSegment)
        {
            this.ParseSectionTagAsSegment = parseSectionTagAsSegment;
            return this;
        }

        public SparkSettings SetPrefix(string prefix)
        {
            this.Prefix = prefix;
            return this;
        }

        public SparkSettings SetStatementMarker(string statementMarker)
        {
            this.StatementMarker = statementMarker;
            return this;
        }

        public Spark.AttributeBehaviour AttributeBehaviour { get; set; }

        public bool AutomaticEncoding { get; set; }

        public bool Debug { get; set; }

        public LanguageType DefaultLanguage { get; set; }

        public Spark.NullBehaviour NullBehaviour { get; set; }

        public string PageBaseType { get; set; }

        public bool ParseSectionTagAsSegment { get; set; }

        public string Prefix { get; set; }

        public IEnumerable<IResourceMapping> ResourceMappings
        {
            get
            {
                return this._resourceMappings;
            }
        }

        public string StatementMarker { get; set; }

        public IEnumerable<string> UseAssemblies
        {
            get
            {
                return this._useAssemblies;
            }
        }

        public IEnumerable<string> UseNamespaces
        {
            get
            {
                return this._useNamespaces;
            }
        }

        public IEnumerable<IViewFolderSettings> ViewFolders
        {
            get
            {
                return this._viewFolders;
            }
        }
    }
}

