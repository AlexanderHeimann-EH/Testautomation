// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidationMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The ValidationMethods interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Validation
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
        /// Waits for catalog update dialog.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if dialog shows up, <c>false</c> otherwise.
        /// </returns>
        bool WaitForCatalogUpdateDialog(int timeoutInMilliseconds);

        #endregion
    }
}