// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckIfDialogIsShown.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides method to check if a dialog is shown
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.SpecificFlows
{
    using System.Diagnostics;

    /// <summary>
    /// Provides method to check if a dialog is shown
    /// </summary>
    public class CheckIfDialogIsShown
    {
        /// <summary>
        /// Check if the PROFIdtm DPV1 dialogbox is shown
        /// </summary>
        /// <returns>
        ///     <br>True: if the dialog is shown in time</br>
        ///     <br>False: if dialog is not shown in time</br>
        /// </returns>
        public bool IsDialogShown()
        {
            var dialogButton = new GUI.ProfIdtmDpv1RepoElements().DialogButtonOk;
            Stopwatch watch = new Stopwatch();

            watch.Start();
            while (dialogButton == null)
            {
                if (watch.ElapsedMilliseconds >= 10000)
                {
                    return false;
                }

                dialogButton = new GUI.ProfIdtmDpv1RepoElements().DialogButtonOk;
            }

            watch.Stop();

            if (dialogButton.Visible)
            {
                return true;
            }

            return false;
        }
    }
}
