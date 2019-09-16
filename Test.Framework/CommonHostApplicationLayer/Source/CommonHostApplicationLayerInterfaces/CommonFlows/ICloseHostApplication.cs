// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICloseHostApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for closing a HostApplication
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    ///     Provides methods for closing a HostApplication
    /// </summary>
    public interface ICloseHostApplication
    {
        /// <summary>
        ///     Closes the HostApplication 
        /// </summary>
        /// <returns>true in case of success;false in case of an error</returns>
        bool Run();

        /// <summary>
        /// Closes the HostApplication
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time for action to finish</param>
        /// <returns>true in case of success;false in case of an error</returns>
        bool Run(int timeOutInMilliseconds);
    }
}