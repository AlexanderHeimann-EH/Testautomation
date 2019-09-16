// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickButtonDefaults.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to click the defaults button
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.SpecificFlows
{
    using Ranorex;

    /// <summary>
    /// Provides function to click the defaults button
    /// </summary>
    public class ClickButtonDefaults
    {
        /// <summary>
        /// Clicks the Defaults button
        /// </summary>
        public bool Run()
        {
            var pressButton = new Functions.ApplicationArea.Execution.PressButton();

            Button button = new GUI.ProfIdtmDpv1RepoElements().ButtonDefaults;

            return pressButton.Run(button);
        }
    }
}
