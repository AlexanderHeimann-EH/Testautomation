// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoaderHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Provides helper functions for methods related to Loader
    /// </summary>
    public static class LoaderHelper
    {
        /// <summary>
        /// 'key' is assembly name
        /// 'value is the related assembly
        /// </summary>
        private static readonly Dictionary<string, Assembly> AssemblyProvider = new Dictionary<string, Assembly>();

        /// <summary>
        /// Pre load all needed assemblies
        /// </summary>
        public static void InitializeAssemblyProvider()
        {
            try
            {
                AddAssembly(Configurator.BO.Configuration.HostApplication);
                AddAssembly(Configurator.BO.Configuration.Communication);
                AddAssembly(Configurator.BO.Configuration.OperatingSystem);
                AddAssembly(Configurator.BO.Configuration.DeviceFunction);
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        /// <summary>
        /// Provides an instance of an specific Assembly
        /// </summary>
        /// <param name="executionDirectory">Key for dictionary</param>
        /// <param name="namespacePath">Namespace for specific function</param>
        /// <returns>
        /// <br>Object: in case of success</br>
        /// <br>Null: in case of an error</br>
        /// </returns>
        public static object CreateInstance(string executionDirectory, string namespacePath)
        {
            try
            {
                Assembly assembly = AssemblyProvider[executionDirectory];
                if (assembly != null)
                {
                    object instance = assembly.CreateInstance(namespacePath);

                    if (instance != null)
                    {
                        return instance;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not create instance of object: " + namespacePath);
                    return null;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not load assembly");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Get assembly names as debug information
        /// </summary>
        public static void GetLoadedAssemblyNames()
        {
            foreach (var item in AssemblyProvider)
            {
                System.Diagnostics.Debug.Print(item.Key);
            }
        }

        /// <summary>
        /// Adds an assembly to the assembly dictionary
        /// </summary>
        /// <param name="executionDirectory">Location of assembly</param>
        private static void AddAssembly(string executionDirectory)
        {
            Assembly assembly = Assembly.LoadFrom(executionDirectory + ".dll");
            if (!AssemblyProvider.ContainsKey(executionDirectory))
            {
                AssemblyProvider.Add(executionDirectory, assembly);
            }
        }
    }
}