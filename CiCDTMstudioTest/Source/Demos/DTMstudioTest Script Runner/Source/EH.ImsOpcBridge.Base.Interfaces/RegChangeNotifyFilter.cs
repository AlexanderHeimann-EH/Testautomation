// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegChangeNotifyFilter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Filter for notifications reported by <see cref="RegistryMonitor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Filter for notifications reported by <see cref="IRegistryMonitor"/>.
    /// </summary>
    [Flags]
    [SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "OK here.")]
    public enum RegChangeNotifyFilter
    {
        /// <summary>Notify the caller if a subkey is added or deleted.</summary>
        Key = 1, 

        /// <summary>Notify the caller of changes to the attributes of the key,
        /// such as the security descriptor information.</summary>
        Attribute = 2, 

        /// <summary>Notify the caller of changes to a value of the key. This can
        /// include adding or deleting a value, or changing an existing value.</summary>
        Value = 4, 

        /// <summary>Notify the caller of changes to the security descriptor
        /// of the key.</summary>
        Security = 8, 
    }
}
