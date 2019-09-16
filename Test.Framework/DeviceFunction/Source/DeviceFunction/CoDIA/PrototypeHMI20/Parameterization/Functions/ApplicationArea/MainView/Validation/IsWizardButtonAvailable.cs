using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsWizardButtonAvailable.
    /// </summary>
    public class IsWizardButtonAvailable : IIsWizardButtonAvailable
    {
        /// <summary>
        /// Determines whether a specific wizard button (next, previous, cancel) is available in current display content
        /// </summary>
        /// <param name="buttonId">The button identifier.</param>
        /// <returns><c>true</c> if button is available, <c>false</c> otherwise.</returns>
        public bool Run(string buttonId)
        {
            var result = false;

            if (AppComController.GetDisplayContent().Contains(buttonId))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button '" + buttonId + "' is available.");
                result = true;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button '" + buttonId + "' is not available.");
            }
            
        
            return result;
        }
    }
}
