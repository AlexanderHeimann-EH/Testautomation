// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ValidationMethods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.SaveProjectInProgress.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.SaveProjectInProgress.Validation;

    /// <summary>
    /// Class ValidationMethods.
    /// </summary>
    public class ValidationMethods : IValidationMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether [is saving in progress dialog shown].
        /// </summary>
        /// <returns><c>true</c> if [is saving in progress dialog shown]; otherwise, <c>false</c>.</returns>
        public bool IsSavingInProgressDialogShown()
        {
            var inProgressDialog = new SaveProjectProgressElements().SavingInProgressDialog;
            bool result = inProgressDialog != null;
            return result;
        }

        /// <summary>
        /// Waits until saving finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if updating finished, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilSavingFinished(int timeoutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();
            while (this.IsSavingInProgressDialogShown())
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Time out reached during saving. Saving took longer than: " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();

            return result;
        }

        #endregion
    }
}