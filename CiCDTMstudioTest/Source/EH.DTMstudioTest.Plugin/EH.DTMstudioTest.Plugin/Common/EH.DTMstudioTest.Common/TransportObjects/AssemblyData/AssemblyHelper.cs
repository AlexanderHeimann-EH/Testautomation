// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The assembly handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using Microsoft.CSharp;

    /// <summary>
    /// The assembly handler.
    /// </summary>
    public class AssemblyHelper
    {
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

            var compilerParameters = new CompilerParameters { GenerateExecutable = false, // Make a DLL
                                                              GenerateInMemory = false, // Explicitly save it to path specified by compilerParameters.OutputAssembly
                                                              IncludeDebugInformation = true, // Enable debugging - generate .pdb
                                                              OutputAssembly = outputAssemblyPath };

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
        /// The create assembly temp file.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string CreateAssemblyTempFile(string assemblyName)
        {
            var orginalFileName = GetOrginalAssemblyName(assemblyName);

            return Path.Combine(Path.GetTempPath(), orginalFileName + "_" + GetTempFileName(".dll"));
        }

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
        /// The get orginal assembly name.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetOrginalAssemblyName(string assemblyName)
        {
            // dann ist es eine Temporäre Datei.
            var orgAssemblyName = assemblyName.Split(new[] { ".cs" }, StringSplitOptions.None);
            if (orgAssemblyName.Length > 1)
            {
                return orgAssemblyName[0] + ".cs";
            }

            orgAssemblyName = assemblyName.Split(new[] { ".dll" }, StringSplitOptions.None);
            if (orgAssemblyName.Length > 1)
            {
                return orgAssemblyName[0] + ".dll";
            }

            return Path.GetFileName(assemblyName);
        }
    }
}