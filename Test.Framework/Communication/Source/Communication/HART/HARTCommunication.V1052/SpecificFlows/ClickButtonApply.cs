// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickButtonApply.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to click the apply button
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HARTCommunication.V1052.SpecificFlows
{
    using Ranorex;

    /// <summary>
    /// Provides function to click the apply button
    /// </summary>
    public class ClickButtonApply
    {
        /// <summary>
        /// Clicks the apply button
        /// </summary>
        public bool Run()
        {
            var pressButton = new Functions.ApplicationArea.Execution.PressButton();

            Button button = new GUI.HARTCommRepoElements().ButtonApply;

            return pressButton.Run(button);
        }
    }
}
