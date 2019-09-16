// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyProxy.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The assembly handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Microsoft.CSharp;

    /// <summary>
    /// The assembly handler.
    /// </summary>
    public class AssemblyProxy
    {
        #region Public Methods and Operators

        /// <summary>
        /// The compile assembly.
        /// </summary>
        /// <param name="sourceFiles">
        /// The source files.
        /// </param>
        /// <param name="referencedAssemblies">
        /// The referenced assemblies.
        /// </param>
        /// <param name="outputAssemblyPath">
        /// The output assembly path.
        /// </param>
        /// <returns>
        /// The <see cref="Assembly"/>.
        /// </returns>
        public static Assembly CompileAssembly(string[] sourceFiles, List<string> referencedAssemblies, string outputAssemblyPath)
        {
            var codeProvider = new CSharpCodeProvider();

            var compilerParameters = new CompilerParameters 
            { 
                GenerateExecutable = false, // Make a DLL
                GenerateInMemory = false, // Explicitly save it to path specified by compilerParameters.OutputAssembly
                IncludeDebugInformation = true, // Enable debugging - generate .pdb
                OutputAssembly = outputAssemblyPath 
            };

            // !! This is important: It adds the THIS project as a reference to the compiled dll to expose the public interfaces (as you would add it in the visual studio)
            // compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            foreach (var referencedAssembly in referencedAssemblies)
            {
                compilerParameters.ReferencedAssemblies.Add(referencedAssembly);
            }

            var result = codeProvider.CompileAssemblyFromFile(compilerParameters, sourceFiles); // Compile

            if (result.Errors.HasErrors)
            {
                throw new Exception("Assembly compilation failed.");
            }

            return result.CompiledAssembly;
        }

        /// <summary>
        /// The get test script methods from assembly.
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        /// <returns>
        /// The <see cref="EhMethodInfoCollection"/>.
        /// </returns>
        public static EhMethodInfoCollection GetTestScriptMethodsFromAssembly(string assemblyPath)
        {
            var seperateAppDomainAssemblyLoader = new AppDomainAssemblyLoader();
            var tempFile = Path.GetTempFileName();
            EhMethodInfoCollection methodInfo;

            try
            {
                var tempMethodFile = seperateAppDomainAssemblyLoader.GetTestScriptInformationMethodsInfo(new FileInfo(assemblyPath));

                tempMethodFile.Save(tempFile);
                methodInfo = new EhMethodInfoCollection();
                methodInfo.Load(tempFile);
            }
            finally
            {
                File.Delete(tempFile);

                seperateAppDomainAssemblyLoader.UnloadAppDomain();
            }

            return methodInfo;
        }

        /// <summary>
        /// The get test suites file from assembly.
        /// </summary>
        /// <param name="loadingAssemblyName">
        /// The assembly path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static EhResourceCollection GetTestSuitesFileFromAssembly(string loadingAssemblyName)
        {
            var seperateAppDomainAssemblyLoader = new AppDomainAssemblyLoader();
            var tempFile = Path.GetTempFileName();
            EhResourceCollection resourceCollection;

            try
            {
                var resultList = seperateAppDomainAssemblyLoader.LoadAssemblyXmlResources(new FileInfo(loadingAssemblyName));

                resultList.Save(tempFile);
                resourceCollection = new EhResourceCollection();
                resourceCollection.Load(tempFile);
            }
            finally
            {
                seperateAppDomainAssemblyLoader.UnloadAppDomain();
            }

            return resourceCollection;
        }

        /// <summary>
        /// Returns all types that implement the specified interface.
        /// </summary>
        /// <param name="assembly">
        /// Assembly to search.
        /// </param>
        /// <param name="interfaceType">
        /// Interface that types must implement.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public static List<Type> GetTypesImplementingInterface(Assembly assembly, Type interfaceType)
        {
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("Not an interface.", "interfaceType");
            }

            return assembly.GetTypes().Where(t => interfaceType.IsAssignableFrom(t)).ToList();
        }

        #endregion
    }
}