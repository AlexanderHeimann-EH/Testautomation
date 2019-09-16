// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ValidationMethods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.Dialogs.UpdateDTMCatalogue.Validation
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Text;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Validation;

    using Ranorex;

    /// <summary>
    /// Class ValidationMethods.
    /// </summary>
    public class ValidationMethods : IValidationMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether changed devices are available or not.
        /// </summary>
        /// <returns><c>true</c> if changed devices are available, <c>false</c> otherwise.</returns>
        public bool AreChangedDevicesAvailable()
        {
            bool result = false;
            int changedDevicesFound = 0;
            IList<Row> changedDeviceRowList = new UpdateDtmCatalogueElements().DevicesOnRight;

            if (changedDeviceRowList == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "List with devices on right side is null or empty.");
            }
            else if (changedDeviceRowList.Count == 0)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No changed devices found, list is empty.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Listing all changed devices:");
                var foundDevices = new StringBuilder();
                foreach (Row myCell in changedDeviceRowList)
                {
                    IList<Unknown> cellChildren = myCell.Children;
                    if (cellChildren.Count > 1)
                    {
                        Cell statusCell = cellChildren[0].Element;
                        Cell deviceTypCell = cellChildren[1].Element;
                        if (statusCell != null && deviceTypCell != null)
                        {
                            if (statusCell.Text != null)
                            {
                                if (statusCell.Text.Contains("Changed"))
                                {                                    
                                    foundDevices.Append(deviceTypCell.Text);
                                    changedDevicesFound++;
                                    result = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cell children from changedDeviceRowList not existing.");
                    }
                }

                if (changedDevicesFound > 0)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), foundDevices.ToString());
                }
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Found " + changedDevicesFound + " changed devices.");
            return result;
        }

        /// <summary>
        /// Determines whether new devices are available or not.
        /// </summary>
        /// <returns><c>true</c> if new devices are available, <c>false</c> otherwise.</returns>
        public bool AreNewDevicesAvailable()
        {
            bool result = false;
            int newDevicesFound = 0;
            IList<Row> newDeviceRowList = (new UpdateDtmCatalogueElements()).DevicesOnLeft;

            if (newDeviceRowList == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "List with devices on left side is null.");
            }
            else if (newDeviceRowList.Count == 0)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No new devices found, list is empty.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Listing all new devices:");
                var foundDevices = new StringBuilder();
                foreach (Row myCell in newDeviceRowList)
                {
                    IList<Unknown> cellChildren = myCell.Children;
                    if (cellChildren.Count > 1)
                    {
                        Cell statusCell = cellChildren[0].Element;
                        Cell deviceTypCell = cellChildren[1].Element;
                        if (statusCell != null && deviceTypCell != null)
                        {
                            if (statusCell.Text != null)
                            {
                                if (statusCell.Text.Contains("New"))
                                {                                    
                                    foundDevices.Append(deviceTypCell.Text);
                                    newDevicesFound++;
                                    result = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cell children from newDeviceRowList not existing.");
                    }
                }

                if (newDevicesFound > 0)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), foundDevices.ToString());
                }
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Found " + newDevicesFound + " new devices.");
            return result;
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
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting until update is finished.");

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

        ///// <summary>
        ///// Determines whether catalog update is running
        ///// </summary>
        ///// <returns><c>true</c> if this instance is updating; otherwise, <c>false</c>.</returns>
        // private bool IsUpdating()
        // {
        // var updateInProgress = new UpdateDtmCatalogueElements().InProgressDialog;
        // bool result = updateInProgress != null;

        // return result;
        // }
        #region Methods

        /// <summary>
        /// Determines whether catalog update is running
        /// </summary>
        /// <returns><c>true</c> if this instance is updating; otherwise, <c>false</c>.</returns>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        private bool IsUpdating()
        {
            var updateInProgress = new UpdateDtmCatalogueElements().InProgressDialog;
            var updateButton = new UpdateDtmCatalogueElements().Update;
            var okButton = new UpdateDtmCatalogueElements().Ok;
            var removedDevicesOkButton = new UpdateDtmCatalogueElements().RemovedDevicesDialogOkButton;

            // ReSharper disable ReplaceWithSingleAssignment.True
            bool result = true;

            if ((updateInProgress == null && updateButton.Enabled && okButton.Enabled) || removedDevicesOkButton != null)
            {
                result = false;
            }
            // ReSharper restore ReplaceWithSingleAssignment.True
            return result;
        }

        #endregion
    }
}