//------------------------------------------------------------------------------
// <copyright file="IWaitUntilDtmIsConnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDeviceAddress.Functions.StatusArea.Statusbar.Validation
{
    /// <summary>
    /// The WaitUntilDtmIsConnected interface.
    /// </summary>
    public interface IWaitUntilDtmIsConnected
    {
        /// <summary>
        ///     Wait until DTM connection is established and shown by GUI
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time until action must be performed</param>
        /// <returns>
        ///     <br>True: if module is connected</br>
        ///     <br>False: if module is not connected</br>
        /// </returns>
        bool Run(int timeOutInMilliseconds);
    }
}