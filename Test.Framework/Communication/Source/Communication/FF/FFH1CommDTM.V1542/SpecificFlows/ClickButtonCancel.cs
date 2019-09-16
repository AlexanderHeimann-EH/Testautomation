// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickButtonCancel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to click the cancel button
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FFH1CommDTM.V1542.SpecificFlows
{
    using Ranorex;

    /// <summary>
    /// Provides function to click the cancel button
    /// </summary>
    public class ClickButtonCancel
    {
        /// <summary>
        /// Clicks the cancel button
        /// </summary>
        public void Run()
        {
            var pressButton = new Functions.ApplicationArea.Execution.PressButton();

            Button button = new GUI.FFH1CommDTMRepoElements().ButtonCancel;

            pressButton.Run(button);
        }
    }
}
