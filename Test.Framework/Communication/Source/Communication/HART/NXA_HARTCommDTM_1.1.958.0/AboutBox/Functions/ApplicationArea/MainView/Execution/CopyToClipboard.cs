//------------------------------------------------------------------------------
// <copyright file="CopyToClipboard.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.AboutBox.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.AboutBox.Functions.ApplicationArea.MainView.Execution;

    using Ranorex.Core;

    /// <summary>
    /// Copies the About box information to clip board
    /// </summary>
    public class CopyToClipboard : ICopyToClipboard
    {
        /// <summary>
        /// Starts execution
        /// </summary>
        /// <returns>
        /// true if the button is found and clicked
        /// false if an error occurred
        /// </returns>
        public bool Run()
        {
            Element copyToClipboardButton =
                (new GUI.ApplicationArea.MainView.AboutBoxMainViewElements()).ButtonCopyToClipboard;
            if (copyToClipboardButton == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), 
                    "The button Copy to Clip Board is not accessible. Check the Ranorex path in the repository");
            }

            Ranorex.Mouse.Click(copyToClipboardButton);
            return true;
        }
    }
}
