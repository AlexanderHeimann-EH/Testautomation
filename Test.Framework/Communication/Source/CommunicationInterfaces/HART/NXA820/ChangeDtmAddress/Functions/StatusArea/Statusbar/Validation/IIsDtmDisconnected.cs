//------------------------------------------------------------------------------
// <copyright file="IIsDtmDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Functions.StatusArea.Statusbar.Validation
{
    /// <summary>
    /// The IsDtmDisconnected interface.
    /// </summary>
    public interface IIsDtmDisconnected
    {
        /// <summary>
        ///     Determines whether connection is offline
        /// </summary>
        /// <returns>
        ///     true: if DTM is offline
        ///     false: if DTM is online or an error occurred
        /// </returns>
        bool Run();
    }
}