// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadedAssembly.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The loaded assemblies.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy
{
    using System;

    /// <summary>
    /// The loaded assemblies.
    /// </summary>
    [Serializable]
    public class LoadedAssembly
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        public string FullPath { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy.
        /// </summary>
        /// <returns>
        /// The <see cref="LoadedAssembly"/>.
        /// </returns>
        public LoadedAssembly Copy()
        {
            var result = new LoadedAssembly { FullPath = this.FullPath };

            return result;
        }

        #endregion
    }
}