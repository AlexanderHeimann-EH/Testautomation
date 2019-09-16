// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickButtonOK.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to click the OK button
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V220.SpecificFlows
{
    using Ranorex;

    /// <summary>
    /// Provides function to click the Ok button
    /// </summary>
    public class ClickButtonOk
    {
        /// <summary>
        /// Clicks the OK button
        /// </summary>
        public bool Run()
        {
            var pressButton = new Functions.ApplicationArea.Execution.PressButton();

            Button button = new GUI.ProfIdtmDpv1RepoElements().ButtonOk;

            return pressButton.Run(button);
        }
    }
}
