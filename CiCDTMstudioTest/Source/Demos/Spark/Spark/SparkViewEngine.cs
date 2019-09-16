namespace Spark
{
    using Spark.Bindings;
    using Spark.Compiler;
    using Spark.Compiler.CSharp;
    using Spark.FileSystem;
    using Spark.Parser;
    using Spark.Parser.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Web.Hosting;

    public class SparkViewEngine : ISparkViewEngine, ISparkServiceInitialize
    {
        private IBindingProvider _bindingProvider;
        private ICompiledViewHolder _compiledViewHolder;
        private ISparkLanguageFactory _langaugeFactory;
        private IResourcePathManager _resourcePathManager;
        private ITemplateLocator _templateLocator;
        private IViewFolder _viewFolder;

        public SparkViewEngine() : this(null)
        {
        }

        public SparkViewEngine(ISparkSettings settings)
        {
            this.Settings = settings ?? (((ISparkSettings) ConfigurationManager.GetSection("spark")) ?? new SparkSettings());
            this.SyntaxProvider = new DefaultSyntaxProvider(this.Settings);
            this.ViewActivatorFactory = new DefaultViewActivator();
        }

        private IViewFolder ActivateViewFolder(IViewFolderSettings viewFolderSettings)
        {
            Type type;
            Func<ParameterInfo, bool> predicate = null;
            switch (viewFolderSettings.FolderType)
            {
                case ViewFolderType.FileSystem:
                    type = typeof(FileSystemViewFolder);
                    break;

                case ViewFolderType.VirtualPathProvider:
                    type = typeof(VirtualPathProviderViewFolder);
                    break;

                case ViewFolderType.EmbeddedResource:
                    type = typeof(EmbeddedViewFolder);
                    break;

                case ViewFolderType.Custom:
                    type = Type.GetType(viewFolderSettings.Type);
                    break;

                default:
                    throw new ArgumentException("Unknown value for view folder type");
            }
            ConstructorInfo info = null;
            foreach (ConstructorInfo info2 in type.GetConstructors())
            {
                if ((info == null) || (info.GetParameters().Length < info2.GetParameters().Length))
                {
                    if (predicate == null)
                    {
                        predicate = param => viewFolderSettings.Parameters.ContainsKey(param.Name);
                    }
                    if (info2.GetParameters().All<ParameterInfo>(predicate))
                    {
                        info = info2;
                    }
                }
            }
            if (info == null)
            {
                throw new MissingMethodException(string.Format("No suitable constructor for {0} located", type.FullName));
            }
            object[] args = (from param in info.GetParameters() select this.ChangeType(viewFolderSettings, param)).ToArray<object>();
            return (IViewFolder) Activator.CreateInstance(type, args);
        }

        public Assembly BatchCompilation(IList<SparkViewDescriptor> descriptors)
        {
            return this.BatchCompilation(null, descriptors);
        }

        public Assembly BatchCompilation(string outputAssembly, IList<SparkViewDescriptor> descriptors)
        {
            List<CompiledViewEntry> list = new List<CompiledViewEntry>();
            List<string> list2 = new List<string>();
            foreach (SparkViewDescriptor descriptor in descriptors)
            {
                CompiledViewEntry item = new CompiledViewEntry {
                    Descriptor = descriptor,
                    Loader = this.CreateViewLoader(),
                    Compiler = this.LanguageFactory.CreateViewCompiler(this, descriptor)
                };
                List<IList<Chunk>> chunksLoaded = new List<IList<Chunk>>();
                List<string> templatesLoaded = new List<string>();
                this.LoadTemplates(item.Loader, descriptor.Templates, chunksLoaded, templatesLoaded);
                item.Compiler.GenerateSourceCode(chunksLoaded, item.Loader.GetEverythingLoaded());
                list2.Add(item.Compiler.SourceCode);
                list.Add(item);
            }
            BatchCompiler compiler2 = new BatchCompiler {
                OutputAssembly = outputAssembly
            };
            Assembly assembly = compiler2.Compile(this.Settings.Debug, "csharp", list2.ToArray());
            foreach (CompiledViewEntry entry3 in list)
            {
                entry3.Compiler.CompiledType = assembly.GetType(entry3.Compiler.ViewClassFullName);
                entry3.Activator = this.ViewActivatorFactory.Register(entry3.Compiler.CompiledType);
                this.CompiledViewHolder.Store(entry3);
            }
            return assembly;
        }

        private object ChangeType(IViewFolderSettings viewFolderSettings, ParameterInfo param)
        {
            if (param.ParameterType == typeof(Assembly))
            {
                return Assembly.Load(viewFolderSettings.Parameters[param.Name]);
            }
            return Convert.ChangeType(viewFolderSettings.Parameters[param.Name], param.ParameterType);
        }

        private static IViewFolder CreateDefaultViewFolder()
        {
            if (HostingEnvironment.IsHosted && (HostingEnvironment.VirtualPathProvider != null))
            {
                return new VirtualPathProviderViewFolder("~/Views");
            }
            return new FileSystemViewFolder(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Views"));
        }

        public ISparkViewEntry CreateEntry(SparkViewDescriptor descriptor)
        {
            ISparkViewEntry entry = this.CompiledViewHolder.Lookup(descriptor);
            if (entry == null)
            {
                entry = this.CreateEntryInternal(descriptor, true);
                this.CompiledViewHolder.Store(entry);
            }
            return entry;
        }

        public ISparkViewEntry CreateEntryInternal(SparkViewDescriptor descriptor, bool compile)
        {
            CompiledViewEntry entry = new CompiledViewEntry {
                Descriptor = descriptor,
                Loader = this.CreateViewLoader(),
                Compiler = this.LanguageFactory.CreateViewCompiler(this, descriptor),
                LanguageFactory = this.LanguageFactory
            };
            List<IList<Chunk>> chunksLoaded = new List<IList<Chunk>>();
            List<string> templatesLoaded = new List<string>();
            this.LoadTemplates(entry.Loader, entry.Descriptor.Templates, chunksLoaded, templatesLoaded);
            if (compile)
            {
                entry.Compiler.CompileView(chunksLoaded, entry.Loader.GetEverythingLoaded());
                entry.Activator = this.ViewActivatorFactory.Register(entry.Compiler.CompiledType);
                return entry;
            }
            entry.Compiler.GenerateSourceCode(chunksLoaded, entry.Loader.GetEverythingLoaded());
            return entry;
        }

        public ISparkView CreateInstance(SparkViewDescriptor descriptor)
        {
            return this.CreateEntry(descriptor).CreateInstance();
        }

        private ViewLoader CreateViewLoader()
        {
            return new ViewLoader { ViewFolder = this.ViewFolder, SyntaxProvider = this.SyntaxProvider, ExtensionFactory = this.ExtensionFactory, Prefix = this.Settings.Prefix, BindingProvider = this.BindingProvider, ParseSectionTagAsSegment = this.Settings.ParseSectionTagAsSegment, AttributeBehaviour = this.Settings.AttributeBehaviour };
        }

        public ISparkViewEntry GetEntry(SparkViewDescriptor descriptor)
        {
            return this.CompiledViewHolder.Lookup(descriptor);
        }

        public void Initialize(ISparkServiceContainer container)
        {
            this.Settings = container.GetService<ISparkSettings>();
            this.SyntaxProvider = container.GetService<ISparkSyntaxProvider>();
            this.ViewActivatorFactory = container.GetService<IViewActivatorFactory>();
            this.LanguageFactory = container.GetService<ISparkLanguageFactory>();
            this.BindingProvider = container.GetService<IBindingProvider>();
            this.ResourcePathManager = container.GetService<IResourcePathManager>();
            this.TemplateLocator = container.GetService<ITemplateLocator>();
            this.CompiledViewHolder = container.GetService<ICompiledViewHolder>();
            this.SetViewFolder(container.GetService<IViewFolder>());
        }

        public IList<SparkViewDescriptor> LoadBatchCompilation(Assembly assembly)
        {
            List<SparkViewDescriptor> list = new List<SparkViewDescriptor>();
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (typeof(ISparkView).IsAssignableFrom(type))
                {
                    object[] customAttributes = type.GetCustomAttributes(typeof(SparkViewAttribute), false);
                    if ((customAttributes != null) && (customAttributes.Length != 0))
                    {
                        SparkViewDescriptor item = ((SparkViewAttribute) customAttributes[0]).BuildDescriptor();
                        CompiledViewEntry entry2 = new CompiledViewEntry {
                            Descriptor = item,
                            Loader = new ViewLoader()
                        };
                        CSharpViewCompiler compiler = new CSharpViewCompiler {
                            CompiledType = type
                        };
                        entry2.Compiler = compiler;
                        entry2.Activator = this.ViewActivatorFactory.Register(type);
                        CompiledViewEntry entry = entry2;
                        this.CompiledViewHolder.Store(entry);
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        private void LoadTemplates(ViewLoader loader, IEnumerable<string> templates, ICollection<IList<Chunk>> chunksLoaded, ICollection<string> templatesLoaded)
        {
            foreach (string str in templates)
            {
                if (templatesLoaded.Contains(str))
                {
                    throw new CompilerException(string.Format("Unable to include template '{0}' recusively", templates));
                }
                IList<Chunk> item = loader.Load(str);
                chunksLoaded.Add(item);
                templatesLoaded.Add(str);
            }
        }

        public void ReleaseInstance(ISparkView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }
            ISparkViewEntry entry = this.CompiledViewHolder.Lookup(view.GeneratedViewId);
            if (entry != null)
            {
                entry.ReleaseInstance(view);
            }
        }

        private void SetViewFolder(IViewFolder value)
        {
            IViewFolder viewFolder = value;
            foreach (IViewFolderSettings settings in this.Settings.ViewFolders)
            {
                IViewFolder folder2 = this.ActivateViewFolder(settings);
                if (!string.IsNullOrEmpty(settings.Subfolder))
                {
                    folder2 = new SubViewFolder(folder2, settings.Subfolder);
                }
                viewFolder = viewFolder.Append(folder2);
            }
            this._viewFolder = viewFolder;
        }

        public IBindingProvider BindingProvider
        {
            get
            {
                if (this._bindingProvider == null)
                {
                    this._bindingProvider = new DefaultBindingProvider();
                }
                return this._bindingProvider;
            }
            set
            {
                this._bindingProvider = value;
            }
        }

        public ICompiledViewHolder CompiledViewHolder
        {
            get
            {
                if (this._compiledViewHolder == null)
                {
                    this._compiledViewHolder = new Spark.CompiledViewHolder();
                }
                return this._compiledViewHolder;
            }
            set
            {
                this._compiledViewHolder = value;
            }
        }

        public string DefaultPageBaseType { get; set; }

        public ISparkExtensionFactory ExtensionFactory { get; set; }

        public ISparkLanguageFactory LanguageFactory
        {
            get
            {
                if (this._langaugeFactory == null)
                {
                    this._langaugeFactory = new DefaultLanguageFactory();
                }
                return this._langaugeFactory;
            }
            set
            {
                this._langaugeFactory = value;
            }
        }

        public IResourcePathManager ResourcePathManager
        {
            get
            {
                if (this._resourcePathManager == null)
                {
                    this._resourcePathManager = new DefaultResourcePathManager(this.Settings);
                }
                return this._resourcePathManager;
            }
            set
            {
                this._resourcePathManager = value;
            }
        }

        public ISparkSettings Settings { get; set; }

        public ISparkSyntaxProvider SyntaxProvider { get; set; }

        public ITemplateLocator TemplateLocator
        {
            get
            {
                if (this._templateLocator == null)
                {
                    this._templateLocator = new DefaultTemplateLocator();
                }
                return this._templateLocator;
            }
            set
            {
                this._templateLocator = value;
            }
        }

        public IViewActivatorFactory ViewActivatorFactory { get; set; }

        public IViewFolder ViewFolder
        {
            get
            {
                if (this._viewFolder == null)
                {
                    this.SetViewFolder(CreateDefaultViewFolder());
                }
                return this._viewFolder;
            }
            set
            {
                this.SetViewFolder(value);
            }
        }
    }
}

