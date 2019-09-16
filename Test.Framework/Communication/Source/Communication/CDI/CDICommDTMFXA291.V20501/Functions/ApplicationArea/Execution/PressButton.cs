// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides functionalities for buttons
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;
using Ranorex;
using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.CDICommDTMFXA291.V20501.Functions.ApplicationArea.Execution
{
    /// <summary>
    /// Provides functionalities for buttons
    /// </summary>
    public class PressButton
    {
        /// <summary>
        /// Clicks the button <see cref="EH.PCPS.TestAutomation.CDICommDTMFXA291.V20501.GUI.CDICommDTMRepoElements.ButtonRefresh"/>
        /// </summary>
        /// <param name="button">
        /// The button.
        /// </param>
        public static bool ExecuteButtonPress(Button button)
        {
            if (button != null && button.Visible)
            {
                button.Click();
                return true;
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not visible. Could not click it");
                return false;
            }
         }
    }
}
