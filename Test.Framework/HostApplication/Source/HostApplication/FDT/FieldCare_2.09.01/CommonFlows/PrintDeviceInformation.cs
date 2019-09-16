// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrintDeviceInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 26.02.2014
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.FieldCare.V20901.CommonFlows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.ReportConfiguration.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;

    using Ranorex;

    /// <summary>
    ///     Provides methods for printing project information
    /// </summary>
    public class PrintDeviceInformation : MarshalByRefObject, IPrintDeviceInformation
    {
        #region Public Methods and Operators

        /// <summary>
        /// Performs a FDT-Print with a specified filename, overwrite if necessary
        /// </summary>
        /// <param name="fileName">
        /// Filename for the printout
        /// </param>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds. Be aware that printing can take several minutes.
        /// </param>
        /// <returns>
        /// true: if FDT-Print was successful; false: if an error occurred
        /// </returns>
        public bool Run(string fileName, int timeoutInMilliseconds)
        {
            bool result = true;
            if ((new OpenFdtPrint()).ViaMenu() == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening FDT-Print dialog failed.");
                result = false;
            }
            else
            {
                (new ReportConfiguration()).SelectReportType("Device Report for Selected Devices");
                Button saveAs = (new ReportConfigurationElements()).SaveAs;
                if (saveAs == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save As button is null.");
                    result = false;
                }
                else
                {
                    saveAs.Click(DefaultValues.locDefaultLocation);
                    if (this.WaitUntilPrintingIsFinished(timeoutInMilliseconds) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Create documentation took too long or is frozen.");
                        Button cancel = new ReportConfigurationElements().Cancel;
                        if (cancel != null)
                        {
                            cancel.Click();
                        }

                        result = false;
                    }
                    else if (Execution.SaveAsFileBrowser.SaveAs(fileName) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving Report failed.");
                        Button cancel = new ReportConfigurationElements().Cancel;
                        if (cancel != null)
                        {
                            cancel.Click();
                        }

                        result = false;
                    }
                    else
                    {
                        // If print out with equal file name already exists and the field care internal dialog comes up
                        Button replaceYes = (new ReplaceProjectMessageElements()).Yes;
                        if (replaceYes != null)
                        {
                            // Confirm replace message
                            replaceYes.Click(DefaultValues.locDefaultLocation);
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Report generated and saved successfully");
                    }
                }
            }

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Waits until generating report (or printing) is finished
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds.
        /// </param>
        /// <returns>
        /// true: if action is finished; false: if an error occurred
        /// </returns>
        private bool WaitUntilPrintingIsFinished(int timeoutInMilliseconds)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (Validation.IsSaveAsDialogOpen.Run() == false)
            {
                if (watch.ElapsedMilliseconds > timeoutInMilliseconds)
                {
                    watch.Stop();
                    return false;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Creating document finished.");
            return true;
        }

        #endregion
    }
}