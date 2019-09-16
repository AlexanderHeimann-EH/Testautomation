//------------------------------------------------------------------------------
// <copyright file="IWaitUntilDtmIsDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Functions.StatusArea.Statusbar.Validation
{
    /// <summary>
    /// The WaitUntilDtmIsDisconnected interface.
    /// </summary>
    public interface IWaitUntilDtmIsDisconnected
    {
        /// <summary>
        ///     Wait until DTM connection is established and shown by GUI
        /// </summary>
        /// ///
        /// <param name="timeOutInMilliseconds">Time until action must be performed</param>
        /// <returns>
        ///     <br>True: if module is disconnected</br>
        ///     <br>False: if module is not disconnected</br>
        /// </returns>
        bool Run(int timeOutInMilliseconds);
    }
}