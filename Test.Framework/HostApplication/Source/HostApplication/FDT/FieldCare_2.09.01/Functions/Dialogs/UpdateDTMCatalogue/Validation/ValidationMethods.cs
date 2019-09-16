// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ValidationMethods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.UpdateDTMCatalogue.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Validation;

    using Ranorex;

    /// <summary>
    /// Class ValidationMethods.
    /// </summary>
    public class ValidationMethods : IValidationMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// The are changed devices available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AreChangedDevicesAvailable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The are new devices available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AreNewDevicesAvailable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [is catalog update dialog shown].
        /// </summary>
        /// <returns><c>true</c> if [is catalog update dialog shown]; otherwise, <c>false</c>.</returns>
        public bool IsCatalogUpdateDialogShown()
        {
            var updateCatalog = new UpdateDtmCatalogueElements().UpdateCatalogue;
            bool result = updateCatalog != null;

            return result;
        }

        /// <summary>
        /// Determines whether [is confirm deleted devices dialog shown].
        /// </summary>
        /// <returns><c>true</c> if [is confirm deleted devices dialog shown]; otherwise, <c>false</c>.</returns>
        public bool IsConfirmDeletedDevicesDialogShown()
        {
            var confirmDeleteDevicesMessage = new UpdateDtmCatalogueElements().RemovedDevicesDialog;
            bool result = confirmDeleteDevicesMessage != null;

            return result;
        }

        /// <summary>
        /// Waits for catalog update dialog.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if dialog shows up, <c>false</c> otherwise.
        /// </returns>
        public bool WaitForCatalogUpdateDialog(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while (this.IsCatalogUpdateDialogShown() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update Catalog dialog did not show up after: " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();

            return result;
        }

        /// <summary>
        /// Waits for confirm removed devices dialog.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if dialog shows up, <c>false</c> otherwise.
        /// </returns>
        public bool WaitForConfirmRemovedDevicesDialog(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while (this.IsConfirmDeletedDevicesDialogShown() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirm removed devices dialog did not show up after: " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();

            return result;
        }

        /// <summary>
        /// Waits until moving finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if updating finished, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilMovingFinished(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            Button move = new UpdateDtmCatalogueElements().Move;
            if (move == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Move button is null.");
                result = false;
            }
            else
            {
                watch.Start();
                while (move.Enabled)
                {
                    if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                    {
                        result = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Time out reached.Moving took longer than: " + timeoutInMilliseconds + " milliseconds.");
                        break;
                    }
                }

                watch.Stop();
            }

            return result;
        }

        /// <summary>
        /// Waits until updating finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if updating finished, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilUpdatingFinished(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while (this.IsUpdating())
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Time out reached during output. Updating took longer than: " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether catalog update is running
        /// </summary>
        /// <returns><c>true</c> if this instance is updating; otherwise, <c>false</c>.</returns>
        private bool IsUpdating()
        {
            var updateInProgress = new UpdateDtmCatalogueElements().InProgressDialog;
            bool result = updateInProgress != null;

            return result;
        }

        #endregion
    }
}