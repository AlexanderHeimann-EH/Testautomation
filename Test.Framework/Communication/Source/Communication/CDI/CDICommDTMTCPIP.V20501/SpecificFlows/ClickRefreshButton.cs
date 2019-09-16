// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickRefreshButton.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to click the refresh button
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.SpecificFlows
{
    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.GUI;

    using Ranorex;

    /// <summary>
    /// Provides a method to click the refresh button
    /// </summary>
    public static class ClickRefreshButton
    {
        /// <summary>
        /// Clicks the refresh button of the CDI Communication DTM
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool Run()
        {
            Button button = new CDICommDTMRepoElements().ButtonRefresh;
            if (button != null && button.Visible)
            {
                button.Click();
                return true;
            }

            return false;
        }
    }
}
