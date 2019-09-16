//------------------------------------------------------------------------------
// <copyright file="IWaitUntilModuleIsReady.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.AboutBox.Functions.ApplicationArea.MainView.Validation
{
    /// <summary>
    /// The WaitUntilModuleIsReady interface.
    /// </summary>
    public interface IWaitUntilModuleIsReady
    {
        /// <summary>
        ///     Validation if module (online) is ready within a specified time
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time within module should be ready</param>
        /// <returns>
        ///     <br>True: if module is ready in time</br>
        ///     <br>False: if module is not ready in time</br>
        /// </returns>
        bool Run(int timeOutInMilliseconds);
    }
}