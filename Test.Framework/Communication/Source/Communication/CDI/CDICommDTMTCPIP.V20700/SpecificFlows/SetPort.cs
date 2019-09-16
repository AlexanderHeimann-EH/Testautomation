// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetPort.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to set Port
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.SpecificFlows
{
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.Functions.ApplicationArea.Execution;
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.GUI;

    /// <summary>
    /// Provides a method to set the Baud rate
    /// </summary>
    public static class SetPort
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
            if (SetParameterInText.SetParameterValue(new CDICommDTMRepoElements().TextPort, value))
            {
                return true;
            }

            return false;
        }
    }
}
