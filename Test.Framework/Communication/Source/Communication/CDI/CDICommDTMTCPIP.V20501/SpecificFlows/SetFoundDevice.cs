// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetFoundDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to select Found Device
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.SpecificFlows
{
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.Functions.ApplicationArea.Execution;
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.GUI;

    /// <summary>
    /// Provides a method to set Found Device
    /// </summary>
    public static class SetFoundDevice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value of the list item to set</param>
        /// <returns>
        /// 
        /// </returns>
        public static bool Run(string value)
        {
            if (SetParameterInComboBox.SetParameterValue(new CDICommDTMRepoElements().ButtonFoundDevices, value))
            {
                return true;
            }

            return false;
        }
    }
}
