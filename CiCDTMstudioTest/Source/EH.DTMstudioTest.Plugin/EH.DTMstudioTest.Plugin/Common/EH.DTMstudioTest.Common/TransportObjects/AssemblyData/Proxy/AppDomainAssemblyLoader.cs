// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppDomainAssemblyLoader.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The seperate app domain assembly loader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Remoting;
    using System.Security.Policy;

    using EH.DTMstudioTest.Common.Interfaces;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.PCPS.TestAutomation.Common.Attributes;
    using Log = EH.DTMstudioTest.Common.Utilities.Logging.Log;

    /// <summary>
    /// The app domain assembly loader.
    /// </summary>
    public class AppDomainAssemblyLoader : MarshalByRefObject
    {
        #region Fields

        /// <summary>
        /// The child domain. 
        /// </summary>
        private AppDomain childDomain;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDomainAssemblyLoader"/> class.
        /// </summary>
        public AppDomainAssemblyLoader()
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The export test result.
        /// </summary>
        /// <param name="assemblyLocation">
        /// The assembly location.
        /// </param>
        /// <param name="pathToReport">
        /// The path to report.
        /// </param>
        /// <param name="testName">
        /// The test name.
        /// </param>
        /// <param name="dtMstudioTestTempData">
        /// The dt mstudio test temp data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ExportTestResult(FileInfo assemblyLocation, string pathToReport, string testName, DTMstudioTestData dtMstudioTestTempData)
        {
            var loader = this.LoadAppDomain(assemblyLocation);
            if (assemblyLocation.Directory != null)
            {
                return loader.ExportTestResult(assemblyLocation, pathToReport, testName, dtMstudioTestTempData);
            }

            return false;
        }

        /// <summary>
        /// The get test script information methods info.
        /// </summary>
        /// <param name="assemblyLocation">
        /// The assembly location. 
        /// </param>
        /// <returns>
        /// The <see cref="EhMethodInfoCollection"/>.
        /// </returns>
        public EhMethodInfoCollection GetTestScriptInformationMethodsInfo(FileInfo assemblyLocation)
        {
            var loader = this.LoadAppDomain(assemblyLocation);
            if (assemblyLocation.Directory != null)
            {
                return loader.GetTestScriptInformationMethodsInfos(assemblyLocation.Directory.FullName, assemblyLocation.FullName);
            }

            return null;
        }

        /// <summary>
        /// The load assembly xml resources.
        /// </summary>
        /// <param name="assemblyLocation">
        /// The assembly location.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public EhResourceCollection LoadAssemblyXmlResources(FileInfo assemblyLocation)
        {
            var loader = this.LoadAppDomain(assemblyLocation);
            return loader.GetXmlResources(assemblyLocation);
        }

        /// <summary>
        /// The unload app domain.
        /// </summary>
        public void UnloadAppDomain()
        {
            AppDomain.Unload(this.childDomain);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The build child domain.
        /// </summary>
        /// <param name="parentDomain">
        /// The parent domain.
        /// </param>
        /// <returns>
        /// The <see cref="AppDomain"/>.
        /// </returns>
        private AppDomain BuildChildDomain(AppDomain parentDomain)
        {
            Evidence evidence = new Evidence(parentDomain.Evidence);
            AppDomainSetup setup = parentDomain.SetupInformation;
            return AppDomain.CreateDomain("DiscoveryRegion", evidence, setup);
        }

        /// <summary>
        /// The load app domain.
        /// </summary>
        /// <param name="assemblyLocation">
        /// The assembly location.
        /// </param>
        /// <returns>
        /// The <see cref="AssemblyLoader"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        private AssemblyLoader LoadAppDomain(FileInfo assemblyLocation)
        {
            if (string.IsNullOrEmpty(assemblyLocation.Directory.FullName))
            {
                throw new InvalidOperationException("Directory can't be null or empty.");
            }

            if (!Directory.Exists(assemblyLocation.Directory.FullName))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Directory not found {0}", assemblyLocation.Directory.FullName));
            }

            this.childDomain = this.BuildChildDomain(AppDomain.CurrentDomain);

            Type loaderType = typeof(AssemblyLoader);
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => { return Assembly.LoadFrom(loaderType.Assembly.Location); };

            var loader = (AssemblyLoader)this.childDomain.CreateInstanceFrom(loaderType.Assembly.Location, loaderType.FullName).Unwrap();

            loader.LoadAssembly(assemblyLocation.FullName);
            return loader;
        }

        #endregion
    }

    /// <summary>
    /// The assembly loader.
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class AssemblyLoader : MarshalByRefObject
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyLoader"/> class.
        /// </summary>
        public AssemblyLoader()
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get temp file name.
        /// </summary>
        /// <param name="extension">
        /// The extension.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetTempFileName(string extension)
        {
            return Guid.NewGuid().ToString() + extension;
        }

        /// <summary>
        /// The export test result.
        /// </summary>
        /// <param name="assemblyLocation">
        /// The assembly location.
        /// </param>
        /// <param name="pathToReport">
        /// The path to report.
        /// </param>
        /// <param name="testName">
        /// The test name.
        /// </param>
        /// <param name="dtmStudioTestTempData">
        /// The dt mstudio test temp data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ExportTestResult(FileInfo assemblyLocation, string pathToReport, string testName, DTMstudioTestData dtmStudioTestTempData)
        {
            var directory = new DirectoryInfo(assemblyLocation.Directory.FullName);
            var result = false;
            ResolveEventHandler resolveEventHandler = (s, e) => { return this.OnResolve(e, directory); };
            AppDomain.CurrentDomain.AssemblyResolve += resolveEventHandler;

            Assembly.LoadFrom(assemblyLocation.FullName);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var assembly = assemblies.First(a => a.Location == assemblyLocation.FullName);

            var instances = from t in assembly.GetTypes() where t.GetInterfaces().Contains(typeof(IExportResultToTestManagement)) && t.GetConstructor(Type.EmptyTypes) != null select Activator.CreateInstance(t) as IExportResultToTestManagement;

            foreach (var instance in instances)
            {
                try
                {
                    result = instance.ExportTestResult(pathToReport, testName, dtmStudioTestTempData);
                    break;
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(this, ex, MethodBase.GetCurrentMethod().Name);   
                    return result;
                }
            }

            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= resolveEventHandler;
            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get methods infos.
        /// </summary>
        /// <param name="directoryName">
        /// The directory name.
        /// </param>
        /// <param name="assemblyFileName">
        /// The assembly file name.
        /// </param>
        /// <returns>
        /// The <see cref="EhMethodInfo"/>.
        /// </returns>
        internal EhMethodInfoCollection GetTestScriptInformationMethodsInfos(string directoryName, string assemblyFileName)
        {
            var methodInfos = new EhMethodInfoCollection();

            var directory = new DirectoryInfo(directoryName);
            ResolveEventHandler resolveEventHandler = (s, e) => { return this.OnReflectionOnlyResolve(e, directory); };

            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += resolveEventHandler;
            Assembly reflectionOnlyAssembly = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().First();

            foreach (Type type in reflectionOnlyAssembly.GetTypes())
            {
                try
                {
                    ObjectHandle oh = Activator.CreateInstanceFrom(assemblyFileName, type.ToString());
                    object o = oh.Unwrap();
                    Type to = o.GetType();

                    foreach (var methodInfo in to.GetMethods())
                    {
                        var customAttributes = methodInfo.GetCustomAttributes(false);

                        if (customAttributes.Length > 0)
                        {
                            foreach (var customAttribut in customAttributes)
                            {
                                if (customAttribut is TestScriptInformation)
                                {
                                    var ehMethodInfo = new EhMethodInfo();

                                    ehMethodInfo.ParameterInfo = this.GetParameterInfos(methodInfo);

                                    ehMethodInfo.CustomAttributGuid = (customAttribut as TestScriptInformation).Guid;
                                    ehMethodInfo.CustomAttributTestDefinition = (customAttribut as TestScriptInformation).TestDefinition.ToString();
                                    ehMethodInfo.CustomAttributTestScript = (customAttribut as TestScriptInformation).TestScript;

                                    ehMethodInfo.MethodFullName = methodInfo.DeclaringType.FullName;

                                    // ehMethodInfo.AssemblyFullPath = methodInfo.DeclaringType.Assembly.Location;
                                    ehMethodInfo.AssemblyFullPath = assemblyFileName;

                                    ehMethodInfo.MethodName = methodInfo.Name;
                                    ehMethodInfo.MethodDisplayName = this.GetDisplayName(methodInfo);
                                    ehMethodInfo.Namespace = methodInfo.DeclaringType.Namespace;
                                    ehMethodInfo.ClassName = methodInfo.ReflectedType.Name;
                                    ehMethodInfo.MemberType = methodInfo.MemberType.ToString();

                                    methodInfos.Add(ehMethodInfo);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorEx(this, ex, MethodBase.GetCurrentMethod().Name);   
                    string test = string.Empty;
                }
            }

            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= resolveEventHandler;
            return methodInfos;
        }

        /// <summary>
        /// The get xml resources.
        /// </summary>
        /// <param name="fileinfo">
        /// The fileinfo.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        internal EhResourceCollection GetXmlResources(FileInfo fileinfo)
        {
            var streamList = new EhResourceCollection();

            var directory = new DirectoryInfo(fileinfo.Directory.FullName);
            ResolveEventHandler resolveEventHandler = (s, e) => { return this.OnReflectionOnlyResolve(e, directory); };

            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += resolveEventHandler;
            Assembly reflectionOnlyAssembly = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().First();

            foreach (string resourceName in reflectionOnlyAssembly.GetManifestResourceNames())
            {
                if (resourceName.EndsWith(".xml"))
                {
                    var stream = reflectionOnlyAssembly.GetManifestResourceStream(resourceName);
                    var fileName = Path.Combine(Path.GetTempPath(), resourceName);

                    using (var output = new FileStream(fileName, FileMode.Create))
                    {
                        var resourc = new EhResourceInfo { ResourceNameFullPath = fileName, ResourceName = resourceName };

                        if (!streamList.Contains(resourc))
                        {
                            if (stream != null)
                            {
                                stream.CopyTo(output);
                                streamList.Add(resourc);
                            }
                        }
                    }
                }
            }

            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= resolveEventHandler;
            return streamList;
        }

        /// <summary>
        /// The load assembly.
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        internal void LoadAssembly(string assemblyPath)
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

        /// <summary>
        /// The get display name.
        /// </summary>
        /// <param name="methodInfo">
        /// The method info.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetDisplayName(MethodInfo methodInfo)
        {
            var returnType = this.GetReturnType(methodInfo);

            var methodName = methodInfo.Name;

            var parameter = string.Empty;

            for (var i = 0; i < methodInfo.GetParameters().Length; i++)
            {
                if (!string.IsNullOrEmpty(parameter))
                {
                    parameter += ", ";
                }

                parameter += this.GetParamName(methodInfo, i);
            }

            return string.Format("{0} {1}({2})", returnType, methodName, parameter).Replace("List`1", "List");
        }

        /// <summary>
        /// The get param name.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetParamName(MethodInfo method, int index)
        {
            string retVal = string.Empty;

            if (method != null && method.GetParameters().Length > index)
            {
                retVal = method.GetParameters()[index].Name;
            }

            return retVal;
        }

        /// <summary>
        /// The get parameter infos.
        /// </summary>
        /// <param name="methodInfo">
        /// The method info.
        /// </param>
        /// <returns>
        /// The <see cref="EhParameterInfoCollection"/>.
        /// </returns>
        private EhParameterInfoCollection GetParameterInfos(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            var ehParameterInfos = new EhParameterInfoCollection();

            for (var i = 0; i < parameters.Count(); i++)
            {
                ehParameterInfos.Add(new EhParameterInfo { Name = parameters[i].Name, ParameterType = parameters[i].ParameterType.FullName });
            }

            return ehParameterInfos;
        }

        /// <summary>
        /// The get return type.
        /// </summary>
        /// <param name="methodInfo">
        /// The method info.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetReturnType(MethodInfo methodInfo)
        {
            if (methodInfo != null && methodInfo.ReturnType.Namespace != null)
            {
                if (methodInfo.ReturnType.Namespace != null)
                {
                    var returnType = methodInfo.ReturnType.ToString().Replace(methodInfo.ReturnType.Namespace, string.Empty);

                    if (returnType[0] == '.')
                    {
                        returnType = returnType.TrimStart('.');
                    }

                    return returnType;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// The on reflection only resolve.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <param name="directory">
        /// The directory.
        /// </param>
        /// <returns>
        /// The <see cref="Assembly"/>.
        /// </returns>
        private Assembly OnReflectionOnlyResolve(ResolveEventArgs args, DirectoryInfo directory)
        {
            Assembly loadedAssembly = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().FirstOrDefault(asm => string.Equals(asm.FullName, args.Name, StringComparison.OrdinalIgnoreCase));

            if (loadedAssembly != null)
            {
                return loadedAssembly;
            }

            var assemblyName = new AssemblyName(args.Name);
            var dependentAssemblyFilename = Path.Combine(directory.FullName, assemblyName.Name + ".dll");

            if (File.Exists(dependentAssemblyFilename))
            {
                return Assembly.ReflectionOnlyLoadFrom(dependentAssemblyFilename);
            }

            return Assembly.ReflectionOnlyLoad(args.Name);
        }

        /// <summary>
        /// The on resolve.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <param name="directory">
        /// The directory.
        /// </param>
        /// <returns>
        /// The <see cref="Assembly"/>.
        /// </returns>
        private Assembly OnResolve(ResolveEventArgs args, DirectoryInfo directory)
        {
            Assembly loadedAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(asm => string.Equals(asm.FullName, args.Name, StringComparison.OrdinalIgnoreCase));

            if (loadedAssembly != null)
            {
                return loadedAssembly;
            }

            var assemblyName = new AssemblyName(args.Name);
            var dependentAssemblyFilename = Path.Combine(directory.FullName, assemblyName.Name + ".dll");

            if (File.Exists(dependentAssemblyFilename))
            {
                return Assembly.LoadFrom(dependentAssemblyFilename);
            }

            return Assembly.ReflectionOnlyLoad(args.Name);
        }

        #endregion
    }
}