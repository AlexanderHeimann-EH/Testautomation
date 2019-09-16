namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using Common.Tools;

    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class ClickButton.
    /// </summary>
    public class ClickButton : IClickButton
    {
        #region Public Methods and Operators

        /// <summary>
        ///  Clicks a specified button
        /// </summary>
        /// <param name="buttonId">The button identifier.</param>
        /// <returns><c>true</c> if button clicked, <c>false</c> otherwise.</returns>
        public bool Run(string buttonId)
        {
            bool result = false;

            if (AppComController.Controller != null)
            {
                //var eventHandler = new DisplayContentEventHandler(AppComController.Controller);
                var oldDisplayContent = AppComController.GetDisplayContent();

                AppComController.Controller.SetStringValue(buttonId, "placeholder");

                //if (eventHandler.WaitForNewDisplayContent(15000).Result)
                if (DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation.WaitForDisplayContentChanged.Run(oldDisplayContent, 15000))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Recognized display content update. Button clicked.");
                    result = true;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No display content update. Button not clicked.");
                }
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Remote host not connected! Please establish a connection first.");
            }

            return result;
        }

        #endregion
    }
}