// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClosingInProgressDialog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The ClosingInProgressDialog interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.CloseProject.Validation
{
    /// <summary>
    /// The ClosingInProgressDialog interface.
    /// </summary>
    public interface IClosingInProgressDialog
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether dialog is shown].
        /// </summary>
        /// <returns><c>true</c> if [dialog is shown]; otherwise, <c>false</c>.</returns>
        bool IsDialogShown();

        /// <summary>
        /// The wait until closing finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool WaitUntilClosingFinished(int timeoutInMilliseconds);

        #endregion
    }
}