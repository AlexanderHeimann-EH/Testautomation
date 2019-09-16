// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseDialog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to close dialogs coming from the PROFIdtm DPV1
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V220.SpecificFlows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Provides a method to close dialogs coming from the PROFIdtm DPV1
    /// </summary>
    public class CloseDialog
    {
        /// <summary>
        /// Closes a dialog
        /// </summary>
        /// <returns>
        ///     <br>True: if the dialog was successfully closed</br>
        ///     <br>False: if the dialog is still open</br>
        /// </returns>
        public bool Run()
        {
            var dialogMessage = new GUI.ProfIdtmDpv1RepoElements().DialogMessage;
            var buttonOk = new GUI.ProfIdtmDpv1RepoElements().DialogButtonOk;
            var click = new Functions.ApplicationArea.Execution.PressButton();
            var watch = new Stopwatch();

            // log the dialog message
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), dialogMessage.TextValue);

            // close the dialog
            click.Run(buttonOk);

            // check if pop up is closed
            watch.Start();
            bool visible = buttonOk.Visible;
            while (!visible)
            {
                if (watch.ElapsedMilliseconds <= 30000)
                {
                    return false;
                }

                visible = buttonOk.Visible;
            }

            watch.Stop();
            return true;
        }
    }
}
