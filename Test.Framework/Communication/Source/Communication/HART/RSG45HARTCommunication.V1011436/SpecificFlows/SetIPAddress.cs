using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.SpecificFlows
{
    /// <summary>
    /// Provides a method to set the end address
    /// </summary>
    public class SetIPAddress
    {
        /// <summary>
        /// Sets the "Port" textbox to a specific value
        /// </summary>
        /// <param name="value">The value of the listitem to set</param>
        /// <returns>
        ///     <br>True: if the text was set</br>
        ///     <br>False: if the text could not be set, does not exist or another error occurred</br>
        /// </returns>
        public bool Run(string value)
        {
            var setParam = new Functions.ApplicationArea.Execution.SetParameter();

            return setParam.SetParameterValue(new GUI.RSG45HARTCommRepoElements().IPAddress, value);
        }
    }
}
