using System;
using System.Collections.Generic;
using System.Reflection;

using Ranorex;
using Ranorex.Core;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.Functions.ApplicationArea.Validation
{
    /// <summary>
    /// Checks if a module is ready
    /// </summary>
    public class IsModuleReady
    {
        /// <summary>
        /// Checks if button [Apply] is available
        /// </summary>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool Run()
        {
            Button button = new RSG45HARTCommunication.V1011436.GUI.RSG45HARTCommRepoElements().ButtonApply;

            if (button == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
