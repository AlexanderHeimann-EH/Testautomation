// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyManagement.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Contains the helper methods around managing assemblies.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Information
{
    using System;
    using System.Collections.ObjectModel;
    using System.Reflection;

    /// <summary>
    /// Contains the helper methods around managing assemblies.
    /// </summary>
    public static class AssemblyManagement
    {
        #region Public Properties

        /// <summary>
        /// Gets the entry assembly.
        /// </summary>
        public static IAssemblyInformation EntryAssembly
        {
            get
            {
                var entryAssembly = Assembly.GetEntryAssembly();

                return entryAssembly == null ? null : new AssemblyInformation(entryAssembly);
            }
        }

        /// <summary>
        /// Gets the loaded assemblies.
        /// </summary>
        public static ReadOnlyCollection<IAssemblyInformation> LoadedAssemblies
        {
            get
            {
                var loadedAssemblies = new Collection<IAssemblyInformation>();

                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    loadedAssemblies.Add(new AssemblyInformation(assembly));
                }

                return new ReadOnlyCollection<IAssemblyInformation>(loadedAssemblies);
            }
        }

        #endregion
    }
}
