using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.SpecificFlows
{
    /// <summary>
    /// Provides function to click the apply button
    /// </summary>
    public class ClickButtonApply
    {
        /// <summary>
        /// Clicks the button apply
        /// </summary>
        public bool Run()
        {
            var clickButton = new Functions.ApplicationArea.Execution.PressButton();

            return clickButton.Run(new GUI.RSG45HARTCommRepoElements().ButtonApply);
        }
    }
}
