namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsButtonAvailable.
    /// </summary>
    public class IsButtonAvailable : IIsButtonAvailable
    {
        #region Public Methods and Operators

        /// <summary>
        /// Validates, whether a specified button exists in current display content.
        /// </summary>        
        /// <param name="buttonId">The parameter identifier.</param>
        /// <returns><c>true</c> if button is available, <c>false</c> otherwise.</returns>
        public bool Run(string buttonId)
        {
            string displayContent = AppComController.GetDisplayContent();
            var result = false;
            if (displayContent.Contains(buttonId))
            {
                result = true;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button '" + buttonId + "' is available.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button '" + buttonId + "' is not available.");
            }

            return result;
        }

        #endregion
    }
}