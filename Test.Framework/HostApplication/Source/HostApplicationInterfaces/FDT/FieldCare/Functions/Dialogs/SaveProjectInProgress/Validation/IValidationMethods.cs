// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidationMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The ValidationMethods interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.SaveProjectInProgress.Validation
{
    /// <summary>
    /// The ValidationMethods interface.
    /// </summary>
    public interface IValidationMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether [is saving in progress dialog shown].
        /// </summary>
        /// <returns><c>true</c> if [is saving in progress dialog shown]; otherwise, <c>false</c>.</returns>
        bool IsSavingInProgressDialogShown();

        /// <summary>
        /// Waits until saving finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if updating finished, <c>false</c> otherwise.
        /// </returns>
        bool WaitUntilSavingFinished(int timeoutInMilliseconds);

        #endregion
    }
}