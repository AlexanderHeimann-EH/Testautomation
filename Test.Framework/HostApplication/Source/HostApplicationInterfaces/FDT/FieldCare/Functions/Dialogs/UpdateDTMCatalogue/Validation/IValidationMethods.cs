// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidationMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The ValidationMethods interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Validation
{
    /// <summary>
    /// The ValidationMethods interface.
    /// </summary>
    public interface IValidationMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether [is catalog update dialog shown].
        /// </summary>
        /// <returns><c>true</c> if [is catalog update dialog shown]; otherwise, <c>false</c>.</returns>
        bool IsCatalogUpdateDialogShown();

        /// <summary>
        /// Determines whether [is confirm deleted devices dialog shown].
        /// </summary>
        /// <returns><c>true</c> if [is confirm deleted devices dialog shown]; otherwise, <c>false</c>.</returns>
        bool IsConfirmDeletedDevicesDialogShown();

        /// <summary>
        /// Waits for catalog update dialog.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if dialog shows up, <c>false</c> otherwise.
        /// </returns>
        bool WaitForCatalogUpdateDialog(int timeoutInMilliseconds);

        /// <summary>
        /// Waits for confirm removed devices dialog.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if dialog shows up, <c>false</c> otherwise.
        /// </returns>
        bool WaitForConfirmRemovedDevicesDialog(int timeoutInMilliseconds);

        /// <summary>
        /// Waits until moving finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if updating finished, <c>false</c> otherwise.
        /// </returns>
        bool WaitUntilMovingFinished(int timeoutInMilliseconds);

        /// <summary>
        /// Waits until updating finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if updating finished, <c>false</c> otherwise.
        /// </returns>
        bool WaitUntilUpdatingFinished(int timeoutInMilliseconds);

        /// <summary>
        /// Determines whether new devices are available or not.
        /// </summary>
        /// <returns><c>true</c> if new devices are available, <c>false</c> otherwise.</returns>
        bool AreNewDevicesAvailable();

        /// <summary>
        /// Determines whether changed devices are available or not.
        /// </summary>
        /// <returns><c>true</c> if changed devices are available, <c>false</c> otherwise.</returns>
        bool AreChangedDevicesAvailable();

        #endregion
    }
}