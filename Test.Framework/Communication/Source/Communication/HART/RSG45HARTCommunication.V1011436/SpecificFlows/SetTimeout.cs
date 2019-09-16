using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.SpecificFlows
{
    /// <summary>
    /// Provides a method to set the timeout
    /// </summary>
    public class SetTimeout
    {
        /// <summary>
        /// Sets the "Timeout" combobox to a specific value
        /// </summary>
        /// <param name="value">The value of the listitem to set</param>
        /// <returns>
        ///     <br>True: if the correct listitem was selected</br>
        ///     <br>False: if the item could not be selected, does not exist or another error occurred</br>
        /// </returns>
        public bool Run(string value)
        {
            var setParam = new Functions.ApplicationArea.Execution.SetParameter();

            return setParam.SetParameterValue(new GUI.RSG45HARTCommRepoElements().TimeoutCombobox, new GUI.RSG45HARTCommRepoElements().TimeoutComboButton, value);
        }
    }
}
