// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClosingInProgressDialog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The closing in progress dialog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.CloseProject.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.CloseProject.Validation;

    using Ranorex.Core;

    /// <summary>
    /// The closing in progress dialog.
    /// </summary>
    public class ClosingInProgressDialog : IClosingInProgressDialog
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether dialog is shown].
        /// </summary>
        /// <returns><c>true</c> if [dialog is shown]; otherwise, <c>false</c>.</returns>
        public bool IsDialogShown()
        {
            Element dialog = new CloseProjectElements().ClosingInProgressDialog;
            return dialog != null;
        }

        /// <summary>
        /// The wait until closing finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool WaitUntilClosingFinished(int timeoutInMilliseconds)
        {
            bool result = true;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (this.IsDialogShown())
            {
                if (watch.ElapsedMilliseconds > timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Closing project did not finish within " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();

            return result;
        }

        #endregion
    }
}