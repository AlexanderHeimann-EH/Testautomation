// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPrintDeviceInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows
{
    /// <summary>
    /// The PrintDeviceInformation interface.
    /// </summary>
    public interface IPrintDeviceInformation
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="reportType">
        /// The report type.
        /// </param>
        /// <param name="filePathAndName">
        /// The file path and name.
        /// </param>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Run(string reportType, string filePathAndName, int timeoutInMilliseconds);
    }
}
