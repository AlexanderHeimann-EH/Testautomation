namespace Spark
{
    using Spark.Bindings;
    using Spark.FileSystem;
    using Spark.Parser.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Web.Hosting;

    public class SparkServiceContainer : ISparkServiceContainer, IServiceProvider
    {
        private readonly Dictionary<Type, Func<ISparkServiceContainer, object>> _defaults;
        private readonly Dictionary<Type, object> _services;

        public SparkServiceContainer()
        {
            this._services = new Dictionary<Type, object>();
            Dictionary<Type, Func<ISparkServiceContainer, object>> dictionary = new Dictionary<Type, Func<ISparkServiceContainer, object>>();
            dictionary.Add(typeof(ISparkSettings), c => ConfigurationManager.GetSection("spark") ?? new SparkSettings());
            dictionary.Add(typeof(ISparkViewEngine), c => new SparkViewEngine(c.GetService<ISparkSettings>()));
            dictionary.Add(typeof(ISparkLanguageFactory), c => new DefaultLanguageFactory());
            dictionary.Add(typeof(ISparkSyntaxProvider), c => new DefaultSyntaxProvider(c.GetService<ISparkSettings>()));
            dictionary.Add(typeof(IViewActivatorFactory), c => new DefaultViewActivator());
            dictionary.Add(typeof(IResourcePathManager), c => new DefaultResourcePathManager(c.GetService<ISparkSettings>()));
            dictionary.Add(typeof(ITemplateLocator), c => new DefaultTemplateLocator());
            dictionary.Add(typeof(IBindingProvider), c => new DefaultBindingProvider());
            dictionary.Add(typeof(IViewFolder), new Func<ISparkServiceContainer, object>(SparkServiceContainer.CreateDefaultViewFolder));
            dictionary.Add(typeof(ICompiledViewHolder), c => new CompiledViewHolder());
            this._defaults = dictionary;
        }

        public SparkServiceContainer(ISparkSettings settings)
        {
            this._services = new Dictionary<Type, object>();
            Dictionary<Type, Func<ISparkServiceContainer, object>> dictionary = new Dictionary<Type, Func<ISparkServiceContainer, object>>();
            dictionary.Add(typeof(ISparkSettings), c => ConfigurationManager.GetSection("spark") ?? new SparkSettings());
            dictionary.Add(typeof(ISparkViewEngine), c => new SparkViewEngine(c.GetService<ISparkSettings>()));
            dictionary.Add(typeof(ISparkLanguageFactory), c => new DefaultLanguageFactory());
            dictionary.Add(typeof(ISparkSyntaxProvider), c => new DefaultSyntaxProvider(c.GetService<ISparkSettings>()));
            dictionary.Add(typeof(IViewActivatorFactory), c => new DefaultViewActivator());
            dictionary.Add(typeof(IResourcePathManager), c => new DefaultResourcePathManager(c.GetService<ISparkSettings>()));
            dictionary.Add(typeof(ITemplateLocator), c => new DefaultTemplateLocator());
            dictionary.Add(typeof(IBindingProvider), c => new DefaultBindingProvider());
            dictionary.Add(typeof(IViewFolder), new Func<ISparkServiceContainer, object>(SparkServiceContainer.CreateDefaultViewFolder));
            dictionary.Add(typeof(ICompiledViewHolder), c => new CompiledViewHolder());
            this._defaults = dictionary;
            this._services[typeof(ISparkSettings)] = settings;
        }

        private static object CreateDefaultViewFolder(ISparkServiceContainer arg)
        {
            if (HostingEnvironment.IsHosted && (HostingEnvironment.VirtualPathProvider != null))
            {
                return new VirtualPathProviderViewFolder("~/Views");
            }
            return new FileSystemViewFolder(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Views"));
        }

        public T GetService<T>()
        {
            return (T) this.GetService(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            lock (this._services)
            {
                object obj2;
                Func<ISparkServiceContainer, object> func;
                if (this._services.TryGetValue(serviceType, out obj2))
                {
                    return obj2;
                }
                if (this._defaults.TryGetValue(serviceType, out func))
                {
                    obj2 = func(this);
                    this._services.Add(serviceType, obj2);
                    if (obj2 is ISparkServiceInitialize)
                    {
                        ((ISparkServiceInitialize) obj2).Initialize(this);
                    }
                    return obj2;
                }
                return null;
            }
        }

        public void SetService<TService>(TService service)
        {
            this.SetService(typeof(TService), service);
        }

        public void SetService(Type serviceType, object service)
        {
            if (this._services.ContainsKey(serviceType))
            {
                throw new ApplicationException(string.Format("A service of type {0} has already been created", serviceType));
            }
            if (!serviceType.IsInterface)
            {
                throw new ApplicationException(string.Format("Only an interface may be used as service type. {0}", serviceType));
            }
            lock (this._services)
            {
                this._services[serviceType] = service;
                if (service is ISparkServiceInitialize)
                {
                    ((ISparkServiceInitialize) service).Initialize(this);
                }
            }
        }

        public void SetServiceBuilder<TService>(Func<ISparkServiceContainer, object> serviceBuilder)
        {
            this.SetServiceBuilder(typeof(TService), serviceBuilder);
        }

        public void SetServiceBuilder(Type serviceType, Func<ISparkServiceContainer, object> serviceBuilder)
        {
            if (this._services.ContainsKey(serviceType))
            {
                throw new ApplicationException(string.Format("A service of type {0} has already been created", serviceType));
            }
            if (!serviceType.IsInterface)
            {
                throw new ApplicationException(string.Format("Only an interface may be used as service type. {0}", serviceType));
            }
            lock (this._services)
            {
                this._defaults[serviceType] = serviceBuilder;
            }
        }
    }
}

