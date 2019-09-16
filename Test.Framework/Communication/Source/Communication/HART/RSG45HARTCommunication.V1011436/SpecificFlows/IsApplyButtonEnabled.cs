using System;
using System.Reflection;

using Ranorex;
using Ranorex.Core;

using EH.PCPS.TestAutomation.Common;
using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.SpecificFlows
{
    /// <summary>
    /// Provides function to check if the button apply is enabled
    /// </summary>
    public class IsApplyButtonEnabled
    {
        /// <summary>
        /// Checks if the 'Apply' button is enabled
        /// </summary>
        /// <returns>
        /// <br>True: if action was successful</br>
        /// <br>False: if action was unsuccessful or an error occurred</br>
        /// </returns>
        public bool Run()
        {
            Button apply = new GUI.RSG45HARTCommRepoElements().ButtonApply;

            if (apply == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is null. It seems that you called this method before the config page was even opened or, more likely, the control vanished into the deep vast space of the universe");
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No seriously, I could not get an object for the button.");
                return false;
            }
            if (apply.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
