// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyResolverHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Utilities.Helper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Configurator.GUI;

    /// <summary>
    /// The assembly resolver helper.
    /// </summary>
    public static class AssemblyResolverHelper
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="currentDomain">
        /// The current Domain.
        /// </param>
        public static void Initialize(AppDomain currentDomain)
        {
            currentDomain.AssemblyResolve += LoadFromSameFolder;    
        }

        /// <summary>
        /// The load from same folder.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="Assembly"/>.
        /// </returns>
        public static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
        {
            string executionDirectory = null;
            string testpackageDirectory = null;

            string buffer = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (buffer != null)
            {
                executionDirectory = Path.Combine(buffer, new AssemblyName(args.Name).Name + ".dll");
            }

            buffer = ConfiguratorDialog.SelectedConfiguration.TestFramework.PathToAssemblies;
            if (buffer != null)
            {
                testpackageDirectory = Path.Combine(buffer, new AssemblyName(args.Name).Name + ".dll");
            }

            List<string> assemblyPaths = new List<string>();
            assemblyPaths.Add(executionDirectory);
            assemblyPaths.Add(testpackageDirectory);

            foreach (var assemblyPath in assemblyPaths)
            {
                if (File.Exists(assemblyPath))
                {
                    Assembly assembly = Assembly.LoadFrom(assemblyPath);
                    return assembly;
                }
            }

            return null;
        }
    }
}
