// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCommunicationUnit.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to select a Communication Unit
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMFXA291.V20501.SpecificFlows
{
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
            if (Functions.ApplicationArea.Execution.SetParameter.SetParameterValue(new GUI.CDICommDTMRepoElements().CommUnitCombobox, value))
            {
                return true;
            }
            return false;
        }
    }
}
