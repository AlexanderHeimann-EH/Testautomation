// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateNetwork.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The CreateNetwork interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows
{
    /// <summary>
    /// The CreateNetwork interface.
    /// </summary>
    public interface ICreateNetwork
    {
        #region Public Methods and Operators

        /// <summary>
        /// Creates network (scan for device) via menu. Waits for the action to finish and reports the result. Sets the network tag for the device.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// Timeout for the scanning progress in milliseconds.
        /// </param>
        /// <param name="networkTag">
        /// The network Tag for the device.
        /// </param>
        /// <returns>
        /// <c>true</c> if scanning finished successfully, <c>false</c> otherwise.
        /// </returns>
        bool Run(int timeoutInMilliseconds, string networkTag);

        #endregion
    }
}