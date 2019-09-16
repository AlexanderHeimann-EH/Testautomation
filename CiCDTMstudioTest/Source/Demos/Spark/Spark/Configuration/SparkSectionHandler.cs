namespace Spark.Configuration
{
    using Spark;
    using Spark.Parser;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class SparkSectionHandler : ConfigurationSection, ISparkSettings, IParserSettings
    {
        public SparkSectionHandler AddAssembly(Assembly assembly)
        {
            this.Compilation.Assemblies.Add(assembly.FullName);
            return this;
        }

        public SparkSectionHandler AddAssembly(string assembly)
        {
            this.Compilation.Assemblies.Add(assembly);
            return this;
        }

        public SparkSectionHandler AddNamespace(string ns)
        {
            this.Pages.Namespaces.Add(ns);
            return this;
        }

        public SparkSectionHandler SetDebug(bool debug)
        {
            this.Compilation.Debug = debug;
            return this;
        }

        public SparkSectionHandler SetPageBaseType(string typeName)
        {
            this.Pages.PageBaseType = typeName;
            return this;
        }

        public SparkSectionHandler SetPageBaseType(Type type)
        {
            this.Pages.PageBaseType = type.FullName;
            return this;
        }

        [ConfigurationProperty("compilation")]
        public CompilationElement Compilation
        {
            get
            {
                return (CompilationElement) base["compilation"];
            }
            set
            {
                base["compilation"] = value;
            }
        }

        [ConfigurationProperty("pages")]
        public PagesElement Pages
        {
            get
            {
                return (PagesElement) base["pages"];
            }
            set
            {
                base["pages"] = value;
            }
        }

        AttributeBehaviour ISparkSettings.AttributeBehaviour
        {
            get
            {
                return this.Compilation.AttributeBehaviour;
            }
        }

        bool ISparkSettings.Debug
        {
            get
            {
                return this.Compilation.Debug;
            }
        }

        LanguageType ISparkSettings.DefaultLanguage
        {
            get
            {
                return this.Compilation.DefaultLanguage;
            }
        }

        NullBehaviour ISparkSettings.NullBehaviour
        {
            get
            {
                return this.Compilation.NullBehaviour;
            }
        }

        string ISparkSettings.PageBaseType
        {
            get
            {
                return this.Pages.PageBaseType;
            }
            set
            {
                this.Pages.PageBaseType = value;
            }
        }

        bool ISparkSettings.ParseSectionTagAsSegment
        {
            get
            {
                return this.Pages.ParseSectionTagAsSegment;
            }
        }

        string ISparkSettings.Prefix
        {
            get
            {
                return this.Pages.Prefix;
            }
        }

        IEnumerable<IResourceMapping> ISparkSettings.ResourceMappings
        {
            get
            {
                IEnumerator enumerator = this.Pages.Resources.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ResourcePathElement current = (ResourcePathElement) enumerator.Current;
                    SimpleResourceMapping iteratorVariable1 = new SimpleResourceMapping {
                        Match = current.Match,
                        Location = current.Location
                    };
                    yield return iteratorVariable1;
                }
            }
        }

        IEnumerable<string> ISparkSettings.UseAssemblies
        {
            get
            {
                IEnumerator enumerator = this.Compilation.Assemblies.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    AssemblyElement current = (AssemblyElement) enumerator.Current;
                    yield return current.Assembly;
                }
            }
        }

        IEnumerable<string> ISparkSettings.UseNamespaces
        {
            get
            {
                IEnumerator enumerator = this.Pages.Namespaces.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    NamespaceElement current = (NamespaceElement) enumerator.Current;
                    yield return current.Namespace;
                }
            }
        }

        IEnumerable<IViewFolderSettings> ISparkSettings.ViewFolders
        {
            get
            {
                IEnumerator enumerator = this.Views.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ViewFolderElement current = (ViewFolderElement) enumerator.Current;
                    yield return current;
                }
            }
        }

        bool IParserSettings.AutomaticEncoding
        {
            get
            {
                return this.Pages.AutomaticEncoding;
            }
        }

        string IParserSettings.StatementMarker
        {
            get
            {
                return this.Pages.StatementMarker;
            }
        }

        [ConfigurationProperty("views")]
        public ViewFolderElementCollection Views
        {
            get
            {
                return (ViewFolderElementCollection) base["views"];
            }
            set
            {
                base["views"] = value;
            }
        }

        [ConfigurationProperty("xmlns")]
        public string XmlNamespace
        {
            get
            {
                return (string) base["xmlns"];
            }
            set
            {
                base["xmlns"] = value;
            }
        }




    }
}

