// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcknowledgeMissingLinkDeviceDialog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides a method to close dialogs coming from the FF H1 CommDTM
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FFH1CommDTM.V1542.SpecificFlows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Provides a method to close dialogs coming from the FF H1 Communication DTM
    /// </summary>
    public class AcknowledgeMissingLinkDeviceDialog
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
            var dialogMessage = new GUI.FFH1CommDTMRepoElements().DialogMessageBox;
            var buttonOk = new GUI.FFH1CommDTMRepoElements().DialogButtonOK;
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
