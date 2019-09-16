// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides functionalities for buttons
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.Functions.ApplicationArea.Execution
{
    using System.Reflection;

    using Common.Tools;

    using Ranorex;

    /// <summary>
    /// Provides functionalities for buttons
    /// </summary>
    public class PressButton
    {
        /// <summary>
        /// Clicks the button <see>
        ///         <cref>CDICommDTMRepoElements.ButtonRefresh</cref>
        ///     </see>
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

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not visible. Could not click it");
            return false;
        }
    }
}
