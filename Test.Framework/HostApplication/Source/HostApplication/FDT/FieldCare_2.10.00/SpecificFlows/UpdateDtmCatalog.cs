// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateDtmCatalog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class UpdateDtmCatalog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.FieldCare.V21000.SpecificFlows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar;

    using Ranorex;

    using Validation = EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Validation;

    /// <summary>
    /// Class UpdateDtmCatalog.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class UpdateDtmCatalog : IUpdateDtmCatalog
    {
        #region Public Methods and Operators

        /// <summary>
        /// Opens the FieldCare Catalog via Menu, starts an update and adds new devices if necessary.
        /// </summary>
        /// <param name="timeToWaitForUpdateMessage">
        /// The time to wait for the update window to appear in milliseconds. Recommended: 5000.
        /// </param>
        /// <param name="timeoutForUpdateProgress">
        /// The timeout For the Update Progress. This depends on how many dtms are found. Recommended: 120000.
        /// </param>
        /// <param name="shouldFindNewOrChangedDevice">
        /// Set to true only if new devices have been installed. They will be added to the catalog.
        /// </param>
        /// <param name="maxMinutesSinceDtmWasInstalled">
        /// The approximate time in minutes since the dtm has been installed
        /// </param>
        /// <param name="timeToWaitForMoving">
        /// The time To Wait For Moving in milliseconds. This is important if the update is huge.
        /// </param>
        /// <returns>
        /// True if the update was successful, false otherwise.<see cref="bool"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(int timeToWaitForUpdateMessage, int timeoutForUpdateProgress, bool shouldFindNewOrChangedDevice, int maxMinutesSinceDtmWasInstalled, int timeToWaitForMoving)
        {
            bool result = true;
            bool dtmsChangedOrNew = false;

            // Open the catalog via menu
            if (Execution.OpenUpdateDtmCatalogue.ViaMenu() == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open Update Catalog dialog.");
            }
            else
            {
                // Wait for the Update Catalog dialog to show up. Wait for a specified time
                if (Validation.ValidationMethods.WaitForCatalogUpdateDialog(timeToWaitForUpdateMessage) == false)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update Catalog dialog did not show up within: " + timeToWaitForUpdateMessage + " milliseconds.");
                }
                else
                {
                    // Update dialog is shown, start the update
                    if (HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Execution.UpdateDtmCatalogue.Update() == false)
                    {
                        result = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Starting Update Catalog failed");
                    }
                    else
                    {
                        // Wait for the update to finish
                        if (Validation.ValidationMethods.WaitUntilUpdatingFinished(timeoutForUpdateProgress) == false)
                        {
                            result = false;
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update progress did not finish within: ");
                        }
                        else
                        {
                            // Update finished, check whether the Confirm removed devices dialog shows up. Confirm if needed.
                            if (Validation.ValidationMethods.WaitForConfirmRemovedDevicesDialog(10000))
                            {
                                Button ok = new UpdateDtmCatalogueElements().RemovedDevicesDialogOkButton;
                                if (ok != null)
                                {
                                    ok.Click();
                                }
                            }

                            // Check for new devices
                            if (Validation.ValidationMethods.AreNewDevicesAvailable())
                            {
                                dtmsChangedOrNew = true;

                                // Select new devices 
                                if (HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Execution.UpdateDtmCatalogue.SelectNewOnLeft(true, maxMinutesSinceDtmWasInstalled) == false)
                                {
                                    result = false;
                                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selecting new devices failed. ");
                                }
                                else
                                {
                                    // Move new devices
                                    if (HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Execution.UpdateDtmCatalogue.Move() == false)
                                    {
                                        result = false;
                                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Moving new devices failed. ");
                                    }
                                    else
                                    {
                                        // Wait for moving to finish if update is huge
                                        if (Validation.ValidationMethods.WaitUntilMovingFinished(timeToWaitForMoving) == false)
                                        {
                                            result = false;
                                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Moving new devices took too long. ");
                                        }
                                    }
                                }
                            }

                            // Check for changed devices
                            if (Validation.ValidationMethods.AreChangedDevicesAvailable())
                            {
                                dtmsChangedOrNew = true;
                            }

                            // Confirm update with ok button
                            if (HostApplicationLoader.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Execution.UpdateDtmCatalogue.Confirm() == false)
                            {
                                result = false;
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update failed. ");
                            }
                        }
                    }
                }

                if (shouldFindNewOrChangedDevice)
                {
                    if (dtmsChangedOrNew == false)
                    {
                        result = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There were no updates to the dtm catalog. No new or changed devices found.");
                    }
                }

                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update successful.");
                }
            }

            return result;
        }

        #endregion
    }
}