using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Security.Policy;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApplication1
{

    /// <span class="code-SummaryComment"><summary></span>
    /// Loads an assembly into a new AppDomain and obtains all the
    /// namespaces in the loaded Assembly, which are returned as a 
    /// List. The new AppDomain is then Unloaded.
    /// 
    /// This class creates a new instance of a 
    /// <span class="code-SummaryComment"><c>AssemblyLoader</c> class</span>
    /// which does the actual ReflectionOnly loading 
    /// of the Assembly into
    /// the new AppDomain.
    /// <span class="code-SummaryComment"></summary></span>
    public class SeperateAppDomainAssemblyLoader
    {
        #region Public Methods
        /// <span class="code-SummaryComment"><summary></span>
        /// Loads an assembly into a new AppDomain and obtains all the
        /// namespaces in the loaded Assembly, which are returned as a 
        /// List. The new AppDomain is then Unloaded
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="assemblyLocation">The Assembly file </span>
        /// location<span class="code-SummaryComment"></param></span>
        /// <span class="code-SummaryComment"><returns>A list of found namespaces</returns></span>
        public List<String> LoadAssembly(FileInfo assemblyLocation)
        {
            List<String> namespaces = new List<String>();

            if (string.IsNullOrEmpty(assemblyLocation.Directory.FullName))
            {
                throw new InvalidOperationException(
                    "Directory can't be null or empty.");
            }

            if (!Directory.Exists(assemblyLocation.Directory.FullName))
            {
                throw new InvalidOperationException(
                   string.Format(CultureInfo.CurrentCulture,
                   "Directory not found {0}",
                   assemblyLocation.Directory.FullName));

            }

            AppDomain childDomain = BuildChildDomain(
                AppDomain.CurrentDomain);

            try
            {
                Type loaderType = typeof(AssemblyLoader);
                if (loaderType.Assembly != null)
                {
                    var loader =
                        (AssemblyLoader)childDomain.
                            CreateInstanceFrom(
                            loaderType.Assembly.Location,
                            loaderType.FullName).Unwrap();

                    loader.LoadAssembly(
                        assemblyLocation.FullName);
                    namespaces =
                        loader.GetNamespaces(
                        assemblyLocation.Directory.FullName);
                }
                return namespaces;
            }

            finally
            {

                AppDomain.Unload(childDomain);
            }
        }

        public List<String> LoadAssemblyTypes(FileInfo assemblyLocation)
        {
            var namespaces = new List<String>();

            if (string.IsNullOrEmpty(assemblyLocation.Directory.FullName))
            {
                throw new InvalidOperationException(
                    "Directory can't be null or empty.");
            }

            if (!Directory.Exists(assemblyLocation.Directory.FullName))
            {
                throw new InvalidOperationException(
                   string.Format(CultureInfo.CurrentCulture,
                   "Directory not found {0}",
                   assemblyLocation.Directory.FullName));

            }

            AppDomain childDomain = BuildChildDomain(
                AppDomain.CurrentDomain);

            try
            {
                Type loaderType = typeof(AssemblyLoader);
                if (loaderType.Assembly != null)
                {
                    var loader =
                        (AssemblyLoader)childDomain.
                            CreateInstanceFrom(
                            loaderType.Assembly.Location,
                            loaderType.FullName).Unwrap();

                    loader.LoadAssembly(
                        assemblyLocation.FullName);
                    namespaces =
                        loader.GetTypes(
                        assemblyLocation.Directory.FullName);
                }
                return namespaces;
            }
            finally
            {
                AppDomain.Unload(childDomain);
            }
        }

        public List<string> LoadAssemblyXmlResources(FileInfo assemblyLocation)
        {
            var namespaces = new List<string>();

            if (string.IsNullOrEmpty(assemblyLocation.Directory.FullName))
            {
                throw new InvalidOperationException(
                    "Directory can't be null or empty.");
            }

            if (!Directory.Exists(assemblyLocation.Directory.FullName))
            {
                throw new InvalidOperationException(
                   string.Format(CultureInfo.CurrentCulture,
                   "Directory not found {0}",
                   assemblyLocation.Directory.FullName));

            }

            AppDomain childDomain = BuildChildDomain(AppDomain.CurrentDomain);

            try
            {
                Type loaderType = typeof(AssemblyLoader);
                if (loaderType.Assembly != null)
                {
                    var loader =
                        (AssemblyLoader)childDomain.
                            CreateInstanceFrom(
                            loaderType.Assembly.Location,
                            loaderType.FullName).Unwrap();

                    loader.LoadAssembly(
                        assemblyLocation.FullName);
                    namespaces =
                        loader.GetXmlResources(
                        assemblyLocation.Directory.FullName);
                }
                return namespaces;
            }
            finally
            {
                AppDomain.Unload(childDomain);
            }
        }


        #endregion

        #region Private Methods
        /// <span class="code-SummaryComment"><summary></span>
        /// Creates a new AppDomain based on the parent AppDomains 
        /// Evidence and AppDomainSetup
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="parentDomain">The parent AppDomain</param></span>
        /// <span class="code-SummaryComment"><returns>A newly created AppDomain</returns></span>
        private AppDomain BuildChildDomain(AppDomain parentDomain)
        {
            Evidence evidence = new Evidence(parentDomain.Evidence);
            AppDomainSetup setup = parentDomain.SetupInformation;
            return AppDomain.CreateDomain("DiscoveryRegion",
                evidence, setup);
        }
        #endregion


        /// <span class="code-SummaryComment"><summary></span>
        /// Remotable AssemblyLoader, this class 
        /// inherits from <span class="code-SummaryComment"><c>MarshalByRefObject</c> </span>
        /// to allow the CLR to marshall
        /// this object by reference across 
        /// AppDomain boundaries
        /// <span class="code-SummaryComment"></summary></span>
        class AssemblyLoader : MarshalByRefObject
        {
            #region Private/Internal Methods
            /// <span class="code-SummaryComment"><summary></span>
            /// Gets namespaces for ReflectionOnly Loaded Assemblies
            /// <span class="code-SummaryComment"></summary></span>
            /// <span class="code-SummaryComment"><param name="path">The path to the Assembly</param></span>
            /// <span class="code-SummaryComment"><returns>A List of namespace strings</returns></span>
            [SuppressMessage("Microsoft.Performance",
                "CA1822:MarkMembersAsStatic")]
            internal List<String> GetNamespaces(string path)
            {

                List<String> namespaces = new List<String>();

                DirectoryInfo directory = new DirectoryInfo(path);
                ResolveEventHandler resolveEventHandler =
                    (s, e) =>
                    {
                        return OnReflectionOnlyResolve(
                            e, directory);
                    };

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve
                    += resolveEventHandler;

                Assembly reflectionOnlyAssembly =
                    AppDomain.CurrentDomain.
                        ReflectionOnlyGetAssemblies().First();

                foreach (Type type in reflectionOnlyAssembly.GetTypes())
                {
                    if (!namespaces.Contains(type.Namespace))
                        namespaces.Add(type.Namespace);
                }

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve
                    -= resolveEventHandler;
                return namespaces;

            }

            internal List<string> GetTypes(string path)
            {

                var namespaces = new List<string>();

                DirectoryInfo directory = new DirectoryInfo(path);
                ResolveEventHandler resolveEventHandler =
                    (s, e) =>
                    {
                        return OnReflectionOnlyResolve(
                            e, directory);
                    };

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve
                    += resolveEventHandler;

                Assembly reflectionOnlyAssembly =
                    AppDomain.CurrentDomain.
                        ReflectionOnlyGetAssemblies().First();

                foreach (Type type in reflectionOnlyAssembly.GetTypes())
                {
                    if (!namespaces.Contains(type.FullName))
                        namespaces.Add(type.FullName);
                }

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve
                    -= resolveEventHandler;
                return namespaces;

            }

            internal List<string> GetXmlResources(string assemblyPath)
            {

                var streamList = new List<string>();

                var directory = new DirectoryInfo(assemblyPath);
                ResolveEventHandler resolveEventHandler =
                    (s, e) =>
                    {
                        return OnReflectionOnlyResolve(
                            e, directory);
                    };

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += resolveEventHandler;

                Assembly reflectionOnlyAssembly = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().First();

                foreach (string resourceName in reflectionOnlyAssembly.GetManifestResourceNames())
                {
                    if (resourceName.EndsWith(".xml"))
                    {
                        var stream = reflectionOnlyAssembly.GetManifestResourceStream(resourceName);
                        var file = "UserDefined_" + GetTempFileName(".xml");
                        var fileName = Path.Combine(assemblyPath, file);

                        using (var output = new FileStream(fileName, FileMode.Create))
                        {
                            if (!streamList.Contains(fileName))
                            {
                                stream.CopyTo(output);
                            
                                streamList.Add(fileName);
                            }
                        }
                    }
                }

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= resolveEventHandler;
                return streamList;
            }

            public static string GetTempFileName(string extension)
            {
                return Guid.NewGuid().ToString() + extension;
            }

            /// <span class="code-SummaryComment"><summary></span>
            /// Attempts ReflectionOnlyLoad of current 
            /// Assemblies dependants
            /// <span class="code-SummaryComment"></summary></span>
            /// <span class="code-SummaryComment"><param name="args">ReflectionOnlyAssemblyResolve </span>
            /// event args<span class="code-SummaryComment"></param></span>
            /// <span class="code-SummaryComment"><param name="directory">The current Assemblies </span>
            /// Directory<span class="code-SummaryComment"></param></span>
            /// <span class="code-SummaryComment"><returns>ReflectionOnlyLoadFrom loaded</span>
            /// dependant Assembly<span class="code-SummaryComment"></returns></span>
            private Assembly OnReflectionOnlyResolve(
                ResolveEventArgs args, DirectoryInfo directory)
            {

                Assembly loadedAssembly =
                    AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies()
                        .FirstOrDefault(
                          asm => string.Equals(asm.FullName, args.Name,
                              StringComparison.OrdinalIgnoreCase));

                if (loadedAssembly != null)
                {
                    return loadedAssembly;
                }

                AssemblyName assemblyName =
                    new AssemblyName(args.Name);
                string dependentAssemblyFilename =
                    Path.Combine(directory.FullName,
                    assemblyName.Name + ".dll");

                if (File.Exists(dependentAssemblyFilename))
                {
                    return Assembly.ReflectionOnlyLoadFrom(
                        dependentAssemblyFilename);
                }
                return Assembly.ReflectionOnlyLoad(args.Name);
            }


            /// <span class="code-SummaryComment"><summary></span>
            /// ReflectionOnlyLoad of single Assembly based on 
            /// the assemblyPath parameter
            /// <span class="code-SummaryComment"></summary></span>
            /// <span class="code-SummaryComment"><param name="assemblyPath">The path to the Assembly</param></span>
            [SuppressMessage("Microsoft.Performance",
                "CA1822:MarkMembersAsStatic")]
            internal void LoadAssembly(String assemblyPath)
            {
                try
                {
                    Assembly.ReflectionOnlyLoadFrom(assemblyPath);
                }
                catch (FileNotFoundException)
                {
                    /* Continue loading assemblies even if an assembly
                     * can not be loaded in the new AppDomain. */
                }
            }
            #endregion
        }

        public List<Stream> LoadAssemblyResourceStreams(FileInfo fileInfo)
        {
            throw new NotImplementedException();
        }
    }
}
