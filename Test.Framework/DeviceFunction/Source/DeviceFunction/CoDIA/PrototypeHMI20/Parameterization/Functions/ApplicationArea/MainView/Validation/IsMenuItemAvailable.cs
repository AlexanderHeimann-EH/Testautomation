namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsMenuItemAvailable.
    /// </summary>
    public class IsMenuItemAvailable : IIsMenuItemAvailable
    {
        #region Public Methods and Operators

        /// <summary>
        /// Validates, whether a specified menu item exists in current display content.
        /// </summary>        
        /// <param name="menuItemId">The menu item identifier.</param>
        /// <returns><c>true</c> if parameter is available, <c>false</c> otherwise.</returns>
        public bool Run(string menuItemId)
        {
            string displayContent = AppComController.GetDisplayContent();
            var result = false;
            if (displayContent.Contains(menuItemId))
            {
                result = true;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu item '" + menuItemId + "' is available in current display content.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu item '" + menuItemId + "' is not available in current display content.");
            }

            return result;
        }

        #endregion
    }
}