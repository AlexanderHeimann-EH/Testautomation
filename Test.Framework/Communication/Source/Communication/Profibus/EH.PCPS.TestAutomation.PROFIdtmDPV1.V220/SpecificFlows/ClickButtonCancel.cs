// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickButtonCancel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to click the cancel button
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V220.SpecificFlows
{
    using Ranorex;

    /// <summary>
    /// Provides function to click the cancel button
    /// </summary>
    public class ClickButtonCancel
    {
        /// <summary>
        /// Clicks the Cancel button
        /// </summary>
        public bool Run()
        {
            var pressButton = new Functions.ApplicationArea.Execution.PressButton();

            Button button = new GUI.ProfIdtmDpv1RepoElements().ButtonCancel;

            return pressButton.Run(button);
        }
    }
}
