// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCommunicationInterface.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to set the communication interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HARTCommunication.V1052.SpecificFlows
{
    /// <summary>
    /// Provides a method to set the communication interface
    /// </summary>
    public class SetCommunicationInterface
    {
        /// <summary>
        /// Sets the "Communication Interface" combo box to a specific value
        /// </summary>
        /// <param name="value">The value of the list item to set</param>
        /// <returns>
        ///     <br>True: if the correct list item was selected</br>
        ///     <br>False: if the item could not be selected, does not exist or another error occurred</br>
        /// </returns>
        public bool Run(string value)
        {
            var setParam = new Functions.ApplicationArea.Execution.SetParameter();

            return setParam.SetParameterValue(new GUI.HARTCommRepoElements().CommunicationInterfaceCombobox, value);
        }
    }
}
