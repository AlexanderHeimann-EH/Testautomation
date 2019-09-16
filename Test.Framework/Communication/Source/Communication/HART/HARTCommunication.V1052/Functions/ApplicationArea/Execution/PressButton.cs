// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides functionalities for buttons
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HARTCommunication.V1052.Functions.ApplicationArea.Execution
{
    using Ranorex;
    using EH.PCPS.TestAutomation.Common.Tools;
    using System.Reflection;

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
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not visible.");
            return false;
            
        }
    }
}
