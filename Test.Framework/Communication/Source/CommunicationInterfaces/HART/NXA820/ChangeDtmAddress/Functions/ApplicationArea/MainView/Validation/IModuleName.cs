//------------------------------------------------------------------------------
// <copyright file="IModuleName.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Functions.ApplicationArea.MainView.Validation
{
    /// <summary>
    /// The ModuleName interface.
    /// </summary>
    public interface IModuleName
    {
        /// <summary>
        /// Gets name of actual module
        /// </summary>
        string Name { get; }
    }
}