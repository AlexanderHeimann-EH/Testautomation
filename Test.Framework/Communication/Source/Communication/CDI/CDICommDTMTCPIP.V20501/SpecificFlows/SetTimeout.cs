// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCommunicationUnit.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to select a Timeout
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.SpecificFlows
{
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.Functions.ApplicationArea.Execution;
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.GUI;

    /// <summary>
    /// Provides a method to select a Timeout
    /// </summary>
    public static class SetTimeout
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value of the list item to select</param>
        /// <returns>
        /// 
        /// </returns>
        public static bool Run(string value)
        {
            if (SetParameterInComboBox.SetParameterValue((new CDICommDTMRepoElements()).ButtonTimeout, value))
            {
                return true;
            }
            return false;
        }
    }
}
