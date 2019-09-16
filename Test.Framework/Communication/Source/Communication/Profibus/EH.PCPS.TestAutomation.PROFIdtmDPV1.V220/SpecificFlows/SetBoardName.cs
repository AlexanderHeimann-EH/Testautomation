// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetBoardName.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to set the board name
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V220.SpecificFlows
{
    /// <summary>
    /// Provides a method to set the board name
    /// </summary>
    public class SetBoardName
    {
        /// <summary>
        /// Sets the "Board Name" combo box to a specific value
        /// </summary>
        /// <param name="value">The value of the list item to set</param>
        /// <returns>
        ///     <br>True: if the correct list item was selected</br>
        ///     <br>False: if the item could not be selected, does not exist or another error occurred</br>
        /// </returns>
        public bool Run(string value)
        {
            var setParam = new Functions.ApplicationArea.Execution.SetParameter();

            return setParam.SetParameterValue(new GUI.ProfIdtmDpv1RepoElements().BoardNameComboBox, new GUI.ProfIdtmDpv1RepoElements().BoardNameComboboxButtonOpen, value);
        }
    }
}
