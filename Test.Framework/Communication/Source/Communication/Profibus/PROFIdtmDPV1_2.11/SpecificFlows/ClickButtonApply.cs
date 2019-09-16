// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickButtonApply.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to click the cancel button
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.SpecificFlows
{
    using Ranorex;

    /// <summary>
    /// Provides function to click the cancel button
    /// </summary>
    public class ClickButtonApply
    {
        /// <summary>
        /// Clicks the Apply button
        /// </summary>
        public bool Run()
        {
            var pressButton = new Functions.ApplicationArea.Execution.PressButton();

            Button button = new GUI.ProfIdtmDpv1RepoElements().ButtonApply;

            return pressButton.Run(button);
        }
    }
}
