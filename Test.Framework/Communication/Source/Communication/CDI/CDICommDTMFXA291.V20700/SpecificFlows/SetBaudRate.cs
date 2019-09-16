// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetBaudRate.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to set the Baud rate
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMFXA291.V20700.SpecificFlows
{
    /// <summary>
    /// Provides a method to set the Baud rate
    /// </summary>
    public static class SetBaudRate
    {
        /// <summary>
        /// Sets the "Baud Rate" combo box to a specific value
        /// </summary>
        /// <param name="value">The value of the list item to set</param>
        /// <returns>
        ///     <br>True: if the correct list item was selected</br>
        ///     <br>False: if the item could not be selected, does not exist or another error occurred</br>
        /// </returns>
        public static bool Run(string value)
        {
            if (Functions.ApplicationArea.Execution.SetParameter.SetParameterValue(new GUI.CDICommDTMRepoElements().BaudRateCombobox, value))
            {
                return true;
            }
            return false;
        }
    }
}
