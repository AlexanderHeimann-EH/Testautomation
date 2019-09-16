// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssemblyInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Contains the interface for information about an assembly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    /// The interface for information about an assembly.
    /// </summary>
    public interface IAssemblyInformation
    {
        #region Public Properties

        /// <summary>
        /// Gets the company.
        /// </summary>
        string Company { get; }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        string Copyright { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the product name.
        /// </summary>
        string ProductName { get; }

        /// <summary>
        /// Gets the product title.
        /// </summary>
        string ProductTitle { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Gets the assembly.
        /// </summary>
        /// <value>The assembly.</value>
        Assembly Assembly { get; }

        #endregion
    }
}
