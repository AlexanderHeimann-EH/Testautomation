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

    /// <summary>
    /// Class IsWizardFinished.
    /// </summary>
    public class IsWizardFinished : IIsWizardFinished
    {
        /// <summary>
        /// Determines whether a wizard sequence is finished.
        /// </summary>        
        /// <returns><c>true</c> if wizard sequence is finished, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            var result = false;

            if (new IsWizardActive().Run())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A wizard is active.");                
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Wizard finished.");
                result = true;
            }


            return result;

        }
    }
}
