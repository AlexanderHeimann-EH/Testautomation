namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsHeaderAvailable.
    /// </summary>
    public class IsHeaderAvailable : IIsHeaderAvailable
    {
        #region Public Methods and Operators

        /// <summary>
        /// Validates, whether device header exists in current display content.
        /// </summary>                
        /// <returns><c>true</c> if parameter is available, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            string displayContent = AppComController.GetDisplayContent();
            var result = false;
            if (displayContent.Contains(@"<DeviceHeader"))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device header is available.");
                result = true;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device header is not available.");
            }

            return result;
        }

        #endregion
    }
}