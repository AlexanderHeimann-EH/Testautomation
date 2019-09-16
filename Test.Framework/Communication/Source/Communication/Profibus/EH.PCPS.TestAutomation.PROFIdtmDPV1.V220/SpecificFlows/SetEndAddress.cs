// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetEndAddress.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to set the board name
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V220.SpecificFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Provides a method to set the board name
    /// </summary>
    public class SetEndAddress
    {
        /// <summary>
        /// Sets the "End Address" text field to a specific value
        /// </summary>
        /// <param name="value">The value of the list item to set</param>
        /// <returns>
        ///     <br>True: if the text was set to the desired value</br>
        ///     <br>False: if the text could not be set or otherwise errors occurred</br>
        /// </returns>
        public bool Run(string value)
        {
            var setParam = new Functions.ApplicationArea.Execution.SetParameter();
            int intValue = Convert.ToInt32(value);

            // check if value is out of specification to avoid pop ups
            if (intValue > 126 | intValue < 1)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The value to set is not a valid value. Please provide a value between and including 1 and 126");
                return false;
            }

            return setParam.SetParameterValue(new GUI.ProfIdtmDpv1RepoElements().EndAddress, value);
        }
    }
}
