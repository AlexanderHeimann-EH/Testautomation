// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetIpAddress.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to set Ip Address
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.SpecificFlows
{
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.Functions.ApplicationArea.Execution;
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.GUI;

    /// <summary>
    /// Provides a method to set the Baud rate
    /// </summary>
    public static class SetIpAddress
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
            if (SetParameterInText.SetParameterValue(new CDICommDTMRepoElements().TextIpAddress, value))
            {
                return true;
            }

            return false;
        }
    }
}
