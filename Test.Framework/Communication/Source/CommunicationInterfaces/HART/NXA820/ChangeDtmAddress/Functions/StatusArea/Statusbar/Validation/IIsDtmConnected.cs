//------------------------------------------------------------------------------
// <copyright file="IIsDtmConnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Functions.StatusArea.Statusbar.Validation
{
    /// <summary>
    /// The IsDtmConnected interface.
    /// </summary>
    public interface IIsDtmConnected
    {
        /// <summary>
        ///     Determines whether online connection is established
        /// </summary>
        /// <returns>
        ///     true: if DTM is online
        ///     false: if DTM is offline or an error occurred
        /// </returns>
        bool Run();
    }
}