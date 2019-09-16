// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides functionalities for buttons
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.Functions.ApplicationArea.Execution
{
    using Ranorex;
    using System.Reflection;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Provides functionalities for buttons
    /// </summary>
    public class PressButton
    {
        /// <summary>
        /// Clicks a button
        /// </summary>
        /// <param name="button">
        /// The button.
        /// </param>
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
