// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetTimeout.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to select a Timeout
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.SpecificFlows
{
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.Functions.ApplicationArea.Execution;
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.GUI;

    /// <summary>
    /// Provides a method to select a Timeout
    /// </summary>
    public static class SetTimeout
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
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
