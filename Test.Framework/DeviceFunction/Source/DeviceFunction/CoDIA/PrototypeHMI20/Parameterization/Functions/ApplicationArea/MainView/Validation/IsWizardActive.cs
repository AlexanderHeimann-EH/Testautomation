namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsWizardActive.
    /// </summary>
    public class IsWizardActive : IIsWizardActive
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether a wizard sequence is active. (Are wizard navigation buttons on screen?)
        /// </summary>        
        /// <returns><c>true</c> if wizard sequence is active, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            var result = false;

            if (AppComController.GetDisplayContent().Contains("WizardButton id="))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A wizard is active.");
                result = true;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No wizard active.");
            }


            return result;
        }

        #endregion
    }
}