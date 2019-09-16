// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base.Interfaces
// Author           : I02423401
// Created          : 05-07-2013
//
// Last Modified By : I02423401
// Last Modified On : 05-07-2013
// ***********************************************************************
// <copyright file="ITranslatableString.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EH.ImsOpcBridge
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The TranslatableString interface.
    /// </summary>
    public interface ITranslatableString
    {
        #region Public Properties

        /// <summary>
        /// Gets the args.
        /// </summary>
        /// <value>The args.</value>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = @"OK here.")]
        string[] Args { get; }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>The name of the assembly.</value>
        string AssemblyName { get; }

        /// <summary>
        /// Gets the name of the base.
        /// </summary>
        /// <value>The name of the base.</value>
        string BaseName { get; }

        /// <summary>
        /// Gets the name of the format resource.
        /// </summary>
        /// <value>The name of the format resource.</value>
        string FormatResourceName { get; }

        /// <summary>
        /// Gets the missing string.
        /// </summary>
        /// <value>The missing string.</value>
        string MissingString { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        string ToString();

        #endregion
    }
}
