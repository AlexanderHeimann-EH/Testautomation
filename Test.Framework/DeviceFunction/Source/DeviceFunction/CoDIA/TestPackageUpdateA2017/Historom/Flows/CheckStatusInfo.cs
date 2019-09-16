// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckStatusInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Flows
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.StatusArea.Usermessages.Execution;

    /// <summary>
    ///     Description of CheckStatusInfo.
    /// </summary>
    public class CheckStatusInfo : ICheckStatusInfo
    {
        /// <summary>
        /// Calls a method to check the status information (down left corner of the module) for errors or failures
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            return new Information().CheckInfo();
        }
    }
}