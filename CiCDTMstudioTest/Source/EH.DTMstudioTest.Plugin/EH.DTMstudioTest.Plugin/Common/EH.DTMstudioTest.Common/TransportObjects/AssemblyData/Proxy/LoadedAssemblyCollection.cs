// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadedAssemblyCollection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The loaded assembly collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The loaded assembly collection.
    /// </summary>
    [Serializable]
    public class LoadedAssemblyCollection : List<LoadedAssembly>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="LoadedAssemblyCollection"/>.
        /// </returns>
        public LoadedAssemblyCollection Copy()
        {
            var result = new LoadedAssemblyCollection();

            result.AddRange(this.Select(loadedAssembly => loadedAssembly.Copy()));

            return result;
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="loadedAssembly">
        /// The loaded assembly.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public new bool Contains(LoadedAssembly loadedAssembly)
        {
            return this.Any(assembly => assembly.FullPath == loadedAssembly.FullPath);
        }

        #endregion
    }
}