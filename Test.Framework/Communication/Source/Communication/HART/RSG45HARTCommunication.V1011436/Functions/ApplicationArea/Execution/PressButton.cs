

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.Functions.ApplicationArea.Execution
{
    using System.Reflection;
    using Ranorex;
    using EH.PCPS.TestAutomation.Common.Tools;
    /// <summary>
    /// Provides functionalities for buttons
    /// </summary>
    public class PressButton
    {
        /// <summary>
        /// Clicks a button
        /// </summary>
        public bool Run(Button button)
        {
            if (button.Visible)
            {
                button.Click();
                return true;
            }
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not visible. Could not click it");
            return false;
        }
    }
}
