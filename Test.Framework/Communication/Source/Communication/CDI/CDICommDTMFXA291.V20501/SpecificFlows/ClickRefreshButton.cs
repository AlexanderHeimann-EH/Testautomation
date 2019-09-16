// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickRefreshButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to click the refresh button
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMFXA291.V20501.SpecificFlows
{
    using Ranorex;

    /// <summary>
    /// Provides a method to click the refresh button
    /// </summary>
    public static class ClickRefreshButton
    {
        /// <summary>
        /// Clicks the refresh button of the CDI Communication DTM
        /// </summary>
        public static bool Run()
        {
            Button button = new GUI.CDICommDTMRepoElements().ButtonRefresh;
            if (button != null && button.Visible)
            {
                button.Click();
                return true;
            }
            return false;
        }
    }
}
