// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCommunicationUnit.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to select a Communication Unit
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.SpecificFlows
{
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.Functions.ApplicationArea.Execution;
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.GUI;

    /// <summary>
    /// Provides a method to select a Communication Unit
    /// </summary>
    public static class SetCommunicationUnit
    {
        /// <summary>
        /// Sets the 'Communication Unit' combo box to a specific value
        /// </summary>
        /// <param name="value">The value of the list item to select</param>
        /// <returns>
        ///     <br>True: if the correct list item was selected</br>
        ///     <br>False: if the item could not be selected, does not exist or another error occurred</br>
        /// </returns>
        public static bool Run(string value)
        {
            if (SetParameter.SetParameterValue(new CDICommDTMRepoElements().CommUnitCombobox, value))
            {
                return true;
            }
            return false;
        }
    }
}
