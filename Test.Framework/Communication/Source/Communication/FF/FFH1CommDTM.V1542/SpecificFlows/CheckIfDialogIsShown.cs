// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckIfDialogIsShown.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides method to check if a dialog is shown
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FFH1CommDTM.V1542.SpecificFlows
{
    using System.Diagnostics;

    /// <summary>
    /// Provides method to check if a dialog is shown
    /// </summary>
    public class CheckIfDialogIsShown
    {
        /// <summary>
        /// Check if the FF H1 Communication DTM dialog box is shown
        /// </summary>
        /// <returns>
        ///     <br>True: if the dialog is shown in time</br>
        ///     <br>False: if dialog is not shown in time</br>
        /// </returns>
        public bool IsDialogShown()
        {
            var dialogButton = new GUI.FFH1CommDTMRepoElements().DialogButtonOK;
            Stopwatch watch = new Stopwatch();

            watch.Start();
            while (dialogButton == null)
            {
                if (watch.ElapsedMilliseconds >= 10000)
                {
                    return false;
                }

                dialogButton = new GUI.FFH1CommDTMRepoElements().DialogButtonOK;
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
